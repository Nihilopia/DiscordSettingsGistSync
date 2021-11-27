using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiscordSettingsGistSync
{
    internal static class LocalStorageParser
    {
        internal static async Task<List<string>> GetLocalStorageAsync()
        {
            string[] files = Directory.GetFiles(Config.LocalStorageLocation);
            List<string> dbContent = new(files.Length);
            foreach (string filePath in files)
            {
                dbContent.Add(await File.ReadAllTextAsync(filePath, Encoding.Latin1));
            }

            for (int j = 0; j < dbContent.Count; j++)
            {
                string line = dbContent[j];
                dbContent[j] = ParseString(line);
            }

            return dbContent;
        }

        private static string ParseString(string toParse)
        {
            string charsToKeep = "abcdefghijklmnopqrstuvwxyz";
            charsToKeep += charsToKeep.ToUpper();
            charsToKeep += "{}:;,.()[]\\'\"- ";

            StringBuilder sb = new();
            foreach (char item in toParse)
            {
                if (charsToKeep.Contains(item))
                {
                    sb.Append(item);
                }
            }
            return sb.ToString();
        }

        internal static string GetStore(string storeName)
        {
            throw new System.NotImplementedException(nameof(GetStore));
        }
    }
}
