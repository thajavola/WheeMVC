using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using WheeMVC.Models;
using WheeMVC.Hash;
namespace WheeMVC.Controllers
{
    public class LoginController : Controller
    {
        NpgsqlConnection con = new NpgsqlConnection();
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlCommand cmd2 = new NpgsqlCommand();
        NpgsqlDataReader reader;
        NpgsqlDataReader reader2;
        HashFile hash = new HashFile();

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {

            return View();

        }
        public void connexionString()
        {
            con.ConnectionString = "server=localhost;Port=5432;Database=whee;User Id=postgres;Password=root";
        }
        [HttpPost]
        public ActionResult mLog(Login lg)
        {
            connexionString();
            con.Open();

            string emailEnter = lg.mail;
            string passwordEnter = lg.mdp;
            string passwordHash = hash.Hasher(passwordEnter);
            lg.mdp = passwordHash;

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM public.compte WHERE mail='" + emailEnter + "' AND mot_de_passe= '" + passwordHash + "'";
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                
                Session["idCompte"] = reader.GetString(0);
                Session["img"]= reader.GetString(9);
                Session["nom"]= reader.GetString(2);
                Session["prenom"]= reader.GetString(3);
                con.Close();
                return RedirectToAction("Index" ,"Accueil");

            }
            else
            {
                con.Close();
                return RedirectToAction("Login");

            }
        }
    }
}