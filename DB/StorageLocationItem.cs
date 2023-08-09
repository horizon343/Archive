using SQLite;

namespace Archive.DB
{
    [Table("StorageLocation")]
    class StorageLocationItem
    {
        [PrimaryKey, Column("StorageLocationID")]
        public string StorageLocationID { get; set; }

        [Column("Title")]
        public string Title { get; set; }
    }
}
