using Archive.DB;

namespace Archive.Data
{
    static class MKB
    {
        public static List<MKBItem> MKBList { get; set; } = new List<MKBItem>();
        public static bool isDataReceived = false;

        private static int currentPage = 1;
        private static int totalPage = 1;
        private static readonly int pageSize = 10000;

        // Получает список МКБ кодов
        public static async Task<bool> GetMKB(DataBase dataBase)
        {
            try
            {
                while (currentPage <= totalPage)
                {
                    (List<MKBItem>, int) mkb = await dataBase.GetPagedEntries<MKBItem>(currentPage, pageSize, "MKBCode", "MKBCode");
                    MKBList.AddRange(mkb.Item1);
                    currentPage += 1;
                    totalPage = mkb.Item2;
                }

                isDataReceived = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
