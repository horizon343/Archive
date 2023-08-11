using SQLite;

namespace Archive.DB
{
    [Table("Record")]
    class RecordItem
    {
        [Column("RecordID")]
        public Guid RecordID { get; set; }
        
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }

        [Column("PatientID")]
        public Guid PatientID { get; set; }

        [Column("DateOfReceipt")]
        public DateTime DateOfReceipt { get; set; }

        [Column("DateOfDischarge")]
        public DateTime DateOfDischarge { get; set; }

        [Column("HistoryNumber")]
        public int HistoryNumber { get; set; }

        [Column("MKBCode")]
        public string MKBCode { get; set; }

        [Column("StorageLocationID")]
        public string StorageLocationID { get; set; }
    }
}
