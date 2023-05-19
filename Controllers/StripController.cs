using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Knjizara.Models;
using Knjizara.Konekcija;
using System.Security.Principal;
using System.Net.Http;
using System.Web.UI;

namespace Knjizara.Controllers
{
    public class StripController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unesi()
        {
            return View();
        }

        public ActionResult SacuvajPodatke(Strip strip)
        {
            using (SqlConnection konekcija = new SqlConnection(Konekcija.Konekcija.Konektuj()))
            {
                using (SqlCommand komanda = new SqlCommand("INSERT INTO strip VALUES ('" + strip.Naziv + "', '" + strip.Izdavac + "', " + strip.Cena + ")", konekcija))
                {
                    if (konekcija.State != ConnectionState.Open) konekcija.Open();
                    komanda.ExecuteNonQuery();
                }
            }

            return RedirectToAction("TabelaStripova");
        }

        public ActionResult TabelaStripova()
        {
            List<Strip> Stripovi = new List<Strip>();
            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Konektuj()))
            {
                using (SqlCommand kom = new SqlCommand("SELECT * FROM strip", kon))
                {
                    if (kon.State != ConnectionState.Open) kon.Open();

                    SqlDataReader drStrip = kom.ExecuteReader();
                    DataTable dtStrip = new DataTable();
                    dtStrip.Load(drStrip);

                    foreach (DataRow StripSlog in dtStrip.Rows) Stripovi.Add(new Strip(StripSlog));
                }
            }

            return View(Stripovi);
        }
        public ActionResult Obrisi(int id)
        {
            if (id < 0)
                return HttpNotFound();


            using (SqlConnection kon = new SqlConnection(Konekcija.Konekcija.Konektuj()))
            {
                using (SqlCommand kom = new SqlCommand("Delete from strip where id='" + id + "'", kon))
                {
                    if (kon.State != System.Data.ConnectionState.Open)
                        kon.Open();

                    kom.ExecuteNonQuery();
                    kon.Close();
                }
            }
           
            return RedirectToAction("TabelaStripova");
        }
    }
}