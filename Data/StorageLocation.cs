using Archive.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Archive.Data
{
    static class StorageLocation
    {
        public static List<StorageLocationItem> StorageLocationList { get; set; } = new List<StorageLocationItem>();
        public static bool isDataReceived = false;
        private static readonly string configFilePath = FilesPaths.configFilePath;

        private static int currentPage = 1;
        private static int totalPage = 1;
        private static readonly int pageSize = 10000;

        public static string? currentStorageLocation = null;

        // Получить места хранения карт
        public static async Task<bool> GetStorageLocation(DataBase dataBase)
        {
            try
            {
                while (currentPage <= totalPage)
                {
                    (List<StorageLocationItem>, int) storageLocations = await dataBase.GetPagedEntries<StorageLocationItem>(currentPage, pageSize, "StorageLocationID");
                    StorageLocationList.AddRange(storageLocations.Item1);
                    currentPage += 1;
                    totalPage = storageLocations.Item2;
                }

                isDataReceived = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Устанавливает текущее местоположение
        public static bool SetCurrentStorageLocation()
        {
            try
            {
                if (File.Exists(configFilePath))
                {
                    string jsonContext = File.ReadAllText(configFilePath);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    string? currentStorageLocationFromJson = jsonObject["CurrentStorageLocation"]?.ToString();
                    if (currentStorageLocationFromJson != null)
                    {
                        currentStorageLocation = currentStorageLocationFromJson;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Изменяет текущее местоположение
        public static bool SetNewStorageLocation(string newStorageLocationID)
        {
            try
            {
                if (File.Exists(configFilePath))
                {
                    string jsonContext = File.ReadAllText(configFilePath);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    if (jsonObject["CurrentStorageLocation"] != null)
                        jsonObject["CurrentStorageLocation"] = newStorageLocationID;
                    else
                        jsonObject.Add("CurrentStorageLocation", newStorageLocationID);

                    using (StreamWriter file = File.CreateText(configFilePath))
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        jsonObject.WriteTo(writer);
                        return true;
                    }
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
