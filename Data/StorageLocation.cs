using Archive.DB;

namespace Archive.Data
{
    static class StorageLocation
    {
        public static List<StorageLocationItem> StorageLocationList { get; set; } = new List<StorageLocationItem>();
        public static bool isDataReceived = false;

        private static int currentPage = 1;
        private static int totalPage = 1;

        private static int pageSize = 10000;

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
    }
}
