using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DB
{
    internal class DBase
    {
        private SQLiteConnection connection;

        /// <summary>
        /// Создает базу данных и подключение к ней
        /// </summary>
        public DBase(string DBPath = "Archive.sqlite")
        {
            connection = new SQLiteConnection(DBPath);
        }

        /// <summary>
        /// Создает таблицы в базе данных
        /// </summary>
        public void CreateTables()
        {
            connection.CreateTables(CreateFlags.None, new Type[] { typeof(RecordItem), typeof(MKBItem), typeof(PatientItem), typeof(DepartmentItem) });
        }

        /// <summary>
        /// Получает всю таблицу <T>
        /// </summary>
        public TableQuery<T> GetTable<T>() where T : new()
        {
            TableQuery<T> data = connection.Table<T>();
            return data;
        }

        /// <summary>
        /// Добавляет данные в таблицу <T>
        /// </summary>
        public void SetDataTable<T>(T data) where T : new()
        {
            connection.Insert(data);
        }
    }
}
