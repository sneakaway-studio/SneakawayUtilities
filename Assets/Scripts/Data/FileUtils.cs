using System.IO;
using UnityEngine;

namespace SneakawayUtilities
{
    /// <summary>
    /// Utilities for saving / reading files
    /// - Reference: https://stackoverflow.com/a/63083061/441878
    /// </summary>
    public static class FileUtils
    {
        public static void WriteToFile(string fileName, string json)
        {
            var path = GetFilePath(fileName);
            var stream = new FileStream(path, FileMode.Create);

            using (var writer = new StreamWriter(stream))
                writer.Write(json);

            Debug.Log($"File saved {path}");
        }

        public static string ReadFromFile(string fileName)
        {
            var path = GetFilePath(fileName);
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                    return reader.ReadToEnd();
            }

            Debug.LogWarning($"{fileName} not found.");
            return null;
        }

        public static string GetFilePath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName);
        }
    }

    //// ^ Used like this, like in your DataManager

    //[Serializable]
    //public class PlayerData
    //{
    //    public int score = 0;
    //    public PlayerData(int score = 0)
    //    {
    //        this.score = score;
    //    }
    //}

    //public PlayerData playerData;

    //public void SavePlayerData(PlayerData data)
    //{
    //    var jsonData = JsonUtility.ToJson(data);
    //    FileUtils.WriteToFile(filename, jsonData);
    //}

    //public PlayerData LoadPlayerData()
    //{
    //    var jsonData = FileUtils.ReadFromFile(filename);
    //    if (jsonData == null)
    //        return new PlayerData();
    //    else
    //        return JsonUtility.FromJson<PlayerData>(jsonData);
    //}


}