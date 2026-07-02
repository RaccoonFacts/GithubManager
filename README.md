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
- Bulk follow and unfollow with throttled, rate-limit-safe execution
- **Following Since** column — see exactly how long you've been following someone
- **Keep List** — permanently protect accounts from ever appearing in your unfollow list
- Full operation log with cancel support

### 🤖 Follow Crawler
- Pull candidate followers from any target GitHub user
- Choose between their **followers** or **who they follow** as your candidate source
- **Target Validation** — preview any account before pulling with:
  - Profile photo
  - Follower / following counts
  - Public repo count
  - Follow ratio
  - Account age
  - Color-coded target quality assessment (Excellent / Good / Decent / Poor)
- **Quality Filter** — automatically skip accounts with too few repos or bot-like follow ratios
- Live streaming candidate queue — candidates appear as pages load, no waiting for full fetch
- Randomized interval timer between follows (configurable min/max in minutes)
- Daily cap with countdown to next follow action
- Export candidate queue and follow log to file

### ⚡ Auto Follow-Back
- Polls your followers on a configurable interval
- Automatically follows back anyone who followed you that you haven't followed yet
- Run Once Now button for immediate one-shot execution
- Full action log with timestamps
- All follows recorded to persistent follow tracker

### ⭐ Star-Back
- Scans your followers' public repositories
- Deduplicates against your existing starred repos
- Configurable minimum star threshold and follower scan count
- Cancel mid-scan — partial results still populate
- Select All + bulk star in one click
- Capped at top 100 repos per user to prevent slowdowns on large accounts
- NEED TO ADD UNSTAR

### 🏥 Repo Health Scanner
- Scans all your public repositories and checks for:
  - ✔ README present
  - ✔ Description set
  - ✔ Topics tagged
  - ✔ Homepage URL
  - ✔ Recent activity (flags repos with no pushes in 6+ months)
- Color-coded health rating per repo (Good / Okay / Poor)
- **Quick Fix Topics** — set topics on any repo directly from the app
- Open any repo in browser with one click

### 🏆 Achievements Tracker
Checks your progress against all current GitHub achievements using the API:

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
- Auto-refresh timer (configurable down to 1 second)
- Live countdown to next refresh
- Refresh counter — see how many times it's refreshed since starting
- Open in default browser button

---

## 🔧 Requirements

- Windows 10 or later
- [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2022+ (for building from source)
- GitHub Personal Access Token (PAT)

---

## 🔑 GitHub Token Setup

This app requires a **Classic Personal Access Token** with the following scopes:

| Scope | Required For |
|---|---|
| `user:follow` | Follow / Unfollow operations |
| `public_repo` | Starring repositories |
| `read:user` | Profile and achievement data |

### Generate your token:
1. Go to [github.com/settings/tokens](https://github.com/settings/tokens)
2. Click **Generate new token (classic)**
3. Check: `user:follow`, `public_repo`, `read:user`
4. Copy the token — you only see it once

> ⚠️ **Fine-grained tokens** handle starring differently. Classic tokens are recommended for full compatibility.

---

## 🚀 Getting Started

### From Source

```bash
git clone https://github.com/YourUsername/GithubManager.git
cd GithubManager
```

1. Open `GithubManager.sln` in Visual Studio 2022
2. Right-click solution → **Manage NuGet Packages**
3. Install:
   - `Octokit`
   - `System.Security.Cryptography.ProtectedData`
4. Build → Run (`F5`)
5. Enter your PAT on first launch
6. Check **Remember Token** to save it encrypted — you won't be prompted again

---

## 🔒 Security

- Your token is **never stored in plain text**
- Encrypted using **Windows DPAPI** (`ProtectedData.Protect`) tied to your Windows user account
- Stored at `%AppData%\GithubManager\token.enc`
- Follow logs and keep lists stored locally at `%AppData%\GithubManager\`
- Nothing is ever sent anywhere except the official GitHub API

---

## 📁 Project Structure

```
GithubManager/
├── Form1.cs                    ← Main form code-behind (all tab handlers)
├── Form1.Designer.cs           ← UI layout (7 tabs, fully code-generated)
├── GitHubSocialManager.cs      ← Core GitHub API service layer
├── FollowCrawler.cs            ← Randomized follow automation with timer
├── AutoFollowBackService.cs    ← Polling service for auto follow-back
├── AchievementChecker.cs       ← Achievement progress checker
├── FollowTracker.cs            ← Persistent follow date log (JSON)
├── KeepList.cs                 ← Persistent keep list (JSON)
├── TokenStorage.cs             ← DPAPI encrypted token storage
└── Program.cs                  ← Entry point
```

---

## ⚙️ Data Files

All persistent data is stored in `%AppData%\GithubManager\`:

| File | Contents |
|---|---|
| `token.enc` | DPAPI encrypted GitHub PAT |
| `follow_log_{username}.json` | Follow dates per user |
| `keep_list_{username}.json` | Protected accounts list |

---

## ⚠️ Disclaimer

This tool uses the official GitHub API with your own credentials for your own account.
All operations are subject to [GitHub's Terms of Service](https://docs.github.com/en/site-policy/github-terms/github-terms-of-service).
The built-in rate limiting, daily caps, and randomized delays are designed to keep usage within acceptable bounds.
Use responsibly.

---

## 🛠️ Built With

- [C# / .NET 10](https://dotnet.microsoft.com/)
- [Windows Forms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
- [Octokit.net](https://github.com/octokit/octokit.net) — Official GitHub API client
- [System.Security.Cryptography.ProtectedData](https://www.nuget.org/packages/System.Security.Cryptography.ProtectedData) — DPAPI token encryption
- [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview) — Local data persistence

---

## 📄 License

MIT License — do whatever you want with it.
