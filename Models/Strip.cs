using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Knjizara.Models
{
    public class Strip
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Izdavac { get; set; }
        public decimal Cena { get; set; }

        public Strip() { }

        public Strip(DataRow strip)
        {
            Id = (int)strip["Id"];
            Naziv = strip["Naziv"].ToString();
            Izdavac = strip["Izdavac"].ToString();
            Cena = (decimal)strip["Cena"];
        }
    }
}