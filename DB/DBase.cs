using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Archive.DB
{
    internal class DBase
    {
        private SQLiteConnection connection;

        /// <summary>
        /// Создает базу данных и подключение к ней
        /// </summary>
        /// <param name="DBPath">Путь к базе данных (Default: Archive.sqlite)</param>
        public DBase(string DBPath = "Archive.sqlite")
        {
            connection = new SQLiteConnection(DBPath);
        }

        /// <summary>
        /// Закрывает соединение с базой данных
        /// </summary>
        public void CloseDatabaseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// Создает таблицы в базе данных, если они не существуют
        /// </summary>
        public void CreateTables()
        {
            connection.CreateTables(CreateFlags.None, new Type[] { typeof(RecordItem), typeof(MKBItem), typeof(PatientItem), typeof(DepartmentItem) });
        }

        /// <summary>
        /// Получает значения из таблицы <T>
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="page">Номер страницы (page = -1 : выдает всю таблицу)</param>
        /// <param name="limit">Количество записей на странице</param>
        /// <returns>(int, List<T>):(Общее количество страниц при делениее limit, данные из таблицы)</returns>
        public (int, List<T>) GetTable<T>(int page, int limit) where T : new()
        {
            if (page == -1)
                return (0, connection.Table<T>().ToList());

            int totalRecords = connection.Table<T>().Count();
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / limit);
            if (page <= 0 || page > totalPages)
                return (0, new List<T>());

            int skipCountRecords = (page - 1) * limit;
            return (totalPages, connection.Table<T>().Skip(skipCountRecords).Take(limit).ToList());
        }

        /// <summary>
        /// Добавляет данные в таблицу <T>
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="data">Экземпляр класса (MKBItem, PatientItem и т.д.)</param>
        public void SetDataTable<T>(T data) where T : new()
        {
            connection.Insert(data);
        }

        /// <summary>
        /// Поиск записей в базе данных по полям
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="fieldAndValue">Словарь {Поле, значение}</param>
        /// <returns>Массив записей List<T></returns>
        public List<T> SearchData<T>(Dictionary<string, string> fieldAndValue) where T : new()
        {
            List<string> conditions = new List<string>();
            List<object> parameters = new List<object>();

            int index = 0;
            foreach (var item in fieldAndValue)
            {
                conditions.Add($"{item.Key} = @{index}");
                parameters.Add(item.Value);
                index++;
            }

            string table = (typeof(T).Name).Remove(typeof(T).Name.IndexOf("Item"));
            string whereJoin = string.Join(" AND ", conditions);
            string query = $"SELECT * FROM {table} WHERE {whereJoin}";

            return connection.Query<T>(query, parameters.ToArray()).ToList();
        }


    }
}