using Archive.DB;

namespace Archive.Data
{
    static class Departments
    {
        public static List<DepartmentItem> DepartmentList { get; set; } = new List<DepartmentItem>();
        public static bool isDataReceived = false;

        private static int currentPage = 1;
        private static int totalPage = 1;
        private static readonly int pageSize = 10000;

        // Получает список отделений
        public static async Task<bool> GetDepartment(DataBase dataBase)
        {
            try
            {
                while (currentPage <= totalPage)
                {
                    (List<DepartmentItem>, int) departments = await dataBase.GetPagedEntries<DepartmentItem>(currentPage, pageSize, "DepartmentID");
                    DepartmentList.AddRange(departments.Item1);
                    currentPage += 1;
                    totalPage = departments.Item2;
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
