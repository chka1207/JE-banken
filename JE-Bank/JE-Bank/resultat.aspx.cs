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
            int del1 = Convert.ToInt16(Session["del1"].ToString());
            int del2 = Convert.ToInt16(Session["del2"].ToString());
            int del3 = Convert.ToInt16(Session["del3"].ToString());
                double del11;
                double del21;
                double del31;
                double total;

            if (resultat1 == "15")
                {
                    del11 = del1 / 5 * 100;
                    del21 = del2 / 5 * 100;
                    del31 = del3 / 5 * 100;
                    total = (del1 + del2 + del3) / 15 * 100;
                    
                }
            else
                {
                    del11 = del1 / 10 * 100;
                    del21 = del2 / 5 * 100;
                    del31 = del3 / 10 * 100;
                    total = (del1 + del2 + del3) / 25 * 100;
                }
            if (total> 69&& del11 > 59 && del21 >59 && del31 >59)
                {
                    resultat.InnerText = "GODKÄND";
                }
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