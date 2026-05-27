using Newtonsoft.Json;
using PasswordManager.Models;
using System.Collections.Generic;
using System.IO;

namespace PasswordManager.Services
{
    public static class FileService
    {
        private static readonly string FilePath = "passwords.json";

        public static void Save(List<PasswordEntry> entries)
        {
            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static List<PasswordEntry> Load()
        {
            if (!File.Exists(FilePath))
                return new List<PasswordEntry>();

            string json = File.ReadAllText(FilePath);

            return JsonConvert.DeserializeObject<List<PasswordEntry>>(json)
                   ?? new List<PasswordEntry>();
        }
    }
}