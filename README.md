# 🐙 GithubManager

A personal GitHub social management desktop application built in **C# WinForms (.NET 10)** using the official [Octokit.net](https://github.com/octokit/octokit.net) library. Built for power users who want full control over their GitHub social presence without touching the browser.

---

## ✨ Features

### 📊 Overview
- Live follower and following counts
- API rate limit monitoring
- One-click token swap without restarting the app

### 🔄 Follow Diff
- Side-by-side view of who doesn't follow you back vs who you haven't followed back yet
- Sortable **Following Since** column — click to sort by days, see who's been ignoring you longest
- Bulk follow and unfollow with throttled, rate-limit-safe execution
- **Keep List** — permanently protect accounts from ever appearing in your unfollow list
- **Never Follow List** — blacklist accounts the crawler will always skip; auto-unfollows on add
- Deduplication — no duplicate entries across paginated API results
- Full operation log with cancel support

### 🤖 Follow Crawler
- Pull candidate followers from any target GitHub user
- Choose between their **followers** or **who they follow** as your candidate source
- **Target Validation** — preview any account before pulling:
  - Profile photo, follower/following counts, public repo count
  - Follow ratio, account age
  - Color-coded quality assessment (Excellent / Good / Decent / Poor)
- **Quality Filter** — skip accounts with too few repos or bot-like follow ratios
- Live streaming candidate queue — candidates appear as pages load
- Randomized interval timer with countdown to next follow action
- Configurable daily cap
- Never Follow list checked before queuing — prevents re-following blacklisted accounts
- Export candidate queue and follow log to file

### ⚡ Auto Follow-Back
- Polls your followers on a configurable interval
- Automatically follows back anyone who followed you that you haven't followed yet
- Run Once Now for immediate execution
- Full timestamped action log

### ⭐ Star-Back
- Scans your followers' public repositories
- Deduplicates against your existing starred repos
- Configurable minimum star threshold and follower scan count
- Capped at top 100 repos per user — prevents slowdowns on large accounts
- Cancel mid-scan — partial results still populate
- Select All + bulk star in one click

### 🏥 Repo Health Scanner
- Scans all your public repositories and checks for:
  - ✔ README present
  - ✔ Description set
  - ✔ Topics tagged
  - ✔ Homepage URL
  - ✔ Recent activity (flags repos stale for 6+ months)
- Color-coded health rating per repo (Good / Okay / Poor)
- **Quick Fix Topics** — set topics on any repo directly from the app
- Open any repo in browser with one click

### 🏆 Achievements Tracker
Checks progress against all current GitHub achievements via the API:

| Achievement | Tiers | How Checked |
|---|---|---|
| 🌟 Starstruck | 16 / 128 / 512 / 4096 stars | Scans your repos |
| 🦈 Pull Shark | 2 / 16 / 128 / 1024 merged PRs | Search API |
| ⚡ Quickdraw | Close issue within 5 min | Events API |
| 👥 Pair Extraordinaire | 1 / 10 / 24 / 48 co-authored commits | Code search |
| 🤞 YOLO | Merge PR without review | Manual check |
| 🧠 Galaxy Brain | Accepted discussion answers | Manual check |
| 💝 Public Sponsor | Sponsor a user | Manual check |
| 🧊 Arctic Code Vault | 2020 code snapshot | Account age check |

- Color-coded status (Unlocked / In Progress / Locked)
- How To Unlock popup with tier breakdown per achievement
- Direct links to relevant GitHub pages

### 👤 Profile Preview
- Embedded browser showing your live GitHub profile
- Auto-refresh timer configurable down to 1 second
- Live countdown to next refresh + total refresh counter
- Open in default browser button

---

## 🔧 Requirements

- Windows 10 or later
- [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2022+ (for building from source)
- GitHub Personal Access Token (PAT)

---

## 🔑 GitHub Token Setup

Requires a **Classic Personal Access Token** with:

| Scope | Required For |
|---|---|
| `user:follow` | Follow / Unfollow operations |
| `public_repo` | Starring repositories |
| `read:user` | Profile and achievement data |

1. Go to [github.com/settings/tokens](https://github.com/settings/tokens)
2. **Generate new token (classic)**
3. Check: `user:follow`, `public_repo`, `read:user`
4. Copy the token — shown once only

> ⚠️ Fine-grained tokens handle starring differently. Classic tokens recommended for full compatibility.

---

## 🚀 Getting Started

```bash
git clone https://github.com/RaccoonFacts/GithubManager.git
cd GithubManager
```

1. Open `GithubManager.sln` in Visual Studio 2022
2. **Manage NuGet Packages** → install:
   - `Octokit`
   - `System.Security.Cryptography.ProtectedData`
3. Build → Run (`F5`)
4. Enter your PAT on first launch — check **Remember Token** to encrypt and persist it

---

## 🔒 Security

- Token encrypted via **Windows DPAPI** (`ProtectedData.Protect`), tied to your Windows user account
- Stored at `%AppData%\GithubManager\token.enc` — never plain text
- All persistent data stays local, only outbound connection is the official GitHub API

---

## 📁 Project Structure

```
GithubManager/
├── Form1.cs                  ← Main form (all tab handlers)
├── Form1.Designer.cs         ← UI layout (8 tabs)
├── GitHubSocialManager.cs    ← Core GitHub API service layer
├── FollowCrawler.cs          ← Randomized follow automation with timer
├── AutoFollowBackService.cs  ← Polling service for auto follow-back
├── AchievementChecker.cs     ← Achievement progress checker
├── FollowTracker.cs          ← Persistent follow date log (JSON)
├── KeepList.cs               ← Persistent keep list (JSON)
├── NeverFollowList.cs        ← Persistent blacklist (JSON)
├── ListViewDaySorter.cs      ← Sortable follow-age column
├── TokenStorage.cs           ← DPAPI encrypted token storage
└── Program.cs                ← Entry point
```

---

## ⚙️ Data Files

All stored in `%AppData%\GithubManager\`:

| File | Contents |
|---|---|
| `token.enc` | DPAPI encrypted GitHub PAT |
| `follow_log_{username}.json` | Follow dates per user |
| `keep_list_{username}.json` | Protected accounts |
| `never_follow_{username}.json` | Crawler blacklist |

---

## 🛠️ Built With

- [C# / .NET 10](https://dotnet.microsoft.com/) + Windows Forms
- [Octokit.net](https://github.com/octokit/octokit.net) — Official GitHub API client
- [System.Security.Cryptography.ProtectedData](https://www.nuget.org/packages/System.Security.Cryptography.ProtectedData) — DPAPI encryption
- [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview) — Local persistence

---

## ⚠️ Disclaimer

Uses the official GitHub API with your own credentials against your own account. Built-in rate limiting, daily caps, and randomized delays keep usage within acceptable bounds.

---

## 📄 License

MIT — do whatever you want with it.
