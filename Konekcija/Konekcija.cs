using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Knjizara.Konekcija
{
    public class Konekcija
    {
        public static string Konektuj()
        {
            return ConfigurationManager.ConnectionStrings["Knjizara"].ConnectionString;
        }
    }
}