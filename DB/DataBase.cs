using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Archive.DB
{
    internal class DataBase
    {
        private string connectionString = "Server=XAMI4OK;Database=Archive;Trusted_Connection=True;Encrypt=false;";

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

        public async Task<(List<T>, int)> SearchEntriesByFieldValue<T, F>(int pageNumber, int pageSize, string sortField, string field, F[] values, string fields = "*") where T : new()
        {
            try
            {
                if (pageSize <= 0 || pageNumber <= 0 || values.Length == 0)
                    return (new List<T>(), 0);

                string table = typeof(T).Name.Remove(typeof(T).Name.IndexOf("Item"));
                int startIndex = (pageNumber - 1) * pageSize;

                string queryWhere = string.Join(", ", values);

                string countQuery = $"SELECT COUNT(*) FROM {table} WHERE {field} IN ({queryWhere})";
                string dataQuery = $"SELECT {fields} FROM {table} WHERE {field} IN ({queryWhere}) ORDER BY {sortField} OFFSET {startIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                int totalPages = 0;
                List<T> result = new List<T>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                    {
                        int totalCount = (int)await countCommand.ExecuteScalarAsync();
                        totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    }

                    using (SqlCommand dataCommand = new SqlCommand(dataQuery, connection))
                    {
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
                MessageBox.Show($"Непредвиденная ошибка при поиске записей: {ex.Message}");
                return (new List<T>(), 0);
            }
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
        /// Добавление одной записи в таблицу T
        /// </summary>
        /// <typeparam name="T">Таблица (MKBItem, PatientItem и т.д.)</typeparam>
        /// <param name="data">Данные (типа T)</param>
        public async Task InsertEntry<T>(T data) where T : new()
        {
            try
            {
                string table = (typeof(T).Name).Remove(typeof(T).Name.IndexOf("Item"));
                PropertyInfo[] properties = typeof(T).GetProperties();

                string columns = string.Join(", ", properties.Select(property => property.Name));
                string values = string.Join(", ", properties.Select(property => "@" + property.Name));

                string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            SqlParameter parameter = new SqlParameter("@" + property.Name, property.GetValue(data) ?? DBNull.Value);
                            command.Parameters.Add(parameter);
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
