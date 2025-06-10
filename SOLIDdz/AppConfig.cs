using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class AppConfig
{
    private static AppConfig instance;
    private static object @lock = new object();
    static Dictionary<string, string> settings;
    private static string filePath = "config.json";
    private AppConfig()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
        else
        {
            settings = new Dictionary<string, string>();
        }
    }
    public static void SetSetting(string key, string value)
    {
        settings[key] = value;
        SaveToFile();
    }
    public static string GetSetting(string key)
    {
        return settings.ContainsKey(key) ? settings[key] : null;
    }
    public static void SaveToFile()
    {
        string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
