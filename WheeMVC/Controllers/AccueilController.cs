using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Data;
using WheeMVC.Models;
using System.Threading.Tasks;

namespace WheeMVC.Controllers
{
    public class AccueilController : Controller
    {
        NpgsqlConnection con = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlCommand cmd2 = new NpgsqlCommand();
        NpgsqlDataReader reader;
        NpgsqlDataReader reader2;
        string id;

        // GET: Accueil
        [HttpGet]
        public ActionResult Index()
        {
            id = (string)Session["idCompte"];
            List<ListViewModel> listView1 = new List<ListViewModel>();
            List<ListViewModel> listView2 = new List<ListViewModel>();
          

            connexionString();
            
            cmdList1(listView1);
           

            return View(listView1);
            

        }
        [HttpPost]
        public async Task<ActionResult> Index(string depart, string arriver)
        {
            List<ListViewModel> listView2 = new List<ListViewModel>();
            connexionString();

            
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM public.annonce_covoiturage as oc inner join publier as o on oc.idCov = o.idCov inner join compte as s on o.idCompte = s.idCompte where pointdepart = '" + depart + "'and pointarrive ='" + arriver + "'";
            using (reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {

                    ListViewModel list = new ListViewModel();
                    list.type_annonce = reader["type_annonce"].ToString();
                    list.pointarrive = reader["pointarrive"].ToString();
                    list.pointdepart = reader["pointdepart"].ToString();
                    list.datecov = reader["datecov"].ToString();
                    list.heuredepart = reader["heuredepart"].ToString();
                    list.textbtn = reader["textbtn"].ToString();
                    list.img = reader["img"].ToString();
                    listView2.Add(list);




                }
            }
            con.Close();


            return View(listView2);
        }


        public List<ListViewModel> cmdList1(List<ListViewModel> listView1)

        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM public.annonce_covoiturage as oc inner join publier as o on oc.idCov = o.idCov inner join compte as s on o.idCompte = s.idCompte";
            using (reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {

                    ListViewModel list = new ListViewModel();
                    list.type_annonce = reader["type_annonce"].ToString();
                    list.pointarrive = reader["pointarrive"].ToString();
                    list.pointdepart = reader["pointdepart"].ToString();
                    list.datecov = reader["datecov"].ToString();
                    list.heuredepart = reader["heuredepart"].ToString();
                    list.textbtn = reader["textbtn"].ToString();
                    list.img = reader["img"].ToString();
                    listView1.Add(list);




                }
            }
            con.Close();
            return listView1;
        }
        public List<ListViewModel> cmdList2(List<ListViewModel> listView2,string depart, string arrive)

        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM public.annonce_covoiturage as oc inner join publier as o on oc.idCov = o.idCov inner join compte as s on o.idCompte = s.idCompte where pointdepart = '"+ depart + "'and pointarrive ='"+ arrive + "'";
            using (reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {

                    ListViewModel list = new ListViewModel();
                    list.type_annonce = reader["type_annonce"].ToString();
                    list.pointarrive = reader["pointarrive"].ToString();
                    list.pointdepart = reader["pointdepart"].ToString();
                    list.datecov = reader["datecov"].ToString();
                    list.heuredepart = reader["heuredepart"].ToString();
                    list.textbtn = reader["textbtn"].ToString();
                    list.img = reader["img"].ToString();
                    listView2.Add(list);




                }
            }
            con.Close();
            return listView2;
        }

        public void connexionString()
        {
            con.ConnectionString = "server=localhost;Port=5432;Database=whee;User Id=postgres;Password=root";
        }
    }
}