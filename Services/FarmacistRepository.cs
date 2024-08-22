using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using FunctiiSQL;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Web.UI.HtmlControls;
using ClassLibrary1;
using System.Web.Helpers;

namespace WebAPI.Services
{
    public class FarmacistRepository
    {
        Functii fct = new Functii();
        ErrorLogs err = new ErrorLogs();
        /*public Farmacist[] GetAllFarmacisti()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Farmacist[])ctx.Cache[CacheKey];
            }

            return new Farmacist[]
                {
            new Farmacist
            {
                ID=0,
                Nume = "Placeholder",
                Email="Placeholder",
                Judet="Placeholder",
                Localitate="Placeholder",
               Telefon="Placeholder",
               Varsa=0
            }
                };*/
        public Farmacist[] GetAllFarmacisti()
        {
            Farmacist[] farmacisti = new Farmacist[] { };
            int ID = 0;
            string Nume = "";
            int Varsta = 0;
            string Email = "";
            string Telefon = "";
            string Localitate = "";
            string Judet = "";
            DataTable dt = new DataTable();
    
                dt = fct.SelectFarmacisti();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    Nume = dt.Rows[i]["Nume"].ToString().Trim();
                    Varsta = Convert.ToInt32(dt.Rows[i]["Varsta"]);
                    Email = dt.Rows[i]["Email"].ToString().Trim();
                    Telefon = dt.Rows[i]["Telefon"].ToString().Trim();
                    Localitate = dt.Rows[i]["Localitate"].ToString().Trim();
                    Judet = dt.Rows[i]["Judet"].ToString().Trim();
                    Farmacist farmacist = new Farmacist(ID, Nume, Varsta, Email, Telefon, Localitate, Judet);
                    Array.Resize(ref farmacisti, farmacisti.Length + 1);
                    farmacisti[farmacisti.Length - 1] = farmacist;
                }
                return farmacisti;
            

        
        }
        //private const string CacheKey = "FarmacistStore";
        public bool SaveFarmacist(Farmacist farmacist)
        {
            if (fct.AdaugaFarmacist(farmacist) == true)
                return true;
            else
                return false;
        }
                    /*int ID = 0;
            string Nume = "";
            int Varsta = 0;
            string Email = "";
            string Telefon = "";
            string Localitate = "";
            string Judet = "";
            Farmacist farmacist = new Farmacist();
            try
            {
                ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                Nume = dt.Rows[i]["Nume"].ToString().Trim();
                Varsta = Convert.ToInt32(dt.Rows[i]["Varsta"]);
                Email = dt.Rows[i]["Email"].ToString().Trim();
                Telefon = dt.Rows[i]["Telefon"].ToString().Trim();
                Localitate = dt.Rows[i]["Localitate"].ToString().Trim();
                Judet = dt.Rows[i]["Judet"].ToString().Trim();
                if (ID != 0 && Nume != "" && Varsta != 0 && Email != "" && Telefon != "" && Localitate != "" && Judet != "")
                {
                    farmacist = new Farmacist(ID, Nume, Varsta, Email, Telefon, Localitate, Judet);
                    return true;
                }
                else return false;
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        return false;
    */
    }
}