using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Archive.DB
{
    [Table("Department")]
    class DepartmentItem
    {
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }

        [Column("Title")]
        public string Title { get; set; }
    }
}
