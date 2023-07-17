using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DB
{
    [Table("Patient")]
    class PatientItem
    {
        [Column("PatientID")]
        public int PatientID { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("MiddleName")]
        public string MiddleName { get; set; }

        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Column("Region")]
        public string Region { get; set; }

        [Column("District")]
        public string District { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("Index")]
        public int Index { get; set; }

    }
}
