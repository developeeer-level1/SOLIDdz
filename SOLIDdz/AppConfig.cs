using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PATTERNSdz
{
    public class AppConfig
    {
        private static readonly Lazy<AppConfig> _instance = new Lazy<AppConfig>(() => new AppConfig());
        private Dictionary<string, string> _settings;
        private const string FilePath = "settings.json";
        public static AppConfig Instance => _instance.Value;
        private AppConfig()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                _settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }
            else
            {
                _settings = new Dictionary<string, string>();
            }
        }
        public void SetSetting(string key, string value)
        {
            _settings[key] = value;
            SaveSettings();
        }

        public string GetSetting(string key)
        {
            return _settings.ContainsKey(key) ? _settings[key] : "Not found";
        }
        private void SaveSettings()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(_settings, options);
            File.WriteAllText(FilePath, json);
        }
    }
}
