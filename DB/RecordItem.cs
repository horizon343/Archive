using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Archive.DB
{
    [Table("Record")]
    class RecordItem
    {
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }

        [Column("PatientID")]
        public int PatientID { get; set; }

        [Column("DateOfReceipt")]
        public DateTime DateOfReceipt { get; set; }

        [Column("DateOfDischarge")]
        public DateTime DateOfDischarge { get; set; }

        [Column("HistoryNumber")]
        public int HistoryNumber { get; set; }

        [Column("MKBCode")]
        public string MKBCode { get; set; }
    }
}
