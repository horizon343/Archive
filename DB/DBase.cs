using SQLite;

namespace Archive.DB
{
    internal class DBase
    {
        private SQLiteConnection connection;
        private SQLiteAsyncConnection connectionAsync;

        /// <summary>
        /// Создает базу данных и подключение к ней
        /// </summary>
        /// <param name="DBPath">Путь к базе данных (Default: Archive.sqlite)</param>
        public DBase(bool async = false, string DBPath = "Archive.sqlite")
        {
            if (!async)
                connection = new SQLiteConnection(DBPath);
            else
                connectionAsync = new SQLiteAsyncConnection(DBPath);
        }

        /// <summary>
        /// Закрывает соединение с базой данных
        /// </summary>
        public void CloseDatabaseConnection()
        {
            connection.Close();
        }
        public async Task CloseDatabaseConnectionAsync()
        {
            await connectionAsync.CloseAsync();
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
        /// Получить значения определенного поля из таблицы <T>
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <typeparam name="TResult">Тип результата</typeparam>
        /// <param name="columnName">Название поля</param>
        /// <returns>Список значений из поля</returns>
        public List<TResult> GetColumnValues<T, TResult>(string columnName) where TResult : new()
        {
            string table = (typeof(T).Name).Remove(typeof(T).Name.IndexOf("Item"));
            string query = $"SELECT {columnName} FROM {table}";

            return connection.Query<TResult>(query).ToList();
        }
        public async Task<List<TResult>> GetColumnValuesAsync<T, TResult>(string columnName) where TResult : new()
        {
            string table = (typeof(T).Name).Remove(typeof(T).Name.IndexOf("Item"));
            string query = $"SELECT {columnName} FROM {table}";

            return await connectionAsync.QueryAsync<TResult>(query);
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
        public void SetDataTable<T>(List<T> data) where T : new()
        {
            connection.InsertAll(data);
        }

        /// <summary>
        /// Поиск записей в базе данных по полям
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="fieldAndValue">Словарь {Поле, значение}</param>
        /// <returns>Массив записей List<T></returns>
        public List<T> SearchData<T>(Dictionary<string, object> fieldAndValue) where T : new()
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

        /// <summary>
        /// Поиск записей по первому символу
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="symbol">Символ для поиска</param>
        /// <param name="field">Поле из таблицы для поиска</param>
        public List<T> GetEntriesStartingWithLetter<T>(string symbol, string field) where T : new()
        {
            string table = (typeof(T).Name).Remove(typeof(T).Name.IndexOf("Item"));
            string query = $"SELECT * FROM {table} WHERE {field} LIKE '{symbol}%'";

            return connection.Query<T>(query).ToList();
        }

        /// <summary>
        /// Обновить запись в базе данных
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <typeparam name="I">Тип ID из таблицы (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="ID">ID</param>
        /// <param name="newRecordDB">Новая запись</param>
        /// <returns></returns>
        public bool UpdateEntryInDB<T, I>(I ID, T newRecordDB) where T : new()
        {
            try
            {
                T recordDB = connection.Find<T>(ID);
                if (recordDB != null)
                {
                    recordDB = newRecordDB;
                    connection.Update(recordDB);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Очистить содержимое таблицы <T>
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        public void ClearTable<T>() where T : new()
        {
            connection.DeleteAll<T>();
        }

    }
}