using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace JE_Bank
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            laddaLista();
        }
        private void laddaLista()
        {
            
            List<Provklass> lista = new List<Provklass>();
            Provklass p = new Provklass();
            lista=p.HämtafrånDbAlla();
            for (int i = -1; i < lista.Count; i++)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    HtmlGenericControl div2 = new HtmlGenericControl("div1");
                
                    
                for (int r = 0; r < 5; r++)
                {
                    Label lb = new Label();
                    Label lbh = new Label();

                    switch (r)
                    {
                        case 0:
                            lbh.Text = "Namn     ";
                            if (i > 0)
                            {
                                lb.Text = lista[i].namn;
                            }
                            break;
                        case 1:
                            string godkänd = "";
                            if (i > 0)
                            {
                                if (lista[i].godkänd_kunskap == true)
                                {
                                    godkänd = "GODKÄND";
                                }
                                if (lista[i].godkänd_kunskap == false)
                                {
                                    godkänd = "EJ GODKÄND";
                                }
                            }
                            lbh.Text = "Kunskapsprov";
                            lb.Text = godkänd;
                            break;
                        case 2:
                            lbh.Text = "Datum     ";
                            if (i > 0)
                            {
                                lb.Text = lista[i].kunskap.ToShortDateString();
                            }
                            break;
                        case 3:
                            string godkänd1 = "";
                            if (i >0) { 
                                if (lista[i].gjort_licens == true)
                                {
                                    godkänd1 = "GODKÄND";
                                }
                                if (lista[i].gjort_licens == false)
                                {
                                    godkänd1 = "EJ GODKÄND";
                                }
                            }
                            lbh.Text = "Licensprov";
                            lb.Text = godkänd1;
                            break;
                        case 4:
                            lbh.Text = "Datum      ";
                            if (i > 0)
                            {
                                lb.Text = lista[i].licens.ToShortDateString();
                            }
                            break;
                    }
                    if (i == -1)
                    {
                        div2.Controls.Add(lbh);
                        lbh.Attributes.Add("Class", "text");
                    }
                    else
                    {
                        lb.Attributes.Add("Class", "text");
                        div2.Controls.Add(lb);
                    }

                }
                    
                    div.Controls.Add(div2);
                    listan.Controls.Add(div);
                }
          
               
            
            
        }
    }

}