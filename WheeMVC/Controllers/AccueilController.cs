using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Data;
using WheeMVC.Models;


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
            List<ListViewModel> listViewF = new List<ListViewModel>();

            connexionString();
            
            cmdList1(listView1);
            cmdList2(listView2);



            listViewF = (List<ListViewModel>)listView1.Union(listView2).ToList();

            return View(listViewF);
            

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
        public List<ListViewModel> cmdList2(List<ListViewModel> listView2)

        {
            con.Open();
            cmd2.Connection = con;
            cmd2.CommandText = "SELECT * FROM public.compte WHERE idCompte='"+id+"'";
            using (reader2 = cmd2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    ListViewModel list = new ListViewModel();
                    list.imgP = reader2.GetString(9);
                    list.nomP = reader2.GetString(2);
                    list.prenomP = reader2.GetString(3);
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