using SQLite;

namespace Archive.DB
{
    [Table("MKB")]
    class MKBItem
    {
        [PrimaryKey, Column("MKBCode")]
        public string MKBCode { get; set; }

        [Column("Title")]
        public string Title { get; set; }
    }
}
