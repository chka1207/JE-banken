using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace JE_Bank
{
    public partial class rasultat : System.Web.UI.Page
    {
        List<Fråga> lista = new List<Fråga>();
        private Dictionary<string, Control> fDynamicControls = new Dictionary<string, Control>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                laddaProv();
                Laddaresultat();
                resultat_db();
            }
           
        }

        public void Laddaresultat()
        {
            if (Session["resul"] != null)
            { 
            string resultat1 = Session["Resul"].ToString();
            double del1 = Convert.ToDouble(Session["del1"].ToString());
            double del2 = Convert.ToDouble(Session["del2"].ToString());
            double del3 = Convert.ToDouble(Session["del3"].ToString());
           
            double total = del1 + del2 + del3;
                double total1;
                double del11, del21, del31;


                lbresultat1.Visible = true;
                lbresultat2.Visible = true;
                lbresultat3.Visible = true;
                lbresultat4.Visible = true;
                lbresultat5.Visible = true;

                if (resultat1 == "15")
                {
                    del11 = del1 / 5 * 100;
                    del21 = del2 / 5 * 100;
                    del31 = del3 / 5 * 100;
                    total1 = total / 15 * 100;
                    
                }
            else
                {
                    del11 = del1 / 10 * 100;
                    del21 = del2 / 5 * 100;
                    del31 = del3 / 10 * 100;
                    total1 = total / 25 * 100;
                }
            if (total1> 69&& del11 > 59 && del21 >59 && del31 >59)
                {
                    lbresultat1.Text = "GODKÄND";

                }
                else
                {
                    lbresultat1.Text = "INTE GODKÄND";
                }
                del11 = Math.Round(del11, 2);
                del21 = Math.Round(del21, 2);
                del31 = Math.Round(del21, 2);
                total1 = Math.Round(total1, 2);

            lbresultat2.Text = "Del 1: "+del1 + "st  " + del11 + "%";
            lbresultat3.Text = "Del 2: " + del2 + "st  " + del21 + "%";
            lbresultat4.Text = "Del 3: " + del3 + "st  " + del31 + "%";
            lbresultat5.Text = "Totalt: " + total + "st  " + total1 + "%";
                
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

        public List<Fråga> XmlToList(XmlDocument xml_doc)
        {
            
            
            List<Fråga> x = new List<Fråga>();


            XmlDocument doc = xml_doc;
            
            XmlNodeList provdel = doc.SelectNodes("/kunskapsprov/provdel/fråga");


            foreach (XmlNode node in provdel)
            {
                Fråga f = new Fråga();

                f.fråga = node["text"].InnerText;
                f.provdel = node.ParentNode["namn"].InnerText;
                f.provdelID = Convert.ToUInt16(node.ParentNode.Attributes["ID"].InnerText);
                f.frågaID = Convert.ToUInt16(node.Attributes["id"].InnerText);
                f.bild = node["text"].Attributes["bild"].InnerText;
                f.svar1 = node.ChildNodes[1].ChildNodes[0].InnerText;
                f.svar2 = node.ChildNodes[1].ChildNodes[1].InnerText;
                f.svar3 = node.ChildNodes[1].ChildNodes[2].InnerText;
                f.svar4 = node.ChildNodes[1].ChildNodes[3].InnerText;
                f.user_svar = node.ChildNodes[2].ChildNodes[0].InnerText;


                if (node.ChildNodes[1].ChildNodes[0].Attributes["id"].InnerText == "rätt")
                {
                    f.rättSvar = node.ChildNodes[1].ChildNodes[0].InnerText;
                }
                if (node.ChildNodes[1].ChildNodes[1].Attributes["id"].InnerText == "rätt")
                {
                    f.rättSvar = node.ChildNodes[1].ChildNodes[1].InnerText;
                }
                if (node.ChildNodes[1].ChildNodes[2].Attributes["id"].InnerText == "rätt")
                {
                    f.rättSvar = node.ChildNodes[1].ChildNodes[2].InnerText;
                }
                if (node.ChildNodes[1].ChildNodes[3].Attributes["id"].InnerText == "rätt")
                {
                    f.rättSvar = node.ChildNodes[1].ChildNodes[3].InnerText;
                }

                x.Add(f);
            }


            return x;
        }

        public void laddaProv()
        {
            Provklass p = new Provklass();
            p.userID = 3; //hårdkodat
            XmlDocument doc = p.DatabasTillXml(p.userID);
            lista = XmlToList(doc);

            string fråga;
            for (int i = 0; i < lista.Count; i++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.ID = lista[i].provdelID.ToString() + i.ToString();
                if (lista[i].bild != "")
                {
                    string bild = "<img src='" + lista[i].bild + "'>";
                    fråga = "<br />" + lista[i].provdel + "<br />" + bild + "<br/>" + lista[i].fråga + "<br />" + "Rätt svar: " + lista[i].rättSvar + "<br/>" + "Ditt svar: " + lista[i].user_svar;
                }
                else
                {
                    fråga = "<br />" + lista[i].provdel + "<br />" + lista[i].fråga + "<br />" + "Rätt svar: " + lista[i].rättSvar + "<br/>" + "Ditt svar: " + lista[i].user_svar;
                }
                div.InnerHtml = fråga;
                test.Controls.Add(div);
               

            }
        }



    }
}