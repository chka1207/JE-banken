using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace JE_Bank
{
    public partial class rasultat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Laddaresultat();
                resultat_db();
            }
        }

        public void Laddaresultat()
        {
            if (Session["resul"] != null)
            { 
            string resultat1 = Session["Resul"].ToString();
            string del1 = Session["del1"].ToString();
            string del2 = Session["del2"].ToString();
            string del3 = Session["del3"].ToString();
            resultat.InnerText = "Totalt resultat: " +resultat1 + " Del 1: " + del1 + " Del 2: " + del2 + " Del 3: " + del3;
            }
        }
        public void resultat_db()
        {
            
            Provklass p = new Provklass();
            p.HämtafrånDb("6");
            if (p.godkänd_kunskap == true)
            {
                lbkunskapG.Text = "Godkänd";
            }
            else
            {
                lbkunskapG.Text = "Underkänd";
            }
            if (p.gjort_licens == true)
            {
                lbLicensG.Text = "Godkänd";
            }
            else
            {
                lbLicensG.Text = "Underkänd";
            }
            lbkunskapD.Text = p.kunskap.ToShortDateString();
            lbLicensD.Text = p.licens.ToShortDateString();

        }

       
    }
}