﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DB
{
    [Table("MKB")]
    class MKBItem
    {
        [Column("MKBCode")]
        public string MKBCode { get; set; }

        [Column("Title")]
        public string Title { get; set; }
    }
}
