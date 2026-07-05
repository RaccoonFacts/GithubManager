namespace GithubManager
{


    public partial class Form1 : Form
    {
        private Octokit.GitHubClient _client;
        private string _username;
        private GitHubSocialManager _social;
        private FollowTracker _tracker;
        private FollowCrawler _crawler;
        private CancellationTokenSource _bulkCts;
        private System.Windows.Forms.Timer _countdownTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string token = TokenStorage.Load();

            if (string.IsNullOrWhiteSpace(token))
            {
                token = PromptForToken(out _);
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                MessageBox.Show("No token provided.");
                Close();
                return;
            }

            _client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("GHSocialTool"))
            {
                Credentials = new Octokit.Credentials(token)
            };

            try
            {
                var current = await _client.User.Current();
                _username = current.Login;
                _social = new GitHubSocialManager(token, _username);
                _tracker = new FollowTracker(_username);
                _keepList = new KeepList(_username);
                _neverFollow = new NeverFollowList(_username);

                // Initialize ListView columns
                if (lvKeepList.Columns.Count == 0)
                {
                    lvKeepList.Columns.Add("Username", 280);
                    lvKeepList.Columns.Add("Added", 275);
                }
                if (lvNeverFollow.Columns.Count == 0)
                    lvNeverFollow.Columns.Add("Blacklisted Username", 560);

                // Pre-populate Never Follow list from disk
                lvNeverFollow.Items.Clear();
                foreach (var login in _neverFollow.All.OrderBy(l => l))
                    lvNeverFollow.Items.Add(new System.Windows.Forms.ListViewItem(login));

                Text = $"GitHub Manager - {_username}";
                lblStatus.Text = $"Logged in as {_username}";

                tabProfile.Controls.Add(lblProfileCountdown);
                await RefreshOverviewAsync();
            }
            catch (Octokit.AuthorizationException)
            {
                TokenStorage.Clear(); // token is bad, wipe it
                MessageBox.Show("Invalid token or insufficient scopes (needs 'user:follow'). Saved token cleared.");
                Close();
            }
        }

        private string PromptForToken(out bool save)
        {
            save = false;
            bool _save = false;

            using var prompt = new Form
            {
                Width = 420,
                Height = 185,
                Text = "Enter GitHub PAT",
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            var lbl = new Label { Left = 10, Top = 10, Width = 380, Text = "Personal Access Token (user:follow scope required):" };
            var txt = new TextBox { Left = 10, Top = 33, Width = 380, UseSystemPasswordChar = true };
            var chkSave = new CheckBox { Left = 10, Top = 65, Width = 300, Text = "Remember token (encrypted, stored locally)" };
            var btnClear = new Button { Left = 10, Top = 100, Width = 120, Text = "Clear Saved Token" };
            var btn = new Button { Left = 300, Top = 100, Width = 90, Text = "OK", DialogResult = DialogResult.OK };

            btnClear.Click += (s, ev) =>
            {
                TokenStorage.Clear();
                MessageBox.Show("Saved token cleared.");
            };

            prompt.Controls.AddRange(new Control[] { lbl, txt, chkSave, btnClear, btn });
            prompt.AcceptButton = btn;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                _save = chkSave.Checked;
                save = _save;
                var token = txt.Text.Trim();
                if (_save && !string.IsNullOrEmpty(token))
                    TokenStorage.Save(token);
                return token;
            }
            return null;
        }

        private async void btnChangeToken_Click(object sender, EventArgs e)
        {
            var token = PromptForToken(out _);
            if (string.IsNullOrWhiteSpace(token)) return;

            try
            {
                var testClient = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("GHSocialTool"))
                {
                    Credentials = new Octokit.Credentials(token)
                };
                var current = await testClient.User.Current();

                // Token valid — swap everything out
                _social = new GitHubSocialManager(token, current.Login);
                _username = current.Login;
                _tracker = new FollowTracker(_username);
                _keepList = new KeepList(_username);
                _neverFollow = new NeverFollowList(_username);

                Text = $"GitHub Manager - {_username}";
                lblStatus.Text = $"Logged in as {_username}";

                await RefreshOverviewAsync();
                MessageBox.Show($"Token updated. Now logged in as {_username}.");
            }
            catch (Octokit.AuthorizationException)
            {
                MessageBox.Show("Invalid token or insufficient scopes. Token not changed.");
            }
        }

        private async Task RefreshOverviewAsync()
        {
            lblStatus.Text = "Refreshing...";
            var followers = await _social.GetFollowersAsync();
            var following = await _social.GetFollowingAsync();
            var remaining = await _social.GetRemainingRateLimitAsync();

            lblFollowers.Text = $"Followers: {followers.Count}";
            lblFollowing.Text = $"Following: {following.Count}";
            lblRateLimit.Text = $"API calls remaining: {remaining}";
            lblStatus.Text = $"Logged in as {_username}";
        }

        private async void btnRefreshOverview_Click(object sender, EventArgs e)
        {
            await RefreshOverviewAsync();
        }

        // ---------------- Diff tab ----------------

        private List<Octokit.User> _notFollowingBack = new();
        private List<Octokit.User> _notFollowedYet = new();
        private KeepList _keepList;
        private NeverFollowList _neverFollow;
        private readonly ListViewDaySorter _diffSorter = new();

        private async void btnLoadDiff_Click(object sender, EventArgs e)
        {
            btnLoadDiff.Enabled = false;
            lvNotFollowingBack.Items.Clear();
            lvNotFollowedYet.Items.Clear();
            lvKeepList.Items.Clear();

            if (lvNotFollowingBack.Columns.Count < 2)
            {
                lvNotFollowingBack.Columns.Clear();
                lvNotFollowingBack.Columns.Add("Username", 160);
                lvNotFollowingBack.Columns.Add("Following Since", 130);
            }
            if (lvNotFollowedYet.Columns.Count < 2)
            {
                lvNotFollowedYet.Columns.Clear();
                lvNotFollowedYet.Columns.Add("Username", 160);
                lvNotFollowedYet.Columns.Add("Their Age", 130);
            }
            if (lvKeepList.Columns.Count < 2)
            {
                lvKeepList.Columns.Clear();
                lvKeepList.Columns.Add("Username", 160);
                lvKeepList.Columns.Add("Added", 130);
            }

            var (notFollowingBack, notFollowedYet) = await _social.DiffAsync();
            _notFollowingBack = notFollowingBack;
            _notFollowedYet = notFollowedYet;

            // Populate keep list from persisted data
            foreach (var kv in _keepList.All.OrderBy(k => k.Key))
            {
                var item = new System.Windows.Forms.ListViewItem(kv.Key);
                item.SubItems.Add(kv.Value.ToLocalTime().ToString("yyyy-MM-dd"));
                lvKeepList.Items.Add(item);
            }

            // Populate never follow list
            lvNeverFollow.Items.Clear();
            foreach (var login in _neverFollow.All.OrderBy(l => l))
                lvNeverFollow.Items.Add(new System.Windows.Forms.ListViewItem(login));

            // Wire sorter once
            if (lvNotFollowingBack.ListViewItemSorter == null)
            {
                lvNotFollowingBack.ListViewItemSorter = _diffSorter;
                lvNotFollowingBack.ColumnClick += (s, e) =>
                {
                    _diffSorter.SetColumn(e.Column);
                    lvNotFollowingBack.Sort();
                };
            }

            // Filter keep list and never follow list out of doesnt-follow-back
            foreach (var u in _notFollowingBack)
            {
                if (_keepList.Contains(u.Login)) continue;
                if (_neverFollow.Contains(u.Login)) continue;
                int days = _tracker?.DaysFollowing(u.Login) ?? int.MaxValue;
                var age = _tracker?.FormatAge(u.Login) ?? "unknown";
                var item = new System.Windows.Forms.ListViewItem(u.Login) { Checked = false, Tag = days };
                item.SubItems.Add(age);
                lvNotFollowingBack.Items.Add(item);
            }

            // Default sort: most days first (who's been ignoring you longest)
            _diffSorter.SetColumn(1);
            lvNotFollowingBack.Sort();

            foreach (var u in _notFollowedYet)
            {
                var item = new System.Windows.Forms.ListViewItem(u.Login) { Checked = false };
                item.SubItems.Add("—");
                lvNotFollowedYet.Items.Add(item);
            }

            var kept = _notFollowingBack.Count(u => _keepList.Contains(u.Login));
            lblDiffStatus.Text = $"You follow {_notFollowingBack.Count} who don't follow back " +
                                 $"({kept} kept, {_notFollowingBack.Count - kept} shown). " +
                                 $"{_notFollowedYet.Count} follow you that you don't follow back.";
            btnLoadDiff.Enabled = true;
        }

        private void btnSelectAllNotFollowingBack_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.ListViewItem item in lvNotFollowingBack.Items) item.Checked = true;
        }

        private void btnSelectAllNotFollowedYet_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.ListViewItem item in lvNotFollowedYet.Items) item.Checked = true;
        }

        private void btnAddToKeep_Click(object sender, EventArgs e)
        {
            var selected = lvNotFollowingBack.Items.Cast<System.Windows.Forms.ListViewItem>()
                .Where(i => i.Checked).ToList();
            if (selected.Count == 0) return;

            foreach (var i in selected)
            {
                _keepList.Add(i.Text);
                lvNotFollowingBack.Items.Remove(i);
                var kept = new System.Windows.Forms.ListViewItem(i.Text);
                kept.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                lvKeepList.Items.Add(kept);
            }

            var keptCount = _notFollowingBack.Count(u => _keepList.Contains(u.Login));
            lblDiffStatus.Text = $"You follow {_notFollowingBack.Count} who don't follow back " +
                                 $"({keptCount} kept, {lvNotFollowingBack.Items.Count} shown). " +
                                 $"{_notFollowedYet.Count} follow you that you don't follow back.";
        }

        private void btnRemoveFromKeep_Click(object sender, EventArgs e)
        {
            var selected = lvKeepList.SelectedItems.Cast<System.Windows.Forms.ListViewItem>().ToList();
            if (selected.Count == 0) return;

            foreach (var i in selected)
            {
                _keepList.Remove(i.Text);
                lvKeepList.Items.Remove(i);

                var user = _notFollowingBack.FirstOrDefault(u => u.Login == i.Text);
                if (user != null)
                {
                    var age = _tracker?.FormatAge(user.Login) ?? "unknown";
                    var item = new System.Windows.Forms.ListViewItem(user.Login) { Checked = false };
                    item.SubItems.Add(age);
                    lvNotFollowingBack.Items.Add(item);
                }
            }
        }

        private async void btnAddToNeverFollow_Click(object sender, EventArgs e)
        {
            var selected = lvNotFollowingBack.Items.Cast<System.Windows.Forms.ListViewItem>()
                .Where(i => i.Checked).ToList();
            if (selected.Count == 0) return;

            btnAddToNeverFollow.Enabled = false;

            foreach (var i in selected)
            {
                _neverFollow.Add(i.Text);
                lvNotFollowingBack.Items.Remove(i);
                lvNeverFollow.Items.Add(new System.Windows.Forms.ListViewItem(i.Text));
                try
                {
                    await _social.UnfollowAsync(i.Text);
                    lstLog.Items.Insert(0, $"Unfollowed + blacklisted: {i.Text}");
                }
                catch (Exception ex)
                {
                    lstLog.Items.Insert(0, $"Blacklisted (unfollow failed): {i.Text} — {ex.Message}");
                }
                await Task.Delay(800);
            }

            btnAddToNeverFollow.Enabled = true;
        }

        private void btnRemoveFromNeverFollow_Click(object sender, EventArgs e)
        {
            var selected = lvNeverFollow.SelectedItems.Cast<System.Windows.Forms.ListViewItem>().ToList();
            if (selected.Count == 0) return;
            foreach (var i in selected)
            {
                _neverFollow.Remove(i.Text);
                lvNeverFollow.Items.Remove(i);
            }
        }

        private void btnImportNeverFollow_Click(object sender, EventArgs e)
        {
            using var dlg = new System.Windows.Forms.OpenFileDialog
            {
                Title = "Import Never Follow List",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            var lines = File.ReadAllLines(dlg.FileName)
                .Select(l => l.Trim().Trim('"').TrimEnd(',').Trim())
                .Where(l => !string.IsNullOrEmpty(l))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            int added = 0;
            foreach (var login in lines)
            {
                if (_neverFollow.Contains(login)) continue;
                _neverFollow.Add(login);
                lvNeverFollow.Items.Add(new System.Windows.Forms.ListViewItem(login));
                added++;
            }

            MessageBox.Show($"Imported {added} new entries ({lines.Count - added} already existed).");
        }

        private async void btnUnfollowSelected_Click(object sender, EventArgs e)
        {
            var selected = lvNotFollowingBack.Items.Cast<ListViewItem>()
                .Where(i => i.Checked)
                .Select(i => _notFollowingBack.First(u => u.Login == i.Text))
                .ToList();

            if (selected.Count == 0) return;
            if (MessageBox.Show($"Unfollow {selected.Count} users?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            btnUnfollowSelected.Enabled = false;
            _bulkCts = new CancellationTokenSource();
            var progress = new Progress<string>(msg => lstLog.Items.Insert(0, msg));

            try
            {
                await _social.MassUnfollowAsync(selected, progress, _bulkCts.Token);
            }
            catch (OperationCanceledException) { }

            btnUnfollowSelected.Enabled = true;
            await RefreshOverviewAsync();
        }

        private async void btnFollowSelected_Click(object sender, EventArgs e)
        {
            var selected = lvNotFollowedYet.Items.Cast<ListViewItem>()
                .Where(i => i.Checked)
                .Select(i => _notFollowedYet.First(u => u.Login == i.Text))
                .ToList();

            if (selected.Count == 0) return;
            if (MessageBox.Show($"Follow {selected.Count} users?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            btnFollowSelected.Enabled = false;
            _bulkCts = new CancellationTokenSource();
            var progress = new Progress<string>(msg => lstLog.Items.Insert(0, msg));

            try
            {
                await _social.MassFollowAsync(selected, progress, _bulkCts.Token);
            }
            catch (OperationCanceledException) { }

            btnFollowSelected.Enabled = true;
            await RefreshOverviewAsync();
        }

        private void btnCancelBulk_Click(object sender, EventArgs e)
        {
            _bulkCts?.Cancel();
        }

        // ---------------- Crawler tab ----------------

        private static readonly HttpClient _http = new();

        private async void btnValidateTarget_Click(object sender, EventArgs e)
        {
            var target = txtTargetUser.Text.Trim();
            if (string.IsNullOrEmpty(target)) return;

            btnValidateTarget.Enabled = false;
            ClearProfileCard();

            try
            {
                var user = await _social.GetFullProfileAsync(target);

                // Avatar
                try
                {
                    var bytes = await _http.GetByteArrayAsync(user.AvatarUrl);
                    using var ms = new System.IO.MemoryStream(bytes);
                    picTargetAvatar.Image = Image.FromStream(ms);
                }
                catch { picTargetAvatar.Image = null; }

                // Stats
                double ratio = user.Followers > 0
                    ? Math.Round((double)user.Following / user.Followers, 2)
                    : user.Following;

                lblTargetName.Text = $"{user.Login}{(string.IsNullOrEmpty(user.Name) ? "" : $" ({user.Name})")}";
                lblTargetFollowers.Text = $"Followers: {user.Followers:N0}";
                lblTargetFollowing.Text = $"Following: {user.Following:N0}";
                lblTargetRepos.Text = $"Public repos: {user.PublicRepos}  |  Follow ratio: {ratio:0.##}x";

                lnkTargetProfile.Text = $"https://github.com/{user.Login}";
                lnkTargetProfile.Links.Clear();
                lnkTargetProfile.Links.Add(0, lnkTargetProfile.Text.Length, lnkTargetProfile.Text);

                // Target quality assessment
                var score = 0;
                var notes = new List<string>();

                if (user.Followers >= 500) { score += 2; notes.Add($"{user.Followers:N0} followers ✓"); }
                else if (user.Followers >= 100) { score += 1; notes.Add($"{user.Followers:N0} followers (moderate)"); }
                else { notes.Add($"Low follower count ({user.Followers})"); }

                if (ratio <= 2) { score += 2; notes.Add("healthy follow ratio ✓"); }
                else if (ratio <= 5) { score += 1; notes.Add("moderate follow ratio"); }
                else { notes.Add($"high follow ratio ({ratio:0.#}x) — possible bot-farm"); }

                if (user.PublicRepos >= 5) { score += 1; notes.Add($"{user.PublicRepos} repos ✓"); }
                else { notes.Add($"few public repos ({user.PublicRepos})"); }

                if (!string.IsNullOrEmpty(user.Bio)) { score += 1; notes.Add("has bio ✓"); }
                if (!string.IsNullOrEmpty(user.Company)) { score += 1; notes.Add("has company ✓"); }

                var accountAge = DateTime.UtcNow - user.CreatedAt.UtcDateTime;
                if (accountAge.TotalDays >= 365) { score += 1; notes.Add("established account ✓"); }
                else { notes.Add($"new account ({(int)accountAge.TotalDays}d old)"); }

                string rating;
                Color ratingColor;
                if (score >= 7) { rating = "⭐ Excellent target"; ratingColor = Color.Green; }
                else if (score >= 5) { rating = "✔ Good target"; ratingColor = Color.DarkGreen; }
                else if (score >= 3) { rating = "⚠ Decent target"; ratingColor = Color.DarkOrange; }
                else { rating = "✘ Poor target"; ratingColor = Color.Red; }

                lblTargetAssessment.Text = $"{rating}  |  {string.Join(", ", notes)}";
                lblTargetAssessment.ForeColor = ratingColor;
            }
            catch (Octokit.NotFoundException)
            {
                lblTargetAssessment.Text = "User not found.";
                lblTargetAssessment.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                lblTargetAssessment.Text = $"Error: {ex.Message}";
                lblTargetAssessment.ForeColor = Color.Red;
            }

            btnValidateTarget.Enabled = true;
        }

        private void lnkTargetProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.LinkData is string url)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void ClearProfileCard()
        {
            picTargetAvatar.Image = null;
            lblTargetName.Text = "";
            lblTargetFollowers.Text = "";
            lblTargetFollowing.Text = "";
            lblTargetRepos.Text = "";
            lnkTargetProfile.Text = "";
            lblTargetAssessment.Text = "";
            lblTargetAssessment.ForeColor = SystemColors.ControlText;
        }

        private async void btnPullCandidates_Click(object sender, EventArgs e)
        {
            var target = txtTargetUser.Text.Trim();
            if (string.IsNullOrEmpty(target))
            {
                MessageBox.Show("Enter a username to pull from.");
                return;
            }

            btnPullCandidates.Enabled = false;
            lblCrawlerStatus.Text = $"Pulling following list for {target}...";

            try
            {
                txtCandidates.Clear();
                lblCrawlerStatus.Text = "Fetching your following list (filter set)...";

                List<Octokit.User> myFollowing;
                using (var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    var followingTask = _social.GetFollowingAsync();
                    var completed = await Task.WhenAny(followingTask, Task.Delay(Timeout.Infinite, timeoutCts.Token));
                    if (completed != followingTask)
                    {
                        MessageBox.Show("Timed out fetching your following list after 30s. Check network/firewall, or that your PAT has user:follow scope.");
                        lblCrawlerStatus.Text = "Pull failed: timeout.";
                        btnPullCandidates.Enabled = true;
                        return;
                    }
                    myFollowing = await followingTask;
                }

                var alreadyFollowed = myFollowing.Select(u => u.Login)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);
                alreadyFollowed.Add(_username);

                bool useQualityFilter = chkQualityFilter.Checked;
                int minRepos = (int)numMinRepos.Value;
                int maxRatio = (int)numMaxRatio.Value;
                int queueTarget = (int)numQueueTarget.Value;

                int totalSeen = 0;
                int totalAdded = 0;
                var stopRequested = false;

                Func<List<Octokit.User>, Task<bool>> onPage = async batch =>
                {
                    if (stopRequested) return false;

                    totalSeen += batch.Count;
                    var candidates = batch.Where(u =>
                        !alreadyFollowed.Contains(u.Login) &&
                        !(_neverFollow?.Contains(u.Login) ?? false)).ToList();

                    foreach (var u in candidates)
                    {
                        if (totalAdded >= queueTarget) { stopRequested = true; break; }

                        if (useQualityFilter)
                        {
                            Octokit.User full;
                            try
                            {
                                full = await _social.GetFullProfileAsync(u.Login);
                            }
                            catch (Octokit.NotFoundException) { continue; }
                            catch (Octokit.RateLimitExceededException)
                            {
                                stopRequested = true;
                                lblCrawlerStatus.Text = "Rate limit hit during quality check — stopping pull.";
                                break;
                            }

                            if (full.PublicRepos < minRepos) continue;

                            // bot-farm heuristic: follows way more than follows them back
                            bool looksLikeBotFarm = full.Followers == 0
                                ? full.Following > 50
                                : (double)full.Following / full.Followers > maxRatio;

                            if (looksLikeBotFarm) continue;
                        }

                        totalAdded++;
                        txtCandidates.AppendText(u.Login + Environment.NewLine);
                    }

                    lblCrawlerStatus.Text = $"Fetching from {target}... {totalSeen} seen, {totalAdded}/{queueTarget} queued";
                    return !stopRequested;
                };

                if (rbSourceFollowers.Checked)
                    await _social.GetFollowersOfAsync(target, onPage);
                else
                    await _social.GetFollowingOfAsync(target, onPage);

                lblCrawlerStatus.Text = stopRequested
                    ? $"Stopped: {totalAdded} qualified candidates queued ({totalSeen} scanned)."
                    : $"Done. {totalSeen} scanned, {totalAdded} candidates queued.";
            }
            catch (Octokit.NotFoundException)
            {
                MessageBox.Show($"User '{target}' not found.");
                lblCrawlerStatus.Text = "Pull failed: user not found.";
            }
            catch (Octokit.RateLimitExceededException rex)
            {
                MessageBox.Show($"Rate limit hit. Resets at {rex.Reset.LocalDateTime}.");
                lblCrawlerStatus.Text = "Pull failed: rate limited.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Pull failed: {ex.GetType().Name} - {ex.Message}");
                lblCrawlerStatus.Text = "Pull failed.";
            }

            btnPullCandidates.Enabled = true;
        }

        private void btnStartCrawler_Click(object sender, EventArgs e)
        {
            var candidates = txtCandidates.Lines
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrEmpty(l))
                .Where(l => !(_neverFollow?.Contains(l) ?? false))
                .ToList();

            if (candidates.Count == 0)
            {
                MessageBox.Show("No candidates remaining after blacklist filter.");
                return;
            }

            int cap = (int)numDailyCap.Value;
            int minMin = (int)numMinInterval.Value;
            int maxMin = (int)numMaxInterval.Value;

            _crawler = new FollowCrawler(_social, _tracker, candidates, cap, minMin * 60000, maxMin * 60000);
            _crawler.Start(msg => lstCrawlerLog.Items.Insert(0, msg));

            _countdownTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _countdownTimer.Tick += (s, args) => UpdateCountdownLabel();
            _countdownTimer.Start();

            btnStartCrawler.Enabled = false;
            btnStopCrawler.Enabled = true;
            lblCrawlerStatus.Text = "Crawler running.";
        }

        private void UpdateCountdownLabel()
        {
            if (_crawler == null || !_crawler.IsRunning)
            {
                lblCrawlerStatus.Text = "Crawler stopped.";
                return;
            }

            if (_crawler.NextFollowAt is DateTime next)
            {
                var remaining = next - DateTime.Now;
                lblCrawlerStatus.Text = remaining > TimeSpan.Zero
                    ? $"Next follow in: {remaining:mm\\:ss}  |  Daily: {_crawler.DailyCount}/{(int)numDailyCap.Value}  |  Queue: {_crawler.RemainingCandidates}"
                    : "Following now...";
            }
            else
            {
                lblCrawlerStatus.Text = "Following now...";
            }
        }

        private void btnStopCrawler_Click(object sender, EventArgs e)
        {
            _crawler?.Stop();
            _countdownTimer?.Stop();
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            lblCrawlerStatus.Text = "Crawler stopped.";
            btnStartCrawler.Enabled = true;
            btnStopCrawler.Enabled = false;
        }

        private void btnExportCandidates_Click(object sender, EventArgs e)
        {
            var lines = txtCandidates.Lines
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrEmpty(l))
                .ToList();

            if (lines.Count == 0) { MessageBox.Show("Candidate queue is empty."); return; }

            using var dlg = new SaveFileDialog
            {
                Title = "Export Candidate Queue",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = $"candidates_{DateTime.Now:yyyyMMdd_HHmm}.txt",
                DefaultExt = "txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(dlg.FileName, lines);
                MessageBox.Show($"Exported {lines.Count} candidates to {dlg.FileName}");
            }
        }

        private void btnExportFollowLog_Click(object sender, EventArgs e)
        {
            if (_tracker == null || _tracker.All.Count == 0)
            {
                MessageBox.Show("No follow log entries yet."); return;
            }

            using var dlg = new SaveFileDialog
            {
                Title = "Export Follow Log",
                Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName = $"follow_log_{DateTime.Now:yyyyMMdd_HHmm}.csv",
                DefaultExt = "csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var lines = new List<string> { "username,followed_date,days_ago" };
                lines.AddRange(_tracker.All
                    .OrderByDescending(kv => kv.Value)
                    .Select(kv => $"{kv.Key},{kv.Value:yyyy-MM-dd HH:mm},{(int)(DateTime.UtcNow - kv.Value).TotalDays}d"));
                File.WriteAllLines(dlg.FileName, lines);
                MessageBox.Show($"Exported {_tracker.All.Count} entries to {dlg.FileName}");
            }
        }

        // ================================================================
        // Auto Follow-Back tab
        // ================================================================
        private AutoFollowBackService _autoFollowBack;
        private System.Windows.Forms.Timer _afbCountdown;

        private void btnStartAutoFollowBack_Click(object sender, EventArgs e)
        {
            int mins = (int)numAFBInterval.Value;
            _autoFollowBack = new AutoFollowBackService(_social, _tracker);
            _autoFollowBack.Start(mins, msg =>
            {
                lstAFBLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {msg}");
            });

            _afbCountdown = new System.Windows.Forms.Timer { Interval = 1000 };
            _afbCountdown.Tick += (s, args) =>
            {
                if (_autoFollowBack?.NextPollAt is DateTime next)
                {
                    var rem = next - DateTime.Now;
                    lblAFBCountdown.Text = rem > TimeSpan.Zero
                        ? $"Next poll in: {rem:mm\\:ss}"
                        : "Polling...";
                }
            };
            _afbCountdown.Start();

            btnStartAutoFollowBack.Enabled = false;
            btnStopAutoFollowBack.Enabled = true;
            lblAFBStatus.Text = $"Running — polling every {mins} min.";
        }

        private void btnStopAutoFollowBack_Click(object sender, EventArgs e)
        {
            _autoFollowBack?.Stop();
            _afbCountdown?.Stop();
            _afbCountdown?.Dispose();
            _afbCountdown = null;
            lblAFBCountdown.Text = "";
            btnStartAutoFollowBack.Enabled = true;
            btnStopAutoFollowBack.Enabled = false;
            lblAFBStatus.Text = "Stopped.";
        }

        private async void btnRunAFBNow_Click(object sender, EventArgs e)
        {
            btnRunAFBNow.Enabled = false;
            lblAFBStatus.Text = "Checking now...";
            try
            {
                var newOnes = await _social.GetNewFollowersNotFollowedBackAsync();
                lstAFBLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] Found {newOnes.Count} to follow back.");
                foreach (var u in newOnes)
                {
                    try
                    {
                        await _social.FollowAsync(u.Login);
                        _tracker?.Record(u.Login);
                        lstAFBLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] Followed back: {u.Login}");
                        await Task.Delay(1500);
                    }
                    catch (Exception ex) { lstAFBLog.Items.Insert(0, $"Failed: {u.Login} — {ex.Message}"); }
                }
                lblAFBStatus.Text = $"Done. Followed back {newOnes.Count} users.";
            }
            catch (Exception ex) { lblAFBStatus.Text = $"Error: {ex.Message}"; }
            btnRunAFBNow.Enabled = true;
        }

        // ================================================================
        // Star-Back tab
        // ================================================================
        private List<(string Owner, string Repo, int Stars, string Url)> _starCandidates = new();
        private CancellationTokenSource _starScanCts;

        private async void btnLoadStarCandidates_Click(object sender, EventArgs e)
        {
            btnLoadStarCandidates.Enabled = false;
            btnCancelStarScan.Enabled = true;
            dgvStarBack.Rows.Clear();
            lblStarBackStatus.Text = "Loading your starred repos for dedup...";

            _starScanCts = new CancellationTokenSource();
            var ct = _starScanCts.Token;

            try
            {
                var myStarred = await _social.GetMyStarredReposAsync();
                var alreadyStarred = myStarred
                    .Select(r => $"{r.Owner.Login}/{r.Name}")
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                lblStarBackStatus.Text = "Loading followers...";
                var followers = await _social.GetFollowersAsync();
                int minStars = (int)numMinStarsForStar.Value;
                int maxFollowers = (int)numFollowersToScan.Value;
                var toScan = followers.Take(maxFollowers).ToList();

                _starCandidates.Clear();
                int scanned = 0;

                foreach (var follower in toScan)
                {
                    ct.ThrowIfCancellationRequested();
                    lblStarBackStatus.Text = $"Scanning {follower.Login} ({++scanned}/{toScan.Count})...";
                    try
                    {
                        // maxPages=1 caps at top 100 repos by stars — prevents 5k-repo accounts freezing the scan
                        var repos = await _social.GetReposForUserAsync(follower.Login, maxPages: 1);
                        foreach (var r in repos.Where(r =>
                            r.StargazersCount >= minStars &&
                            !r.Archived &&
                            !alreadyStarred.Contains($"{r.Owner.Login}/{r.Name}")))
                        {
                            _starCandidates.Add((r.Owner.Login, r.Name, r.StargazersCount, r.HtmlUrl));
                            alreadyStarred.Add($"{r.Owner.Login}/{r.Name}");
                        }
                    }
                    catch { /* skip inaccessible */ }
                    await Task.Delay(300, ct);
                }

                foreach (var (owner, repo, stars, url) in _starCandidates.OrderByDescending(c => c.Stars))
                    dgvStarBack.Rows.Add(false, $"{owner}/{repo}", stars, url);

                lblStarBackStatus.Text = $"Found {_starCandidates.Count} unstarred repos from {scanned} followers.";
            }
            catch (OperationCanceledException)
            {
                lblStarBackStatus.Text = $"Scan cancelled. {_starCandidates.Count} candidates found so far.";
                foreach (var (owner, repo, stars, url) in _starCandidates.OrderByDescending(c => c.Stars))
                    dgvStarBack.Rows.Add(false, $"{owner}/{repo}", stars, url);
            }
            catch (Exception ex) { lblStarBackStatus.Text = $"Error: {ex.Message}"; }

            btnLoadStarCandidates.Enabled = true;
            btnCancelStarScan.Enabled = false;
        }

        private void btnSelectAllStars_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.DataGridViewRow row in dgvStarBack.Rows)
                row.Cells[0].Value = true;
        }

        private void btnCancelStarScan_Click(object sender, EventArgs e)
        {
            _starScanCts?.Cancel();
            btnCancelStarScan.Enabled = false;
        }

        private async void btnStarSelected_Click(object sender, EventArgs e)
        {
            var toStar = dgvStarBack.Rows.Cast<System.Windows.Forms.DataGridViewRow>()
                .Where(r => r.Cells[0].Value is true)
                .Select(r => r.Cells[1].Value?.ToString())
                .Where(v => v != null)
                .ToList();

            if (toStar.Count == 0) { MessageBox.Show("Check rows to star first."); return; }
            btnStarSelected.Enabled = false;

            foreach (var fullName in toStar)
            {
                var parts = fullName!.Split('/');
                if (parts.Length != 2) continue;
                try
                {
                    await _social.StarRepoAsync(parts[0], parts[1]);
                    lstStarBackLog.Items.Insert(0, $"⭐ Starred {fullName}");
                    await Task.Delay(800);
                }
                catch (Exception ex) { lstStarBackLog.Items.Insert(0, $"✘ {fullName}: {ex.Message}"); }
            }

            btnStarSelected.Enabled = true;
            lblStarBackStatus.Text = $"Starred {toStar.Count} repos.";
        }

        private void btnOpenStarUrl_Click(object sender, EventArgs e)
        {
            if (dgvStarBack.CurrentRow == null) return;
            var url = dgvStarBack.CurrentRow.Cells[3].Value?.ToString();
            if (!string.IsNullOrEmpty(url))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }

        // ================================================================
        // Repo Health tab
        // ================================================================
        private async void btnScanRepos_Click(object sender, EventArgs e)
        {
            btnScanRepos.Enabled = false;
            dgvRepoHealth.Rows.Clear();
            lblRepoHealthStatus.Text = "Loading repos...";

            try
            {
                var repos = await _social.GetMyReposAsync();
                lblRepoHealthStatus.Text = $"Checking {repos.Count} repos...";
                int done = 0;

                foreach (var repo in repos.OrderByDescending(r => r.StargazersCount))
                {
                    bool hasReadme = await _social.HasReadmeAsync(repo.Owner.Login, repo.Name);
                    var topics = await _social.GetTopicsAsync(repo.Owner.Login, repo.Name);
                    bool hasDesc = !string.IsNullOrEmpty(repo.Description);
                    bool hasTopics = topics.Count > 0;
                    bool hasUrl = !string.IsNullOrEmpty(repo.Homepage);
                    bool stale = repo.PushedAt < DateTimeOffset.UtcNow.AddMonths(-6);

                    string health = (hasReadme && hasDesc && hasTopics) ? "✔ Good"
                                  : (!hasReadme || !hasDesc) ? "✘ Poor"
                                  : "⚠ Okay";

                    dgvRepoHealth.Rows.Add(
                        repo.Name,
                        repo.StargazersCount,
                        hasReadme ? "✔" : "✘",
                        hasDesc ? "✔" : "✘",
                        hasTopics ? string.Join(", ", topics.Take(3)) : "✘ none",
                        hasUrl ? "✔" : "✘",
                        stale ? "⚠ Stale" : "Active",
                        health,
                        repo.HtmlUrl
                    );

                    lblRepoHealthStatus.Text = $"Checked {++done}/{repos.Count}...";
                    await Task.Delay(200);
                }

                lblRepoHealthStatus.Text = $"Done. {repos.Count} repos scanned.";
                ColorRepoHealthRows();
            }
            catch (Exception ex) { lblRepoHealthStatus.Text = $"Error: {ex.Message}"; }

            btnScanRepos.Enabled = true;
        }

        private void ColorRepoHealthRows()
        {
            foreach (System.Windows.Forms.DataGridViewRow row in dgvRepoHealth.Rows)
            {
                var health = row.Cells[7].Value?.ToString() ?? "";
                row.DefaultCellStyle.BackColor = health.StartsWith("✔") ? System.Drawing.Color.FromArgb(220, 255, 220)
                                               : health.StartsWith("✘") ? System.Drawing.Color.FromArgb(255, 220, 220)
                                               : System.Drawing.Color.FromArgb(255, 245, 200);
            }
        }

        private void btnOpenRepoUrl_Click(object sender, EventArgs e)
        {
            if (dgvRepoHealth.CurrentRow == null) return;
            var url = dgvRepoHealth.CurrentRow.Cells[8].Value?.ToString();
            if (!string.IsNullOrEmpty(url))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }

        private async void btnQuickFixTopics_Click(object sender, EventArgs e)
        {
            if (dgvRepoHealth.CurrentRow == null) return;
            var repoName = dgvRepoHealth.CurrentRow.Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(repoName)) return;

            string input;
            using (var dlg = new System.Windows.Forms.Form { Width = 420, Height = 140, Text = $"Set topics for {repoName}", StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen, FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog })
            {
                var txt = new System.Windows.Forms.TextBox { Left = 10, Top = 10, Width = 380, Text = "" };
                var lbl = new System.Windows.Forms.Label { Left = 10, Top = 38, Width = 380, Text = "Enter topics comma-separated (lowercase, hyphens ok):" };
                var btn = new System.Windows.Forms.Button { Left = 290, Top = 65, Width = 100, Text = "OK", DialogResult = System.Windows.Forms.DialogResult.OK };
                dlg.Controls.AddRange(new System.Windows.Forms.Control[] { txt, lbl, btn });
                dlg.AcceptButton = btn;
                input = dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK ? txt.Text : "";
            }
            if (string.IsNullOrWhiteSpace(input)) return;

            var topics = input.Split(',').Select(t => t.Trim().ToLower().Replace(" ", "-"))
                              .Where(t => !string.IsNullOrEmpty(t)).ToArray();
            try
            {
                await _social.SetTopicsAsync(_username, repoName, topics);
                dgvRepoHealth.CurrentRow.Cells[4].Value = string.Join(", ", topics.Take(3));
                MessageBox.Show($"Topics updated for {repoName}.");
            }
            catch (Exception ex) { MessageBox.Show($"Failed: {ex.Message}"); }
        }

        // ================================================================
        // Profile Preview tab
        // ================================================================
        private System.Windows.Forms.Timer _profileRefreshTimer;
        private System.Windows.Forms.Timer _profileCountdownTimer;
        private DateTime _nextProfileRefresh;
        private readonly System.Windows.Forms.Label lblProfileCountdown = new System.Windows.Forms.Label
        {
            Left = 10,
            Top = 40,
            Width = 300,
            Text = "",
            Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)
        };

        private void tabProfile_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(webProfile.Url?.ToString()))
                NavigateProfile();
        }

        private void NavigateProfile()
        {
            webProfile.Navigate($"https://github.com/{_username}");
            lblProfileStatus.Text = $"Viewing: github.com/{_username}";
        }

        private void btnRefreshProfile_Click(object sender, EventArgs e) => NavigateProfile();

        private void btnOpenProfileBrowser_Click(object sender, EventArgs e)
        {
            var url = $"https://github.com/{_username}";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnStartProfileAutoRefresh_Click(object sender, EventArgs e)
        {
            int secs = (int)numProfileRefreshInterval.Value;

            int refreshCount = 0;
            _profileRefreshTimer = new System.Windows.Forms.Timer { Interval = secs * 1000 };
            _profileRefreshTimer.Tick += (s, args) =>
            {
                NavigateProfile();
                refreshCount++;
                _nextProfileRefresh = DateTime.Now.AddSeconds(secs);
                lblProfileStatus.Text = $"Auto-refreshing every {secs}s — {refreshCount} refresh{(refreshCount == 1 ? "" : "es")} so far.";
            };

            var countdownLabel = this.lblProfileCountdown;
            var statusLabel = this.lblProfileStatus;

            _profileCountdownTimer = new System.Windows.Forms.Timer { Interval = 50 };
            _profileCountdownTimer.Tick += (s, args) =>
            {
                var remaining = _nextProfileRefresh - DateTime.Now;
                countdownLabel.Text = remaining > TimeSpan.Zero
                    ? $"Next refresh in: {remaining.TotalSeconds:0.0}s  |  Total refreshes: {refreshCount}"
                    : $"Refreshing...  |  Total refreshes: {refreshCount}";
            };

            _nextProfileRefresh = DateTime.Now.AddSeconds(secs);
            _profileRefreshTimer.Start();
            _profileCountdownTimer.Start();

            btnStartProfileAutoRefresh.Enabled = false;
            btnStopProfileAutoRefresh.Enabled = true;
            lblProfileStatus.Text = $"Auto-refreshing every {secs}s.";
        }

        private void btnStopProfileAutoRefresh_Click(object sender, EventArgs e)
        {
            _profileRefreshTimer?.Stop();
            _profileRefreshTimer?.Dispose();
            _profileRefreshTimer = null;
            _profileCountdownTimer?.Stop();
            _profileCountdownTimer?.Dispose();
            _profileCountdownTimer = null;
            this.lblProfileCountdown.Text = "";
            btnStartProfileAutoRefresh.Enabled = true;
            btnStopProfileAutoRefresh.Enabled = false;
            lblProfileStatus.Text = "Auto-refresh stopped.";
        }

        // ================================================================
        // Achievements tab
        // ================================================================
        private AchievementChecker _achievementChecker;
        private List<Achievement> _lastAchievements = new();

        private async void btnCheckAchievements_Click(object sender, EventArgs e)
        {
            btnCheckAchievements.Enabled = false;
            dgvAchievements.Rows.Clear();
            _lastAchievements.Clear();

            _achievementChecker = new AchievementChecker(
                TokenStorage.Load() ?? "", _username);

            var progress = new Progress<string>(msg => lblAchievementStatus.Text = msg);

            try
            {
                _lastAchievements = await _achievementChecker.CheckAllAsync(progress);

                foreach (var a in _lastAchievements)
                {
                    string statusIcon = a.Status switch
                    {
                        AchievementStatus.Unlocked => "✔ Unlocked",
                        AchievementStatus.InProgress => "⏳ In Progress",
                        _ => "🔒 Locked"
                    };

                    string progressText = a.NextGoal > 0
                        ? $"{a.Progress} / {a.NextGoal}"
                        : $"{a.Progress}";

                    int rowIdx = dgvAchievements.Rows.Add(
                        a.Name,
                        statusIcon,
                        a.CurrentTier,
                        progressText,
                        a.NextGoal.ToString(),
                        a.Description,
                        a.Note
                    );

                    var row = dgvAchievements.Rows[rowIdx];
                    row.DefaultCellStyle.BackColor = a.Status switch
                    {
                        AchievementStatus.Unlocked => System.Drawing.Color.FromArgb(220, 255, 220),
                        AchievementStatus.InProgress => System.Drawing.Color.FromArgb(255, 245, 200),
                        _ => System.Drawing.Color.FromArgb(240, 240, 240)
                    };
                }

                int unlocked = _lastAchievements.Count(a => a.Status == AchievementStatus.Unlocked);
                int inProgress = _lastAchievements.Count(a => a.Status == AchievementStatus.InProgress);
                lblAchievementStatus.Text = $"✔ {unlocked} unlocked  ⏳ {inProgress} in progress  🔒 {_lastAchievements.Count - unlocked - inProgress} locked";
            }
            catch (Exception ex)
            {
                lblAchievementStatus.Text = $"Error: {ex.Message}";
            }

            btnCheckAchievements.Enabled = true;
        }

        private void btnOpenAchievementUrl_Click(object sender, EventArgs e)
        {
            if (dgvAchievements.CurrentRow == null) return;
            int idx = dgvAchievements.CurrentRow.Index;
            if (idx < 0 || idx >= _lastAchievements.Count) return;
            var url = _lastAchievements[idx].ApiUrl;
            if (!string.IsNullOrEmpty(url))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnHowToUnlock_Click(object sender, EventArgs e)
        {
            if (dgvAchievements.CurrentRow == null) return;
            int idx = dgvAchievements.CurrentRow.Index;
            if (idx < 0 || idx >= _lastAchievements.Count) return;
            var a = _lastAchievements[idx];
            MessageBox.Show($"{a.Name}\n\n{a.HowTo}\n\nTiers:\n" +
                string.Join("\n", a.Tiers.Select(t => $"  {t.BadgeEmoji} {t.Label}: {t.Threshold}")),
                "How to Unlock", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}