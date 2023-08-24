using Archive.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Archive.Data
{
    static class StorageLocation
    {
        public static List<StorageLocationItem> StorageLocationList { get; set; } = new List<StorageLocationItem>();
        public static bool isDataReceived = false;

        private static int currentPage = 1;
        private static int totalPage = 1;

        private static int pageSize = 10000;

        private static readonly string currentStorageLocationPathFile = "JSON/config.json";
        public static string? currentStorageLocation = null;

        public static async Task GetStorageLocation()
        {
            try
            {
                DataBase dataBase = new DataBase();

                while (currentPage <= totalPage)
                {
                    (List<StorageLocationItem>, int) storageLocations = await dataBase.GetPagedEntries<StorageLocationItem>(currentPage, pageSize, "StorageLocationID");
                    StorageLocationList.AddRange(storageLocations.Item1);
                    currentPage += 1;
                    totalPage = storageLocations.Item2;
                }

                isDataReceived = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при получении мест хранения карт: {ex.Message}");
            }
        }

        public static void SetCurrentStorageLocation()
        {
            try
            {
                if (File.Exists(currentStorageLocationPathFile))
                {
                    string jsonContext = File.ReadAllText(currentStorageLocationPathFile);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    string? currentStorageLocationfromJson = jsonObject["CurrentStorageLocation"]?.ToString();
                    if (currentStorageLocationfromJson != null)
                        currentStorageLocation = currentStorageLocationfromJson;
                    else
                        currentStorageLocation = "Б";
                }
                else
                {
                    MessageBox.Show($"Непредвиденная ошибка при получении текущего местоположения: Отсутствует файл config.json");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при установлении текущего местоположения: {ex.Message}");
            }
        }

        public static void SetNewStorageLocation(string newStorageLocationID)
        {
            try
            {
                if (File.Exists(currentStorageLocationPathFile))
                {
                    string jsonContext = File.ReadAllText(currentStorageLocationPathFile);
                    JObject jsonObject = JObject.Parse(jsonContext);

                    if (jsonObject["CurrentStorageLocation"].ToString() != null)
                        jsonObject["CurrentStorageLocation"] = currentStorageLocation;
                    else
                        jsonObject.Add("CurrentStorageLocation", currentStorageLocation);

                    using (StreamWriter file = File.CreateText(currentStorageLocationPathFile))
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        jsonObject.WriteTo(writer);
                    }
                }
                else
                {
                    MessageBox.Show($"Непредвиденная ошибка при получении текущего местоположения: Отсутствует файл config.json");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка изменения текущего местоположения: {ex.Message}");
            }
        }
    }
}
