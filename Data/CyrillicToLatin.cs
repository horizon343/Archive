using Newtonsoft.Json.Linq;

namespace Archive.Data
{
    static class CyrillicToLatin
    {
        private static readonly string filePathCyrillicToLatinMap = "CyrillicToLatinMap.json";
        public static Dictionary<char, char> CyrillicToLatinMap { get; set; } = new Dictionary<char, char> { };

        public static void GetCyrillicToLatin()
        {
            try
            {
                if (File.Exists(filePathCyrillicToLatinMap))
                {
                    string jsonContext = File.ReadAllText(filePathCyrillicToLatinMap);
                    JObject jsonObject = JObject.Parse(jsonContext);
                    foreach (var item in jsonObject)
                    {
                        CyrillicToLatinMap.Add(item.Key[0], item.Value.ToString()[0]);
                    }
                }
                else
                {
                    MessageBox.Show($"Ошибка мапинга, отсутствует {filePathCyrillicToLatinMap}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка мапинга: [{ex.Message}]");
            }
        }
    }
}
