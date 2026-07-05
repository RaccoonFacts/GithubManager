namespace GithubManager
{
    using System.Text.Json;

    public class NeverFollowList
    {
        private readonly string _path;
        private HashSet<string> _entries;

        public NeverFollowList(string username)
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GithubManager");
            Directory.CreateDirectory(dir);
            _path = Path.Combine(dir, $"never_follow_{username}.json");
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_path)) { _entries = new(StringComparer.OrdinalIgnoreCase); return; }
            try
            {
                var json = File.ReadAllText(_path);
                var list = JsonSerializer.Deserialize<List<string>>(json) ?? new();
                _entries = new HashSet<string>(list, StringComparer.OrdinalIgnoreCase);
            }
            catch { _entries = new(StringComparer.OrdinalIgnoreCase); }
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_entries.OrderBy(e => e).ToList(),
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public void Add(string login)
        {
            var clean = login.Trim().Trim('"').TrimEnd(',').Trim();
            if (string.IsNullOrEmpty(clean)) return;
            _entries.Add(clean);
            Save();
        }
        public void Remove(string login) { _entries.Remove(login); Save(); }
        public bool Contains(string login) => _entries.Contains(login);
        public IReadOnlyCollection<string> All => _entries;
    }
}