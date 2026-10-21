
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GymMembershipManagementSystem.Services
{
    public class JsonFile<T>
    {
        private readonly string filePath;

        public JsonFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save(List<T> data)
        {
            string json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(filePath, json);
        }

        public List<T> Load()
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();
        }
    }
}
