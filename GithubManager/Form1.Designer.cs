using System.Drawing;

namespace GithubManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabOverview = new TabPage();
            lblStatus = new Label();
            lblFollowers = new Label();
            lblFollowing = new Label();
            lblRateLimit = new Label();
            btnRefreshOverview = new Button();
            btnChangeToken = new Button();
            tabDiff = new TabPage();
            btnLoadDiff = new Button();
            lblDiffStatus = new Label();
            lvNotFollowingBack = new ListView();
            btnSelectAllNotFollowingBack = new Button();
            btnUnfollowSelected = new Button();
            btnAddToKeep = new Button();
            lvNotFollowedYet = new ListView();
            btnSelectAllNotFollowedYet = new Button();
            btnFollowSelected = new Button();
            btnCancelBulk = new Button();
            lblKeepListHeader = new Label();
            lvKeepList = new ListView();
            btnRemoveFromKeep = new Button();
            btnAddToNeverFollow = new Button();
            lblNeverFollowHeader = new Label();
            lvNeverFollow = new ListView();
            btnRemoveFromNeverFollow = new Button();
            btnImportNeverFollow = new Button();
            lstLog = new ListBox();
            tabCrawler = new TabPage();
            lblTargetUser = new Label();
            txtTargetUser = new TextBox();
            btnValidateTarget = new Button();
            btnPullCandidates = new Button();
            rbSourceFollowers = new RadioButton();
            rbSourceFollowing = new RadioButton();
            chkQualityFilter = new CheckBox();
            lblMinRepos = new Label();
            numMinRepos = new NumericUpDown();
            lblMaxRatio = new Label();
            numMaxRatio = new NumericUpDown();
            lblQueueTarget = new Label();
            numQueueTarget = new NumericUpDown();
            lblCandidates = new Label();
            txtCandidates = new TextBox();
            picTargetAvatar = new PictureBox();
            lblTargetName = new Label();
            lblTargetFollowers = new Label();
            lblTargetFollowing = new Label();
            lblTargetRepos = new Label();
            lnkTargetProfile = new LinkLabel();
            lblTargetAssessment = new Label();
            lblDailyCap = new Label();
            numDailyCap = new NumericUpDown();
            lblMinInterval = new Label();
            numMinInterval = new NumericUpDown();
            lblMaxInterval = new Label();
            numMaxInterval = new NumericUpDown();
            btnStartCrawler = new Button();
            btnStopCrawler = new Button();
            lblCrawlerStatus = new Label();
            lblNextFollowCountdown = new Label();
            btnExportCandidates = new Button();
            btnExportFollowLog = new Button();
            lstCrawlerLog = new ListBox();
            tabAFB = new TabPage();
            lblAFBInterval = new Label();
            numAFBInterval = new NumericUpDown();
            btnStartAutoFollowBack = new Button();
            btnStopAutoFollowBack = new Button();
            btnRunAFBNow = new Button();
            lblAFBStatus = new Label();
            lblAFBCountdown = new Label();
            lstAFBLog = new ListBox();
            tabStarBack = new TabPage();
            lblFollowersToScan = new Label();
            numFollowersToScan = new NumericUpDown();
            lblMinStarsForStar = new Label();
            numMinStarsForStar = new NumericUpDown();
            btnLoadStarCandidates = new Button();
            btnCancelStarScan = new Button();
            btnSelectAllStars = new Button();
            btnStarSelected = new Button();
            btnOpenStarUrl = new Button();
            lblStarBackStatus = new Label();
            dgvStarBack = new DataGridView();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            lstStarBackLog = new ListBox();
            tabRepoHealth = new TabPage();
            btnScanRepos = new Button();
            btnOpenRepoUrl = new Button();
            btnQuickFixTopics = new Button();
            lblRepoHealthStatus = new Label();
            dgvRepoHealth = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            tabProfile = new TabPage();
            btnRefreshProfile = new Button();
            btnOpenProfileBrowser = new Button();
            lblProfileRefreshInterval = new Label();
            numProfileRefreshInterval = new NumericUpDown();
            btnStartProfileAutoRefresh = new Button();
            btnStopProfileAutoRefresh = new Button();
            lblProfileStatus = new Label();
            webProfile = new WebBrowser();
            tabAchievements = new TabPage();
            btnCheckAchievements = new Button();
            lblAchievementStatus = new Label();
            dgvAchievements = new DataGridView();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
            btnOpenAchievementUrl = new Button();
            btnHowToUnlock = new Button();
            tabControl1.SuspendLayout();
            tabOverview.SuspendLayout();
            tabDiff.SuspendLayout();
            tabCrawler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMinRepos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxRatio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQueueTarget).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTargetAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDailyCap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxInterval).BeginInit();
            tabAFB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAFBInterval).BeginInit();
            tabStarBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFollowersToScan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinStarsForStar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStarBack).BeginInit();
            tabRepoHealth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepoHealth).BeginInit();
            tabProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numProfileRefreshInterval).BeginInit();
            tabAchievements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAchievements).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabOverview);
            tabControl1.Controls.Add(tabDiff);
            tabControl1.Controls.Add(tabCrawler);
            tabControl1.Controls.Add(tabAFB);
            tabControl1.Controls.Add(tabStarBack);
            tabControl1.Controls.Add(tabRepoHealth);
            tabControl1.Controls.Add(tabProfile);
            tabControl1.Controls.Add(tabAchievements);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 700);
            tabControl1.TabIndex = 0;
            // 
            // tabOverview
            // 
            tabOverview.Controls.Add(lblStatus);
            tabOverview.Controls.Add(lblFollowers);
            tabOverview.Controls.Add(lblFollowing);
            tabOverview.Controls.Add(lblRateLimit);
            tabOverview.Controls.Add(btnRefreshOverview);
            tabOverview.Controls.Add(btnChangeToken);
            tabOverview.Location = new Point(4, 24);
            tabOverview.Name = "tabOverview";
            tabOverview.Size = new Size(792, 672);
            tabOverview.TabIndex = 0;
            tabOverview.Text = "Overview";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(10, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(500, 23);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Not logged in";
            // 
            // lblFollowers
            // 
            lblFollowers.Location = new Point(10, 38);
            lblFollowers.Name = "lblFollowers";
            lblFollowers.Size = new Size(200, 23);
            lblFollowers.TabIndex = 1;
            lblFollowers.Text = "Followers: -";
            // 
            // lblFollowing
            // 
            lblFollowing.Location = new Point(10, 60);
            lblFollowing.Name = "lblFollowing";
            lblFollowing.Size = new Size(200, 23);
            lblFollowing.TabIndex = 2;
            lblFollowing.Text = "Following: -";
            // 
            // lblRateLimit
            // 
            lblRateLimit.Location = new Point(10, 82);
            lblRateLimit.Name = "lblRateLimit";
            lblRateLimit.Size = new Size(300, 23);
            lblRateLimit.TabIndex = 3;
            lblRateLimit.Text = "API calls remaining: -";
            // 
            // btnRefreshOverview
            // 
            btnRefreshOverview.Location = new Point(10, 110);
            btnRefreshOverview.Name = "btnRefreshOverview";
            btnRefreshOverview.Size = new Size(120, 23);
            btnRefreshOverview.TabIndex = 4;
            btnRefreshOverview.Text = "Refresh";
            btnRefreshOverview.Click += btnRefreshOverview_Click;
            // 
            // btnChangeToken
            // 
            btnChangeToken.Location = new Point(140, 110);
            btnChangeToken.Name = "btnChangeToken";
            btnChangeToken.Size = new Size(130, 23);
            btnChangeToken.TabIndex = 5;
            btnChangeToken.Text = "Change Token";
            btnChangeToken.Click += btnChangeToken_Click;
            // 
            // tabDiff
            // 
            tabDiff.Controls.Add(btnLoadDiff);
            tabDiff.Controls.Add(lblDiffStatus);
            tabDiff.Controls.Add(lvNotFollowingBack);
            tabDiff.Controls.Add(btnSelectAllNotFollowingBack);
            tabDiff.Controls.Add(btnUnfollowSelected);
            tabDiff.Controls.Add(btnAddToKeep);
            tabDiff.Controls.Add(lvNotFollowedYet);
            tabDiff.Controls.Add(btnSelectAllNotFollowedYet);
            tabDiff.Controls.Add(btnFollowSelected);
            tabDiff.Controls.Add(btnCancelBulk);
            tabDiff.Controls.Add(lblKeepListHeader);
            tabDiff.Controls.Add(lvKeepList);
            tabDiff.Controls.Add(btnRemoveFromKeep);
            tabDiff.Controls.Add(btnAddToNeverFollow);
            tabDiff.Controls.Add(lblNeverFollowHeader);
            tabDiff.Controls.Add(lvNeverFollow);
            tabDiff.Controls.Add(btnRemoveFromNeverFollow);
            tabDiff.Controls.Add(btnImportNeverFollow);
            tabDiff.Controls.Add(lstLog);
            tabDiff.Location = new Point(4, 24);
            tabDiff.Name = "tabDiff";
            tabDiff.Size = new Size(792, 672);
            tabDiff.TabIndex = 1;
            tabDiff.Text = "Follow Diff";
            // 
            // btnLoadDiff
            // 
            btnLoadDiff.Location = new Point(10, 10);
            btnLoadDiff.Name = "btnLoadDiff";
            btnLoadDiff.Size = new Size(120, 23);
            btnLoadDiff.TabIndex = 0;
            btnLoadDiff.Text = "Load Diff";
            btnLoadDiff.Click += btnLoadDiff_Click;
            // 
            // lblDiffStatus
            // 
            lblDiffStatus.Location = new Point(140, 15);
            lblDiffStatus.Name = "lblDiffStatus";
            lblDiffStatus.Size = new Size(640, 23);
            lblDiffStatus.TabIndex = 1;
            // 
            // lvNotFollowingBack
            // 
            lvNotFollowingBack.CheckBoxes = true;
            lvNotFollowingBack.FullRowSelect = true;
            lvNotFollowingBack.Location = new Point(10, 42);
            lvNotFollowingBack.Name = "lvNotFollowingBack";
            lvNotFollowingBack.Size = new Size(370, 240);
            lvNotFollowingBack.TabIndex = 2;
            lvNotFollowingBack.UseCompatibleStateImageBehavior = false;
            lvNotFollowingBack.View = View.Details;
            // 
            // btnSelectAllNotFollowingBack
            // 
            btnSelectAllNotFollowingBack.Location = new Point(10, 288);
            btnSelectAllNotFollowingBack.Name = "btnSelectAllNotFollowingBack";
            btnSelectAllNotFollowingBack.Size = new Size(100, 23);
            btnSelectAllNotFollowingBack.TabIndex = 3;
            btnSelectAllNotFollowingBack.Text = "Select All";
            btnSelectAllNotFollowingBack.Click += btnSelectAllNotFollowingBack_Click;
            // 
            // btnUnfollowSelected
            // 
            btnUnfollowSelected.Location = new Point(118, 288);
            btnUnfollowSelected.Name = "btnUnfollowSelected";
            btnUnfollowSelected.Size = new Size(130, 23);
            btnUnfollowSelected.TabIndex = 4;
            btnUnfollowSelected.Text = "Unfollow Selected";
            btnUnfollowSelected.Click += btnUnfollowSelected_Click;
            // 
            // btnAddToKeep
            // 
            btnAddToKeep.Location = new Point(256, 288);
            btnAddToKeep.Name = "btnAddToKeep";
            btnAddToKeep.Size = new Size(120, 23);
            btnAddToKeep.TabIndex = 5;
            btnAddToKeep.Text = "→ Keep List";
            btnAddToKeep.Click += btnAddToKeep_Click;
            // 
            // lvNotFollowedYet
            // 
            lvNotFollowedYet.CheckBoxes = true;
            lvNotFollowedYet.FullRowSelect = true;
            lvNotFollowedYet.Location = new Point(395, 42);
            lvNotFollowedYet.Name = "lvNotFollowedYet";
            lvNotFollowedYet.Size = new Size(385, 240);
            lvNotFollowedYet.TabIndex = 6;
            lvNotFollowedYet.UseCompatibleStateImageBehavior = false;
            lvNotFollowedYet.View = View.Details;
            // 
            // btnSelectAllNotFollowedYet
            // 
            btnSelectAllNotFollowedYet.Location = new Point(395, 288);
            btnSelectAllNotFollowedYet.Name = "btnSelectAllNotFollowedYet";
            btnSelectAllNotFollowedYet.Size = new Size(100, 23);
            btnSelectAllNotFollowedYet.TabIndex = 7;
            btnSelectAllNotFollowedYet.Text = "Select All";
            btnSelectAllNotFollowedYet.Click += btnSelectAllNotFollowedYet_Click;
            // 
            // btnFollowSelected
            // 
            btnFollowSelected.Location = new Point(503, 288);
            btnFollowSelected.Name = "btnFollowSelected";
            btnFollowSelected.Size = new Size(140, 23);
            btnFollowSelected.TabIndex = 8;
            btnFollowSelected.Text = "Follow Selected";
            btnFollowSelected.Click += btnFollowSelected_Click;
            // 
            // btnCancelBulk
            // 
            btnCancelBulk.Location = new Point(651, 288);
            btnCancelBulk.Name = "btnCancelBulk";
            btnCancelBulk.Size = new Size(80, 23);
            btnCancelBulk.TabIndex = 9;
            btnCancelBulk.Text = "Cancel";
            btnCancelBulk.Click += btnCancelBulk_Click;
            // 
            // lblKeepListHeader
            // 
            lblKeepListHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKeepListHeader.Location = new Point(10, 344);
            lblKeepListHeader.Name = "lblKeepListHeader";
            lblKeepListHeader.Size = new Size(350, 23);
            lblKeepListHeader.TabIndex = 10;
            lblKeepListHeader.Text = "Keep List (always excluded from unfollow):";
            // 
            // lvKeepList
            // 
            lvKeepList.FullRowSelect = true;
            lvKeepList.Location = new Point(10, 370);
            lvKeepList.Name = "lvKeepList";
            lvKeepList.Size = new Size(580, 120);
            lvKeepList.TabIndex = 11;
            lvKeepList.UseCompatibleStateImageBehavior = false;
            lvKeepList.View = View.Details;
            // 
            // btnRemoveFromKeep
            // 
            btnRemoveFromKeep.Location = new Point(596, 405);
            btnRemoveFromKeep.Name = "btnRemoveFromKeep";
            btnRemoveFromKeep.Size = new Size(180, 40);
            btnRemoveFromKeep.TabIndex = 12;
            btnRemoveFromKeep.Text = "Remove from Keep List";
            btnRemoveFromKeep.Click += btnRemoveFromKeep_Click;
            // 
            // btnAddToNeverFollow
            // 
            btnAddToNeverFollow.BackColor = Color.FromArgb(255, 220, 220);
            btnAddToNeverFollow.Location = new Point(118, 314);
            btnAddToNeverFollow.Name = "btnAddToNeverFollow";
            btnAddToNeverFollow.Size = new Size(130, 23);
            btnAddToNeverFollow.TabIndex = 13;
            btnAddToNeverFollow.Text = "→ Never Follow";
            btnAddToNeverFollow.UseVisualStyleBackColor = false;
            btnAddToNeverFollow.Click += btnAddToNeverFollow_Click;
            // 
            // lblNeverFollowHeader
            // 
            lblNeverFollowHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNeverFollowHeader.ForeColor = Color.Firebrick;
            lblNeverFollowHeader.Location = new Point(10, 493);
            lblNeverFollowHeader.Name = "lblNeverFollowHeader";
            lblNeverFollowHeader.Size = new Size(350, 23);
            lblNeverFollowHeader.TabIndex = 14;
            lblNeverFollowHeader.Text = "Never Follow List (crawler always skips these):";
            // 
            // lvNeverFollow
            // 
            lvNeverFollow.FullRowSelect = true;
            lvNeverFollow.Location = new Point(14, 519);
            lvNeverFollow.Name = "lvNeverFollow";
            lvNeverFollow.Size = new Size(580, 90);
            lvNeverFollow.TabIndex = 15;
            lvNeverFollow.UseCompatibleStateImageBehavior = false;
            lvNeverFollow.View = View.Details;
            // 
            // btnRemoveFromNeverFollow
            // 
            btnRemoveFromNeverFollow.Location = new Point(600, 519);
            btnRemoveFromNeverFollow.Name = "btnRemoveFromNeverFollow";
            btnRemoveFromNeverFollow.Size = new Size(170, 35);
            btnRemoveFromNeverFollow.TabIndex = 16;
            btnRemoveFromNeverFollow.Text = "Remove from Never Follow";
            btnRemoveFromNeverFollow.Click += btnRemoveFromNeverFollow_Click;
            // 
            // btnImportNeverFollow
            // 
            btnImportNeverFollow.Location = new Point(600, 574);
            btnImportNeverFollow.Name = "btnImportNeverFollow";
            btnImportNeverFollow.Size = new Size(170, 35);
            btnImportNeverFollow.TabIndex = 17;
            btnImportNeverFollow.Text = "Import from .txt";
            btnImportNeverFollow.Click += btnImportNeverFollow_Click;
            // 
            // lstLog
            // 
            lstLog.Location = new Point(10, 615);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(770, 49);
            lstLog.TabIndex = 18;
            // 
            // tabCrawler
            // 
            tabCrawler.Controls.Add(lblTargetUser);
            tabCrawler.Controls.Add(txtTargetUser);
            tabCrawler.Controls.Add(btnValidateTarget);
            tabCrawler.Controls.Add(btnPullCandidates);
            tabCrawler.Controls.Add(rbSourceFollowers);
            tabCrawler.Controls.Add(rbSourceFollowing);
            tabCrawler.Controls.Add(chkQualityFilter);
            tabCrawler.Controls.Add(lblMinRepos);
            tabCrawler.Controls.Add(numMinRepos);
            tabCrawler.Controls.Add(lblMaxRatio);
            tabCrawler.Controls.Add(numMaxRatio);
            tabCrawler.Controls.Add(lblQueueTarget);
            tabCrawler.Controls.Add(numQueueTarget);
            tabCrawler.Controls.Add(lblCandidates);
            tabCrawler.Controls.Add(txtCandidates);
            tabCrawler.Controls.Add(picTargetAvatar);
            tabCrawler.Controls.Add(lblTargetName);
            tabCrawler.Controls.Add(lblTargetFollowers);
            tabCrawler.Controls.Add(lblTargetFollowing);
            tabCrawler.Controls.Add(lblTargetRepos);
            tabCrawler.Controls.Add(lnkTargetProfile);
            tabCrawler.Controls.Add(lblTargetAssessment);
            tabCrawler.Controls.Add(lblDailyCap);
            tabCrawler.Controls.Add(numDailyCap);
            tabCrawler.Controls.Add(lblMinInterval);
            tabCrawler.Controls.Add(numMinInterval);
            tabCrawler.Controls.Add(lblMaxInterval);
            tabCrawler.Controls.Add(numMaxInterval);
            tabCrawler.Controls.Add(btnStartCrawler);
            tabCrawler.Controls.Add(btnStopCrawler);
            tabCrawler.Controls.Add(lblCrawlerStatus);
            tabCrawler.Controls.Add(lblNextFollowCountdown);
            tabCrawler.Controls.Add(btnExportCandidates);
            tabCrawler.Controls.Add(btnExportFollowLog);
            tabCrawler.Controls.Add(lstCrawlerLog);
            tabCrawler.Location = new Point(4, 24);
            tabCrawler.Name = "tabCrawler";
            tabCrawler.Size = new Size(792, 672);
            tabCrawler.TabIndex = 2;
            tabCrawler.Text = "Crawler";
            // 
            // lblTargetUser
            // 
            lblTargetUser.Location = new Point(8, 2);
            lblTargetUser.Name = "lblTargetUser";
            lblTargetUser.Size = new Size(185, 23);
            lblTargetUser.TabIndex = 0;
            lblTargetUser.Text = "Pull candidates from user:";
            // 
            // txtTargetUser
            // 
            txtTargetUser.Location = new Point(8, 28);
            txtTargetUser.Name = "txtTargetUser";
            txtTargetUser.Size = new Size(180, 23);
            txtTargetUser.TabIndex = 1;
            // 
            // btnValidateTarget
            // 
            btnValidateTarget.Location = new Point(198, 28);
            btnValidateTarget.Name = "btnValidateTarget";
            btnValidateTarget.Size = new Size(65, 23);
            btnValidateTarget.TabIndex = 2;
            btnValidateTarget.Text = "Validate";
            btnValidateTarget.Click += btnValidateTarget_Click;
            // 
            // btnPullCandidates
            // 
            btnPullCandidates.Location = new Point(270, 28);
            btnPullCandidates.Name = "btnPullCandidates";
            btnPullCandidates.Size = new Size(55, 23);
            btnPullCandidates.TabIndex = 3;
            btnPullCandidates.Text = "Pull";
            btnPullCandidates.Click += btnPullCandidates_Click;
            // 
            // rbSourceFollowers
            // 
            rbSourceFollowers.Checked = true;
            rbSourceFollowers.Location = new Point(10, 56);
            rbSourceFollowers.Name = "rbSourceFollowers";
            rbSourceFollowers.Size = new Size(145, 24);
            rbSourceFollowers.TabIndex = 4;
            rbSourceFollowers.TabStop = true;
            rbSourceFollowers.Text = "Their followers";
            // 
            // rbSourceFollowing
            // 
            rbSourceFollowing.Location = new Point(158, 56);
            rbSourceFollowing.Name = "rbSourceFollowing";
            rbSourceFollowing.Size = new Size(145, 24);
            rbSourceFollowing.TabIndex = 5;
            rbSourceFollowing.Text = "Who they follow";
            // 
            // chkQualityFilter
            // 
            chkQualityFilter.Location = new Point(10, 78);
            chkQualityFilter.Name = "chkQualityFilter";
            chkQualityFilter.Size = new Size(310, 24);
            chkQualityFilter.TabIndex = 6;
            chkQualityFilter.Text = "Apply quality filter (1 extra API call/candidate)";
            // 
            // lblMinRepos
            // 
            lblMinRepos.Location = new Point(10, 108);
            lblMinRepos.Name = "lblMinRepos";
            lblMinRepos.Size = new Size(110, 23);
            lblMinRepos.TabIndex = 7;
            lblMinRepos.Text = "Min public repos:";
            // 
            // numMinRepos
            // 
            numMinRepos.Location = new Point(148, 102);
            numMinRepos.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMinRepos.Name = "numMinRepos";
            numMinRepos.Size = new Size(70, 23);
            numMinRepos.TabIndex = 8;
            numMinRepos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMaxRatio
            // 
            lblMaxRatio.Location = new Point(12, 133);
            lblMaxRatio.Name = "lblMaxRatio";
            lblMaxRatio.Size = new Size(110, 23);
            lblMaxRatio.TabIndex = 9;
            lblMaxRatio.Text = "Max follow ratio:";
            // 
            // numMaxRatio
            // 
            numMaxRatio.Location = new Point(148, 131);
            numMaxRatio.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMaxRatio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxRatio.Name = "numMaxRatio";
            numMaxRatio.Size = new Size(70, 23);
            numMaxRatio.TabIndex = 10;
            numMaxRatio.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblQueueTarget
            // 
            lblQueueTarget.Location = new Point(12, 162);
            lblQueueTarget.Name = "lblQueueTarget";
            lblQueueTarget.Size = new Size(130, 23);
            lblQueueTarget.TabIndex = 11;
            lblQueueTarget.Text = "Stop after N queued:";
            // 
            // numQueueTarget
            // 
            numQueueTarget.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numQueueTarget.Location = new Point(148, 160);
            numQueueTarget.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numQueueTarget.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numQueueTarget.Name = "numQueueTarget";
            numQueueTarget.Size = new Size(80, 23);
            numQueueTarget.TabIndex = 12;
            numQueueTarget.Value = new decimal(new int[] { 200, 0, 0, 0 });
            // 
            // lblCandidates
            // 
            lblCandidates.Location = new Point(10, 188);
            lblCandidates.Name = "lblCandidates";
            lblCandidates.Size = new Size(300, 23);
            lblCandidates.TabIndex = 13;
            lblCandidates.Text = "Candidate queue (filtered):";
            // 
            // txtCandidates
            // 
            txtCandidates.Location = new Point(10, 214);
            txtCandidates.Multiline = true;
            txtCandidates.Name = "txtCandidates";
            txtCandidates.ReadOnly = true;
            txtCandidates.ScrollBars = ScrollBars.Vertical;
            txtCandidates.Size = new Size(300, 88);
            txtCandidates.TabIndex = 14;
            // 
            // picTargetAvatar
            // 
            picTargetAvatar.BorderStyle = BorderStyle.FixedSingle;
            picTargetAvatar.Location = new Point(331, 3);
            picTargetAvatar.Name = "picTargetAvatar";
            picTargetAvatar.Size = new Size(72, 72);
            picTargetAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picTargetAvatar.TabIndex = 15;
            picTargetAvatar.TabStop = false;
            // 
            // lblTargetName
            // 
            lblTargetName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTargetName.Location = new Point(412, 10);
            lblTargetName.Name = "lblTargetName";
            lblTargetName.Size = new Size(370, 23);
            lblTargetName.TabIndex = 16;
            // 
            // lblTargetFollowers
            // 
            lblTargetFollowers.Location = new Point(412, 32);
            lblTargetFollowers.Name = "lblTargetFollowers";
            lblTargetFollowers.Size = new Size(370, 23);
            lblTargetFollowers.TabIndex = 17;
            // 
            // lblTargetFollowing
            // 
            lblTargetFollowing.Location = new Point(412, 50);
            lblTargetFollowing.Name = "lblTargetFollowing";
            lblTargetFollowing.Size = new Size(370, 23);
            lblTargetFollowing.TabIndex = 18;
            // 
            // lblTargetRepos
            // 
            lblTargetRepos.Location = new Point(412, 68);
            lblTargetRepos.Name = "lblTargetRepos";
            lblTargetRepos.Size = new Size(370, 23);
            lblTargetRepos.TabIndex = 19;
            // 
            // lnkTargetProfile
            // 
            lnkTargetProfile.Location = new Point(330, 88);
            lnkTargetProfile.Name = "lnkTargetProfile";
            lnkTargetProfile.Size = new Size(300, 23);
            lnkTargetProfile.TabIndex = 20;
            lnkTargetProfile.LinkClicked += lnkTargetProfile_LinkClicked;
            // 
            // lblTargetAssessment
            // 
            lblTargetAssessment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTargetAssessment.Location = new Point(330, 108);
            lblTargetAssessment.Name = "lblTargetAssessment";
            lblTargetAssessment.Size = new Size(450, 23);
            lblTargetAssessment.TabIndex = 21;
            // 
            // lblDailyCap
            // 
            lblDailyCap.Location = new Point(332, 138);
            lblDailyCap.Name = "lblDailyCap";
            lblDailyCap.Size = new Size(100, 23);
            lblDailyCap.TabIndex = 22;
            lblDailyCap.Text = "Daily cap:";
            // 
            // numDailyCap
            // 
            numDailyCap.Location = new Point(450, 136);
            numDailyCap.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numDailyCap.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDailyCap.Name = "numDailyCap";
            numDailyCap.Size = new Size(80, 23);
            numDailyCap.TabIndex = 23;
            numDailyCap.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblMinInterval
            // 
            lblMinInterval.Location = new Point(330, 172);
            lblMinInterval.Name = "lblMinInterval";
            lblMinInterval.Size = new Size(115, 23);
            lblMinInterval.TabIndex = 24;
            lblMinInterval.Text = "Min interval (min):";
            // 
            // numMinInterval
            // 
            numMinInterval.Location = new Point(450, 170);
            numMinInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numMinInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMinInterval.Name = "numMinInterval";
            numMinInterval.Size = new Size(80, 23);
            numMinInterval.TabIndex = 25;
            numMinInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMaxInterval
            // 
            lblMaxInterval.Location = new Point(330, 201);
            lblMaxInterval.Name = "lblMaxInterval";
            lblMaxInterval.Size = new Size(115, 23);
            lblMaxInterval.TabIndex = 26;
            lblMaxInterval.Text = "Max interval (min):";
            // 
            // numMaxInterval
            // 
            numMaxInterval.Location = new Point(450, 199);
            numMaxInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numMaxInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxInterval.Name = "numMaxInterval";
            numMaxInterval.Size = new Size(80, 23);
            numMaxInterval.TabIndex = 27;
            numMaxInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnStartCrawler
            // 
            btnStartCrawler.Location = new Point(316, 227);
            btnStartCrawler.Name = "btnStartCrawler";
            btnStartCrawler.Size = new Size(155, 23);
            btnStartCrawler.TabIndex = 28;
            btnStartCrawler.Text = "Start Follow Crawler";
            btnStartCrawler.Click += btnStartCrawler_Click;
            // 
            // btnStopCrawler
            // 
            btnStopCrawler.Enabled = false;
            btnStopCrawler.Location = new Point(490, 227);
            btnStopCrawler.Name = "btnStopCrawler";
            btnStopCrawler.Size = new Size(110, 23);
            btnStopCrawler.TabIndex = 29;
            btnStopCrawler.Text = "Stop Crawler";
            btnStopCrawler.Click += btnStopCrawler_Click;
            // 
            // lblCrawlerStatus
            // 
            lblCrawlerStatus.Location = new Point(331, 270);
            lblCrawlerStatus.Name = "lblCrawlerStatus";
            lblCrawlerStatus.Size = new Size(450, 23);
            lblCrawlerStatus.TabIndex = 30;
            lblCrawlerStatus.Text = "Crawler idle.";
          
            // 
            // lblNextFollowCountdown
            // 
            lblNextFollowCountdown.Location = new Point(330, 270);
            lblNextFollowCountdown.Name = "lblNextFollowCountdown";
            lblNextFollowCountdown.Size = new Size(450, 23);
            lblNextFollowCountdown.TabIndex = 31;
            // 
            // btnExportCandidates
            // 
            btnExportCandidates.Location = new Point(10, 308);
            btnExportCandidates.Name = "btnExportCandidates";
            btnExportCandidates.Size = new Size(148, 23);
            btnExportCandidates.TabIndex = 32;
            btnExportCandidates.Text = "Export Candidate Queue";
            btnExportCandidates.Click += btnExportCandidates_Click;
            // 
            // btnExportFollowLog
            // 
            btnExportFollowLog.Location = new Point(165, 308);
            btnExportFollowLog.Name = "btnExportFollowLog";
            btnExportFollowLog.Size = new Size(145, 23);
            btnExportFollowLog.TabIndex = 33;
            btnExportFollowLog.Text = "Export Follow Log";
            btnExportFollowLog.Click += btnExportFollowLog_Click;
            // 
            // lstCrawlerLog
            // 
            lstCrawlerLog.Location = new Point(10, 346);
            lstCrawlerLog.Name = "lstCrawlerLog";
            lstCrawlerLog.Size = new Size(770, 229);
            lstCrawlerLog.TabIndex = 34;
            // 
            // tabAFB
            // 
            tabAFB.Controls.Add(lblAFBInterval);
            tabAFB.Controls.Add(numAFBInterval);
            tabAFB.Controls.Add(btnStartAutoFollowBack);
            tabAFB.Controls.Add(btnStopAutoFollowBack);
            tabAFB.Controls.Add(btnRunAFBNow);
            tabAFB.Controls.Add(lblAFBStatus);
            tabAFB.Controls.Add(lblAFBCountdown);
            tabAFB.Controls.Add(lstAFBLog);
            tabAFB.Location = new Point(4, 24);
            tabAFB.Name = "tabAFB";
            tabAFB.Size = new Size(792, 672);
            tabAFB.TabIndex = 3;
            tabAFB.Text = "Auto Follow-Back";
            // 
            // lblAFBInterval
            // 
            lblAFBInterval.Location = new Point(10, 12);
            lblAFBInterval.Name = "lblAFBInterval";
            lblAFBInterval.Size = new Size(130, 23);
            lblAFBInterval.TabIndex = 0;
            lblAFBInterval.Text = "Poll interval (min):";
            // 
            // numAFBInterval
            // 
            numAFBInterval.Location = new Point(148, 10);
            numAFBInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numAFBInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAFBInterval.Name = "numAFBInterval";
            numAFBInterval.Size = new Size(80, 23);
            numAFBInterval.TabIndex = 1;
            numAFBInterval.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // btnStartAutoFollowBack
            // 
            btnStartAutoFollowBack.Location = new Point(240, 8);
            btnStartAutoFollowBack.Name = "btnStartAutoFollowBack";
            btnStartAutoFollowBack.Size = new Size(140, 23);
            btnStartAutoFollowBack.TabIndex = 2;
            btnStartAutoFollowBack.Text = "Start Auto Follow-Back";
            btnStartAutoFollowBack.Click += btnStartAutoFollowBack_Click;
            // 
            // btnStopAutoFollowBack
            // 
            btnStopAutoFollowBack.Enabled = false;
            btnStopAutoFollowBack.Location = new Point(388, 8);
            btnStopAutoFollowBack.Name = "btnStopAutoFollowBack";
            btnStopAutoFollowBack.Size = new Size(80, 23);
            btnStopAutoFollowBack.TabIndex = 3;
            btnStopAutoFollowBack.Text = "Stop";
            btnStopAutoFollowBack.Click += btnStopAutoFollowBack_Click;
            // 
            // btnRunAFBNow
            // 
            btnRunAFBNow.Location = new Point(476, 8);
            btnRunAFBNow.Name = "btnRunAFBNow";
            btnRunAFBNow.Size = new Size(110, 23);
            btnRunAFBNow.TabIndex = 4;
            btnRunAFBNow.Text = "Run Once Now";
            btnRunAFBNow.Click += btnRunAFBNow_Click;
            // 
            // lblAFBStatus
            // 
            lblAFBStatus.Location = new Point(10, 38);
            lblAFBStatus.Name = "lblAFBStatus";
            lblAFBStatus.Size = new Size(500, 23);
            lblAFBStatus.TabIndex = 5;
            lblAFBStatus.Text = "Idle.";
            // 
            // lblAFBCountdown
            // 
            lblAFBCountdown.Location = new Point(10, 58);
            lblAFBCountdown.Name = "lblAFBCountdown";
            lblAFBCountdown.Size = new Size(300, 23);
            lblAFBCountdown.TabIndex = 6;
            // 
            // lstAFBLog
            // 
            lstAFBLog.Location = new Point(10, 82);
            lstAFBLog.Name = "lstAFBLog";
            lstAFBLog.Size = new Size(770, 469);
            lstAFBLog.TabIndex = 7;
            // 
            // tabStarBack
            // 
            tabStarBack.Controls.Add(lblFollowersToScan);
            tabStarBack.Controls.Add(numFollowersToScan);
            tabStarBack.Controls.Add(lblMinStarsForStar);
            tabStarBack.Controls.Add(numMinStarsForStar);
            tabStarBack.Controls.Add(btnLoadStarCandidates);
            tabStarBack.Controls.Add(btnCancelStarScan);
            tabStarBack.Controls.Add(btnSelectAllStars);
            tabStarBack.Controls.Add(btnStarSelected);
            tabStarBack.Controls.Add(btnOpenStarUrl);
            tabStarBack.Controls.Add(lblStarBackStatus);
            tabStarBack.Controls.Add(dgvStarBack);
            tabStarBack.Controls.Add(lstStarBackLog);
            tabStarBack.Location = new Point(4, 24);
            tabStarBack.Name = "tabStarBack";
            tabStarBack.Size = new Size(792, 672);
            tabStarBack.TabIndex = 4;
            tabStarBack.Text = "Star-Back";
            // 
            // lblFollowersToScan
            // 
            lblFollowersToScan.Location = new Point(10, 12);
            lblFollowersToScan.Name = "lblFollowersToScan";
            lblFollowersToScan.Size = new Size(130, 23);
            lblFollowersToScan.TabIndex = 0;
            lblFollowersToScan.Text = "Followers to scan:";
            // 
            // numFollowersToScan
            // 
            numFollowersToScan.Location = new Point(148, 10);
            numFollowersToScan.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numFollowersToScan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFollowersToScan.Name = "numFollowersToScan";
            numFollowersToScan.Size = new Size(80, 23);
            numFollowersToScan.TabIndex = 1;
            numFollowersToScan.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblMinStarsForStar
            // 
            lblMinStarsForStar.Location = new Point(240, 12);
            lblMinStarsForStar.Name = "lblMinStarsForStar";
            lblMinStarsForStar.Size = new Size(90, 23);
            lblMinStarsForStar.TabIndex = 2;
            lblMinStarsForStar.Text = "Min repo stars:";
            // 
            // numMinStarsForStar
            // 
            numMinStarsForStar.Location = new Point(334, 10);
            numMinStarsForStar.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numMinStarsForStar.Name = "numMinStarsForStar";
            numMinStarsForStar.Size = new Size(70, 23);
            numMinStarsForStar.TabIndex = 3;
            numMinStarsForStar.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnLoadStarCandidates
            // 
            btnLoadStarCandidates.Location = new Point(416, 8);
            btnLoadStarCandidates.Name = "btnLoadStarCandidates";
            btnLoadStarCandidates.Size = new Size(130, 23);
            btnLoadStarCandidates.TabIndex = 4;
            btnLoadStarCandidates.Text = "Load Candidates";
            btnLoadStarCandidates.Click += btnLoadStarCandidates_Click;
            // 
            // btnCancelStarScan
            // 
            btnCancelStarScan.Enabled = false;
            btnCancelStarScan.Location = new Point(554, 8);
            btnCancelStarScan.Name = "btnCancelStarScan";
            btnCancelStarScan.Size = new Size(70, 23);
            btnCancelStarScan.TabIndex = 5;
            btnCancelStarScan.Text = "Cancel";
            btnCancelStarScan.Click += btnCancelStarScan_Click;
            // 
            // btnSelectAllStars
            // 
            btnSelectAllStars.Location = new Point(632, 8);
            btnSelectAllStars.Name = "btnSelectAllStars";
            btnSelectAllStars.Size = new Size(90, 23);
            btnSelectAllStars.TabIndex = 6;
            btnSelectAllStars.Text = "Select All";
            btnSelectAllStars.Click += btnSelectAllStars_Click;
            // 
            // btnStarSelected
            // 
            btnStarSelected.Location = new Point(730, 8);
            btnStarSelected.Name = "btnStarSelected";
            btnStarSelected.Size = new Size(110, 23);
            btnStarSelected.TabIndex = 7;
            btnStarSelected.Text = "⭐ Star Checked";
            btnStarSelected.Click += btnStarSelected_Click;
            // 
            // btnOpenStarUrl
            // 
            btnOpenStarUrl.Location = new Point(750, 8);
            btnOpenStarUrl.Name = "btnOpenStarUrl";
            btnOpenStarUrl.Size = new Size(108, 23);
            btnOpenStarUrl.TabIndex = 8;
            btnOpenStarUrl.Text = "Open in Browser";
            btnOpenStarUrl.Click += btnOpenStarUrl_Click;
            // 
            // lblStarBackStatus
            // 
            lblStarBackStatus.Location = new Point(10, 38);
            lblStarBackStatus.Name = "lblStarBackStatus";
            lblStarBackStatus.Size = new Size(760, 23);
            lblStarBackStatus.TabIndex = 9;
            // 
            // dgvStarBack
            // 
            dgvStarBack.AllowUserToAddRows = false;
            dgvStarBack.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStarBack.Columns.AddRange(new DataGridViewColumn[] { dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvStarBack.Location = new Point(10, 53);
            dgvStarBack.Name = "dgvStarBack";
            dgvStarBack.Size = new Size(770, 395);
            dgvStarBack.TabIndex = 10;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // lstStarBackLog
            // 
            lstStarBackLog.Location = new Point(10, 458);
            lstStarBackLog.Name = "lstStarBackLog";
            lstStarBackLog.Size = new Size(770, 94);
            lstStarBackLog.TabIndex = 11;
            // 
            // tabRepoHealth
            // 
            tabRepoHealth.Controls.Add(btnScanRepos);
            tabRepoHealth.Controls.Add(btnOpenRepoUrl);
            tabRepoHealth.Controls.Add(btnQuickFixTopics);
            tabRepoHealth.Controls.Add(lblRepoHealthStatus);
            tabRepoHealth.Controls.Add(dgvRepoHealth);
            tabRepoHealth.Location = new Point(4, 24);
            tabRepoHealth.Name = "tabRepoHealth";
            tabRepoHealth.Size = new Size(792, 672);
            tabRepoHealth.TabIndex = 5;
            tabRepoHealth.Text = "Repo Health";
            // 
            // btnScanRepos
            // 
            btnScanRepos.Location = new Point(10, 10);
            btnScanRepos.Name = "btnScanRepos";
            btnScanRepos.Size = new Size(120, 23);
            btnScanRepos.TabIndex = 0;
            btnScanRepos.Text = "Scan My Repos";
            btnScanRepos.Click += btnScanRepos_Click;
            // 
            // btnOpenRepoUrl
            // 
            btnOpenRepoUrl.Location = new Point(138, 10);
            btnOpenRepoUrl.Name = "btnOpenRepoUrl";
            btnOpenRepoUrl.Size = new Size(120, 23);
            btnOpenRepoUrl.TabIndex = 1;
            btnOpenRepoUrl.Text = "Open in Browser";
            btnOpenRepoUrl.Click += btnOpenRepoUrl_Click;
            // 
            // btnQuickFixTopics
            // 
            btnQuickFixTopics.Location = new Point(266, 10);
            btnQuickFixTopics.Name = "btnQuickFixTopics";
            btnQuickFixTopics.Size = new Size(130, 23);
            btnQuickFixTopics.TabIndex = 2;
            btnQuickFixTopics.Text = "Set Topics (selected)";
            btnQuickFixTopics.Click += btnQuickFixTopics_Click;
            // 
            // lblRepoHealthStatus
            // 
            lblRepoHealthStatus.Location = new Point(408, 15);
            lblRepoHealthStatus.Name = "lblRepoHealthStatus";
            lblRepoHealthStatus.Size = new Size(372, 23);
            lblRepoHealthStatus.TabIndex = 3;
            // 
            // dgvRepoHealth
            // 
            dgvRepoHealth.AllowUserToAddRows = false;
            dgvRepoHealth.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepoHealth.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12 });
            dgvRepoHealth.Location = new Point(10, 40);
            dgvRepoHealth.Name = "dgvRepoHealth";
            dgvRepoHealth.ReadOnly = true;
            dgvRepoHealth.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRepoHealth.Size = new Size(770, 520);
            dgvRepoHealth.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // tabProfile
            // 
            tabProfile.Controls.Add(btnRefreshProfile);
            tabProfile.Controls.Add(btnOpenProfileBrowser);
            tabProfile.Controls.Add(lblProfileRefreshInterval);
            tabProfile.Controls.Add(numProfileRefreshInterval);
            tabProfile.Controls.Add(btnStartProfileAutoRefresh);
            tabProfile.Controls.Add(btnStopProfileAutoRefresh);
            tabProfile.Controls.Add(lblProfileStatus);
            tabProfile.Controls.Add(webProfile);
            tabProfile.Location = new Point(4, 24);
            tabProfile.Name = "tabProfile";
            tabProfile.Size = new Size(792, 672);
            tabProfile.TabIndex = 6;
            tabProfile.Text = "Profile";
            tabProfile.Enter += tabProfile_Enter;
            // 
            // btnRefreshProfile
            // 
            btnRefreshProfile.Location = new Point(10, 10);
            btnRefreshProfile.Name = "btnRefreshProfile";
            btnRefreshProfile.Size = new Size(90, 23);
            btnRefreshProfile.TabIndex = 0;
            btnRefreshProfile.Text = "Refresh";
            btnRefreshProfile.Click += btnRefreshProfile_Click;
            // 
            // btnOpenProfileBrowser
            // 
            btnOpenProfileBrowser.Location = new Point(108, 10);
            btnOpenProfileBrowser.Name = "btnOpenProfileBrowser";
            btnOpenProfileBrowser.Size = new Size(120, 23);
            btnOpenProfileBrowser.TabIndex = 1;
            btnOpenProfileBrowser.Text = "Open in Browser";
            btnOpenProfileBrowser.Click += btnOpenProfileBrowser_Click;
            // 
            // lblProfileRefreshInterval
            // 
            lblProfileRefreshInterval.Location = new Point(240, 13);
            lblProfileRefreshInterval.Name = "lblProfileRefreshInterval";
            lblProfileRefreshInterval.Size = new Size(110, 23);
            lblProfileRefreshInterval.TabIndex = 2;
            lblProfileRefreshInterval.Text = "Auto-refresh (sec):";
            // 
            // numProfileRefreshInterval
            // 
            numProfileRefreshInterval.Location = new Point(354, 10);
            numProfileRefreshInterval.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            numProfileRefreshInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numProfileRefreshInterval.Name = "numProfileRefreshInterval";
            numProfileRefreshInterval.Size = new Size(70, 23);
            numProfileRefreshInterval.TabIndex = 3;
            numProfileRefreshInterval.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // btnStartProfileAutoRefresh
            // 
            btnStartProfileAutoRefresh.Location = new Point(432, 8);
            btnStartProfileAutoRefresh.Name = "btnStartProfileAutoRefresh";
            btnStartProfileAutoRefresh.Size = new Size(110, 23);
            btnStartProfileAutoRefresh.TabIndex = 4;
            btnStartProfileAutoRefresh.Text = "Start Auto-Refresh";
            btnStartProfileAutoRefresh.Click += btnStartProfileAutoRefresh_Click;
            // 
            // btnStopProfileAutoRefresh
            // 
            btnStopProfileAutoRefresh.Enabled = false;
            btnStopProfileAutoRefresh.Location = new Point(550, 8);
            btnStopProfileAutoRefresh.Name = "btnStopProfileAutoRefresh";
            btnStopProfileAutoRefresh.Size = new Size(60, 23);
            btnStopProfileAutoRefresh.TabIndex = 5;
            btnStopProfileAutoRefresh.Text = "Stop";
            btnStopProfileAutoRefresh.Click += btnStopProfileAutoRefresh_Click;
            // 
            // lblProfileStatus
            // 
            lblProfileStatus.Location = new Point(622, 13);
            lblProfileStatus.Name = "lblProfileStatus";
            lblProfileStatus.Size = new Size(158, 23);
            lblProfileStatus.TabIndex = 6;
            // 
            // webProfile
            // 
            webProfile.Location = new Point(10, 60);
            webProfile.Name = "webProfile";
            webProfile.ScriptErrorsSuppressed = true;
            webProfile.Size = new Size(770, 500);
            webProfile.TabIndex = 7;
            // 
            // tabAchievements
            // 
            tabAchievements.Controls.Add(btnCheckAchievements);
            tabAchievements.Controls.Add(lblAchievementStatus);
            tabAchievements.Controls.Add(dgvAchievements);
            tabAchievements.Controls.Add(btnOpenAchievementUrl);
            tabAchievements.Controls.Add(btnHowToUnlock);
            tabAchievements.Location = new Point(4, 24);
            tabAchievements.Name = "tabAchievements";
            tabAchievements.Size = new Size(792, 672);
            tabAchievements.TabIndex = 7;
            tabAchievements.Text = "Achievements";
            // 
            // btnCheckAchievements
            // 
            btnCheckAchievements.Location = new Point(10, 10);
            btnCheckAchievements.Name = "btnCheckAchievements";
            btnCheckAchievements.Size = new Size(160, 23);
            btnCheckAchievements.TabIndex = 0;
            btnCheckAchievements.Text = "Check My Achievements";
            btnCheckAchievements.Click += btnCheckAchievements_Click;
            // 
            // lblAchievementStatus
            // 
            lblAchievementStatus.Location = new Point(180, 14);
            lblAchievementStatus.Name = "lblAchievementStatus";
            lblAchievementStatus.Size = new Size(580, 23);
            lblAchievementStatus.TabIndex = 1;
            lblAchievementStatus.Text = "Click Check to load your achievement progress.";
            // 
            // dgvAchievements
            // 
            dgvAchievements.AllowUserToAddRows = false;
            dgvAchievements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAchievements.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17, dataGridViewTextBoxColumn18, dataGridViewTextBoxColumn19 });
            dgvAchievements.Location = new Point(10, 40);
            dgvAchievements.Name = "dgvAchievements";
            dgvAchievements.ReadOnly = true;
            dgvAchievements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAchievements.Size = new Size(770, 440);
            dgvAchievements.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // btnOpenAchievementUrl
            // 
            btnOpenAchievementUrl.Location = new Point(10, 490);
            btnOpenAchievementUrl.Name = "btnOpenAchievementUrl";
            btnOpenAchievementUrl.Size = new Size(160, 23);
            btnOpenAchievementUrl.TabIndex = 3;
            btnOpenAchievementUrl.Text = "Open in Browser";
            btnOpenAchievementUrl.Click += btnOpenAchievementUrl_Click;
            // 
            // btnHowToUnlock
            // 
            btnHowToUnlock.Location = new Point(178, 490);
            btnHowToUnlock.Name = "btnHowToUnlock";
            btnHowToUnlock.Size = new Size(160, 23);
            btnHowToUnlock.TabIndex = 4;
            btnHowToUnlock.Text = "How To Unlock";
            btnHowToUnlock.Click += btnHowToUnlock_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(800, 700);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "GitHub Manager";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabOverview.ResumeLayout(false);
            tabDiff.ResumeLayout(false);
            tabCrawler.ResumeLayout(false);
            tabCrawler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMinRepos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxRatio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQueueTarget).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTargetAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDailyCap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxInterval).EndInit();
            tabAFB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numAFBInterval).EndInit();
            tabStarBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numFollowersToScan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinStarsForStar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStarBack).EndInit();
            tabRepoHealth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRepoHealth).EndInit();
            tabProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numProfileRefreshInterval).EndInit();
            tabAchievements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAchievements).EndInit();
            ResumeLayout(false);
        }

        // Overview
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOverview, tabDiff, tabCrawler, tabAFB, tabStarBack, tabRepoHealth, tabProfile;
        private System.Windows.Forms.Label lblStatus, lblFollowers, lblFollowing, lblRateLimit;
        private System.Windows.Forms.Button btnRefreshOverview;
        private System.Windows.Forms.Button btnChangeToken;

        // Diff
        private System.Windows.Forms.Button btnLoadDiff, btnUnfollowSelected, btnFollowSelected, btnCancelBulk;
        private System.Windows.Forms.Button btnSelectAllNotFollowingBack, btnSelectAllNotFollowedYet;
        private System.Windows.Forms.Button btnAddToKeep, btnRemoveFromKeep;
        private System.Windows.Forms.Button btnAddToNeverFollow, btnRemoveFromNeverFollow, btnImportNeverFollow;
        private System.Windows.Forms.Label lblNeverFollowHeader;
        private System.Windows.Forms.ListView lvNeverFollow;
        private System.Windows.Forms.Label lblDiffStatus, lblKeepListHeader;
        private System.Windows.Forms.ListView lvNotFollowingBack, lvNotFollowedYet, lvKeepList;
        private System.Windows.Forms.ListBox lstLog;

        // Crawler
        private System.Windows.Forms.Label lblTargetUser, lblCandidates, lblMinRepos, lblMaxRatio;
        private System.Windows.Forms.Label lblQueueTarget, lblDailyCap, lblMinInterval, lblMaxInterval;
        private System.Windows.Forms.Label lblCrawlerStatus, lblNextFollowCountdown;
        private System.Windows.Forms.Label lblTargetName, lblTargetFollowers, lblTargetFollowing, lblTargetRepos, lblTargetAssessment;
        private System.Windows.Forms.TextBox txtTargetUser, txtCandidates;
        private System.Windows.Forms.Button btnValidateTarget, btnPullCandidates, btnStartCrawler, btnStopCrawler;
        private System.Windows.Forms.Button btnExportCandidates, btnExportFollowLog;
        private System.Windows.Forms.RadioButton rbSourceFollowers, rbSourceFollowing;
        private System.Windows.Forms.CheckBox chkQualityFilter;
        private System.Windows.Forms.NumericUpDown numMinRepos, numMaxRatio, numQueueTarget, numDailyCap, numMinInterval, numMaxInterval;
        private System.Windows.Forms.PictureBox picTargetAvatar;
        private System.Windows.Forms.LinkLabel lnkTargetProfile;
        private System.Windows.Forms.ListBox lstCrawlerLog;

        // Auto Follow-Back
        private System.Windows.Forms.Label lblAFBInterval, lblAFBStatus, lblAFBCountdown;
        private System.Windows.Forms.NumericUpDown numAFBInterval;
        private System.Windows.Forms.Button btnStartAutoFollowBack, btnStopAutoFollowBack, btnRunAFBNow;
        private System.Windows.Forms.ListBox lstAFBLog;

        // Star-Back
        private System.Windows.Forms.Label lblFollowersToScan, lblMinStarsForStar, lblStarBackStatus;
        private System.Windows.Forms.NumericUpDown numFollowersToScan, numMinStarsForStar;
        private System.Windows.Forms.Button btnLoadStarCandidates, btnCancelStarScan, btnSelectAllStars, btnStarSelected, btnOpenStarUrl;
        private System.Windows.Forms.DataGridView dgvStarBack;
        private System.Windows.Forms.ListBox lstStarBackLog;

        // Repo Health
        private System.Windows.Forms.Button btnScanRepos, btnOpenRepoUrl, btnQuickFixTopics;
        private System.Windows.Forms.Label lblRepoHealthStatus;
        private System.Windows.Forms.DataGridView dgvRepoHealth;

        // Profile
        private System.Windows.Forms.Button btnRefreshProfile, btnOpenProfileBrowser;
        private System.Windows.Forms.Button btnStartProfileAutoRefresh, btnStopProfileAutoRefresh;
        private System.Windows.Forms.Label lblProfileRefreshInterval, lblProfileStatus;
        private System.Windows.Forms.NumericUpDown numProfileRefreshInterval;
        private System.Windows.Forms.WebBrowser webProfile;

        // Achievements
        private System.Windows.Forms.TabPage tabAchievements;
        private System.Windows.Forms.Button btnCheckAchievements, btnOpenAchievementUrl, btnHowToUnlock;
        private System.Windows.Forms.Label lblAchievementStatus;
        private System.Windows.Forms.DataGridView dgvAchievements;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
    }
}