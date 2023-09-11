using Archive.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Archive.DB
{
    internal class DataBase
    {
        private static string connectionString = "";
        private static readonly string jsonFilePath = FilesPaths.connectionDBFilePath;

        private static JObject? jsonObject;
        public static bool errorWhenConnection = false;

        public DataBase()
        {
            errorWhenConnection = false;

            try
            {
                if (jsonObject == null)
                {
                    if (File.Exists(jsonFilePath))
                    {
                        string jsonContext = File.ReadAllText(jsonFilePath);
                        jsonObject = JObject.Parse(jsonContext);
                        if (jsonObject["ConnectionString"] != null)
                        {
                            connectionString = jsonObject["ConnectionString"].ToString();

                            using SqlConnection connection = new SqlConnection(connectionString);
                            connection.Open();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка, отсутствует поле \"ConnectionString\"");
                            errorWhenConnection = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка, отсутствует файл с настройками");
                        errorWhenConnection = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных");
                errorWhenConnection = true;
            }
        }

        /// <summary>
        /// Обновление записи в таблице
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="item">Запись для добавления</param>
        /// <param name="fieldID">Поле с ID</param>
        public async Task<int> EntryUpdate<T>(T item, string fieldID)
        {
            try
            {
                string table = typeof(T).Name.Remove(typeof(T).Name.IndexOf("Item"));
                PropertyInfo[] properties = typeof(T).GetProperties();
                string setString = string.Join(", ", properties.Select(property => $"{property.Name} = @{property.Name}"));

                string updateQuery = $"UPDATE {table} SET {setString} WHERE {fieldID} = @{fieldID}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            SqlParameter parameter = new SqlParameter($"@{property.Name}", property.GetValue(item));
                            command.Parameters.Add(parameter);
                        }
                        return await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при обновлении записи: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Удаляет массив записей по primaryKey
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <typeparam name="PK">Тип первичного ключа</typeparam>
        /// <param name="primaryKey">Поле первичного ключа (Name)</param>
        /// <param name="listPK">Список из значений первичного ключа</param>
        /// <returns></returns>
        public async Task<int> DeleteEntry<T, PK>(string primaryKey, List<PK> listPK)
        {
            try
            {
                string table = typeof(T).Name.Remove(typeof(T).Name.IndexOf("Item"));
                string values = "";
                for (int i = 0; i < listPK.Count; i++)
                {
                    values += "@" + i.ToString();
                    if (i != listPK.Count - 1)
                        values += ",";
                }
                string query = $"DELETE FROM {table} WHERE {primaryKey} IN ({values})";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        for (int i = 0; i < listPK.Count; i++)
                        {
                            SqlParameter parameter = new SqlParameter("@" + i, listPK[i]);
                            command.Parameters.Add(parameter);
                        }

                        int? count = await command.ExecuteNonQueryAsync();
                        if (count != null)
                            return (int)count;
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при удалении записи: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> DeleteEntry<T, PK>(string primaryKey, PK data)
        {
            List<PK> dataList = new List<PK>();
            dataList.Add(data);
            return await DeleteEntry<T, PK>(primaryKey, dataList);
        }

        /// <summary>
        /// Постраничное получение записей из таблицы 
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле сортировки (поле с ID)</param>
        /// <param name="fields">Поля, которые нужно вернуть (все поля: *)</param>
        /// <param name="fieldsAndValues">Поля и значения (осуществляется точный поиск)</param>
        public async Task<(List<T>, int)> GetPagedEntries<T>(int pageNumber, int pageSize, string sortField, string fields = "*", Dictionary<string, object>? fieldsAndValues = null) where T : new()
        {
            try
            {
                if (pageSize <= 0 || pageNumber <= 0)
                    return (new List<T>(), 0);

                string table = (typeof(T).Name).Remove(typeof(T).Name.IndexOf("Item"));
                int startIndex = (pageNumber - 1) * pageSize;

                string countQuery = $"SELECT COUNT(*) FROM {table}";
                string dataQuery = $"SELECT {fields} FROM {table} ORDER BY {sortField} OFFSET {startIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                if (fieldsAndValues != null)
                {
                    string queryWhere = string.Join(" AND ", fieldsAndValues.Select(fieldAndValue => $"{fieldAndValue.Key} = @{fieldAndValue.Key}"));

                    countQuery = $"SELECT COUNT(*) FROM {table} WHERE {queryWhere}";
                    dataQuery = $"SELECT {fields} FROM {table} WHERE {queryWhere} ORDER BY {sortField} OFFSET {startIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
                }

                int totalPages = 0;
                List<T> result = new List<T>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                    {
                        if (fieldsAndValues != null)
                            foreach (var fieldAndValue in fieldsAndValues)
                            {
                                SqlParameter parameter = new SqlParameter("@" + fieldAndValue.Key, fieldAndValue.Value);
                                countCommand.Parameters.Add(parameter);
                            }

                        int totalCount = (int)await countCommand.ExecuteScalarAsync();
                        totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    }

                    using (SqlCommand dataCommand = new SqlCommand(dataQuery, connection))
                    {
                        if (fieldsAndValues != null)
                            foreach (var fieldAndValue in fieldsAndValues)
                            {
                                SqlParameter parameter = new SqlParameter("@" + fieldAndValue.Key, fieldAndValue.Value);
                                dataCommand.Parameters.Add(parameter);
                            }

                        using (SqlDataReader reader = await dataCommand.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                T item = new T();
                                PopulateItemFromDataReader<T>(item, reader);
                                result.Add(item);
                            }
                        }
                    }
                }

                return (result, totalPages);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при получении записей: {ex.Message}");
                return (new List<T>(), 0);
            }
        }

        /// <summary>
        /// Поиск записей по первому и последнему символу
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="startSymbol">Первый символ строки</param>
        /// <param name="endSymbol">Последний символ строки</param>
        /// <param name="field">Поле, по которому осуществляется поиск</param>
        /// <param name="fields">Поля, которые нужно вернуть (все поля: *)</param>
        public async Task<List<T>> GetEntriesStartAndEndCharacter<T>(string startSymbol, string endSymbol, string field, string fields = "*") where T : new()
        {
            try
            {
                List<T> result = new List<T>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string table = (typeof(T).Name).Remove(typeof(T).Name.IndexOf("Item"));

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT {fields} FROM {table} WHERE {field} LIKE '{startSymbol}%%{endSymbol}'";
                    command.Connection = connection;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                T item = new T();
                                PopulateItemFromDataReader<T>(item, reader);
                                result.Add(item);
                            }
                            return result;
                        }
                        return new List<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при поиске записей: {ex.Message}");
                return new List<T>();
            }
        }

        /// <summary>
        /// Добавление записи в таблицу T
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="data">Данные (типа T)</param>
        public async Task InsertEntry<T>(List<T> data) where T : new()
        {
            try
            {
                string table = typeof(T).Name.Remove(typeof(T).Name.IndexOf("Item"));
                PropertyInfo[] properties = typeof(T).GetProperties();

                string columns = string.Join(", ", properties.Select(property => property.Name));
                string values = "";
                for (int i = 0; i < data.Count; i++)
                {
                    values += "(" + string.Join(", ", properties.Select(property => "@" + property.Name + i)) + ")";
                    if (i != data.Count - 1)
                        values += ",";
                }

                string query = $"INSERT INTO {table} ({columns}) VALUES {values}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                SqlParameter parameter = new SqlParameter("@" + property.Name + i, property.GetValue(data[i]) ?? DBNull.Value);
                                command.Parameters.Add(parameter);
                            }
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при добавлении записи: {ex.Message}");
            }
        }
        public async Task InsertEntry<T>(T data) where T : new()
        {
            List<T> dataList = new List<T>();
            dataList.Add(data);
            await InsertEntry<T>(dataList);
        }

        /// <summary>
        /// Выполняет слияние
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="data">Данные (типа T)</param>
        /// <param name="primaryKey">Первичный ключ из таблицы <T></param>
        public async Task MergeEntry<T>(List<T> data, string primaryKey) where T : new()
        {
            try
            {
                string table = typeof(T).Name.Remove(typeof(T).Name.IndexOf("Item"));
                PropertyInfo[] properties = typeof(T).GetProperties();

                string columns = string.Join(", ", properties.Select(property => property.Name));
                string values = "";
                for (int i = 0; i < data.Count; i++)
                {
                    values += "(" + string.Join(", ", properties.Select(property => "@" + property.Name + i)) + ")";
                    if (i != data.Count - 1)
                        values += ",";
                }
                string updateString = "";
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].Name != primaryKey)
                    {
                        updateString += $"{properties[i].Name}=Source.{properties[i].Name}";
                        if (i != properties.Length - 1)
                            updateString += ",";
                    }
                }
                string insertString = string.Join(", ", properties.Select(property => $"Source.{property.Name}"));

                string query = $"MERGE INTO {table} AS Target " +
                               $"USING (VALUES {values}) " +
                               $"AS Source ({columns}) " +
                               $"ON Target.{primaryKey} = Source.{primaryKey} " +
                               $"WHEN MATCHED THEN " +
                               $"UPDATE SET {updateString} " +
                               $"WHEN NOT MATCHED THEN " +
                               $"INSERT ({columns}) " +
                               $"VALUES ({insertString});";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                SqlParameter parameter = new SqlParameter("@" + property.Name + i, property.GetValue(data[i]) ?? DBNull.Value);
                                command.Parameters.Add(parameter);
                            }
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непредвиденная ошибка при слиянии записи: {ex.Message}");
            }
        }

        private void PopulateItemFromDataReader<T>(T item, SqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                PropertyInfo? property = typeof(T).GetProperty(columnName);

                if (property != null && reader[columnName] != DBNull.Value)
                    property.SetValue(item, reader[columnName]);
            }
        }
    }
}
