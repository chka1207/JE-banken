using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JE_Bank
{
    public partial class rasultat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string resultat1 = Session["Resul"].ToString();
            string del1 = Session["del1"].ToString();
            string del2 = Session["del2"].ToString();
            string del3 = Session["del3"].ToString();

            resultat.InnerText = resultat1 +" "+ del1 +" "+del2+" "+del3;
        }
    }
}