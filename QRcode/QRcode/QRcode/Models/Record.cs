using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace QRcode.Models
{
    public class Record
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Code { get; set; }
        public DateTime Date{ get; set; }
    }
}
