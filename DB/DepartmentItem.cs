using SQLite;

namespace Archive.DB
{
    [Table("Department")]
    class DepartmentItem
    {
        [PrimaryKey, AutoIncrement, Column("DepartmentID")]
        public int DepartmentID { get; set; }

        [Column("Title")]
        public string Title { get; set; }
    }
}
