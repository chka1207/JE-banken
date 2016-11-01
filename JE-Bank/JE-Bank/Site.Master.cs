using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace JE_Bank
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            // Switchcase som styr active i menyn
            string thisURL = this.Page.GetType().Name.ToString();
            switch (thisURL)
            {
                case "index_aspx":
                    hem.Attributes.Add("class", "active");
                    break;
                case "prov_aspx":
                    Lprov.Attributes.Add("class", "active");
                    break;
                case "resultat_aspx":
                    Lresultat.Attributes.Add("class", "active");
                    break;
            }
        }

        protected void change_Click(object sender, EventArgs e)
        {

        }
    }
}