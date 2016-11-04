using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace JE_Bank
{
    public partial class licensprov : System.Web.UI.Page
    {
        List<Fråga> lista = new List<Fråga>();
        private Dictionary<string, Control> fDynamicControls = new Dictionary<string, Control>();
        protected void Page_Init(object sender, EventArgs e)
        {

            laddaFragor();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {

            }
            
        }

        public void laddaFragor()
        {
            lista = XmlToList();

            string fråga;
            for (int i = 0; i < lista.Count; i++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.ID = lista[i].provdelID.ToString() + i.ToString();
                if (lista[i].bild != "")
                {
                    string bild = "<img src='" + lista[i].bild + "'>";
                    fråga = "<br />" + lista[i].provdel + "<br />" + bild + "<br/>" + lista[i].fråga + "<br />";
                }
                else
                {
                    fråga = "<br />" + lista[i].provdel + "<br />" + lista[i].fråga + "<br />";
                }
                div.InnerHtml = fråga;
            

                for (int r = 0; r < 4; r++)
                {

                    RadioButton radio = new RadioButton();
                    radio.ID = "rd" + i.ToString() + r.ToString();
                    radio.GroupName = "gn" + i.ToString();
                    radio.CssClass = "fråga";
                    string text = "";
                    if (r == 0)
                    {
                        text = lista[i].svar1;
                    }
                    if (r == 1)
                    {
                        text = lista[i].svar2;
                    }
                    if (r == 2)
                    {
                        text = lista[i].svar3;
                    }
                    if (r == 3)
                    {
                        text = lista[i].svar4;
                    }
                    radio.Text = text;
                    div.Controls.Add(radio);
                }
                
                test.Controls.Add(div);
              

            }
        }

        
        public List<Fråga> XmlToList()
        {
            string path;
            List<Fråga> x = new List<Fråga>();
            path = Server.MapPath(@"xml\licens.xml");
            

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList provdel = doc.SelectNodes("/licensprov/provdel/fråga");


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

        protected void Ratta_Click(object sender, EventArgs e)
        {
            Provklass p = new Provklass();
            int user_id = 0;
            int resultat = 0;
            int del1 = 0, del2 = 0, del3 = 0;
            ContentPlaceHolder MainC = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

            for (int i = 0; i < lista.Count; i++)
            {

                for (int r = 0; r < 4; r++)
                {
                    var rd1 = (RadioButton)MainC.FindControl("test").FindControl("rd" + i.ToString() + r.ToString());
                    if (rd1.Checked)
                    {
                        if (rd1.Text == lista[i].rättSvar && 1 == lista[i].provdelID)
                        {
                            del1++;
                        }
                        if (rd1.Text == lista[i].rättSvar && 2 == lista[i].provdelID)
                        {
                            del2++;
                        }
                        if (rd1.Text == lista[i].rättSvar && 3 == lista[i].provdelID)
                        {
                            del3++;
                        }

                        p.xmldatabas = skrivTillXml(rd1.Text, lista[i].provdelID, lista[i].frågaID, ref user_id);
                    }
                }
            }
            p.XmltillDatabas(user_id, p.xmldatabas);
            resultat = del1 + del2 + del3;
            Session["Resul"] = lista.Count;
            Session["del1"] = del1;
            Session["del2"] = del2;
            Session["del3"] = del3;
            Response.Redirect("~/resultat.aspx");

        }

        public string skrivTillXml(string valt_svar, int provdelID, int frågaID, ref int user_id)
        {
            Provklass p = new Provklass();
            p.userID = 3; // hårdkodat

            user_id = p.userID;
            string path = Server.MapPath(@"xml\licens.xml");
            string path2 = Server.MapPath(@"xml\" + p.userID + ".xml");
            XmlDocument doc = new XmlDocument();

            if (path2 == null || frågaID == 1)
            {
                doc.Load(path);
            }
            else
            {
                doc.Load(path2);
            }

            XmlNode root = doc.DocumentElement;

            XmlElement user_svar = doc.CreateElement("user_svar");
            XmlNodeList node = doc.SelectNodes("/licensprov/provdel[@ID='" + provdelID + "']/fråga[@id='" + frågaID + "']");
            user_svar.InnerText = valt_svar;
            node[0].AppendChild(user_svar);

            string nyttxml = Server.MapPath(@"xml\" + p.userID + ".xml");

            doc.Save(nyttxml);
            p.xmldatabas = doc.OuterXml;

            return p.xmldatabas;

        }
    }
}