using Newtonsoft.Json.Linq;

namespace Archive.Data
{
    static class CyrillicToLatin
    {
        private static readonly string cyrillicToLatinMapFilePath = FilesPaths.cyrillicToLatinMapFilePath;

        public static Dictionary<char, char> CyrillicToLatinMap { get; set; } = new Dictionary<char, char> { };

        // Получает символы для автозамены
        public static bool GetCyrillicToLatin()
        {
            try
            {
                if (File.Exists(cyrillicToLatinMapFilePath))
                {
                    string jsonContext = File.ReadAllText(cyrillicToLatinMapFilePath);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    foreach (var item in jsonObject)
                    {
                        if (item.Key.Length != 1 || item.Value == null || item.Value.ToString().Length != 1)
                            continue;
                        CyrillicToLatinMap.Add(item.Key[0], item.Value.ToString()[0]);
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
