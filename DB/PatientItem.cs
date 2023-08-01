using SQLite;

namespace Archive.DB
{
    [Table("Patient")]
    class PatientItem
    {
        [PrimaryKey, Column("PatientID")]
        public Guid PatientID { get; set; }

        [Column("PatientNumber")]
        public string PatientNumber { get; set; }

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
        public string Index { get; set; }
    }
}
