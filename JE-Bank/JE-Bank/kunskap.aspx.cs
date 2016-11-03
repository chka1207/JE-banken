using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Xml;

namespace JE_Bank
{
    public partial class kunskap : System.Web.UI.Page
    {
        List<Fråga> frågor = new List<Fråga>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    //första laddning
            //}
            //else
            //{
            //    //postback
            //}

            //foreach (Fråga f in frågor)
            //{
            //    HtmlGenericControl x = new HtmlGenericControl("div");
            //    x.InnerHtml = f.provdel + "<br>" + f.bild + "< br >" +
            //        f.fråga + "< br >" + f.svar1 + "< br >" + f.svar2 +
            //        "< br >" + f.svar3 + "< br >" + f.svar4;

            //    test.Controls.Add(x);
            //}

            //GetXml();

            AppendFrågor(XmlToList());
            
        }
        public void GetXml()
        {
            string frågor = "";

            string path = Server.MapPath(@"xml\kunskap.xml");

            XmlTextReader hämtaxml = new XmlTextReader(path);

            while (hämtaxml.Read())
            {
                switch (hämtaxml.Name)
                {
                    case "bild":
                        frågor += hämtaxml.ReadString() +" ";
                        break;
                }
            }

            test.InnerHtml = frågor;
        }
        public void AppendFrågor(List<Fråga> frågelista)
        {
            foreach (Fråga f in frågelista)
            {
                                               
                HtmlGenericControl div = new HtmlGenericControl("div");
                if (f.bild != "")
                {
                    string bild = "<img src='" + f.bild + "'>";

                    div.InnerHtml = "<br>" + f.provdel + " " + f.fråga + " " + bild + "<br>" + f.svar1 + "<br>" + f.svar2 + "<br>" + f.svar3 + "<br>" + f.svar4;
                }
                else
                {
                    div.InnerHtml = "<br>" + f.provdel + " " + f.fråga + "<br>" + f.svar1 + "<br>" + f.svar2 + "<br>" + f.svar3 + "<br>" + f.svar4;
                }

                test.Controls.Add(div);
            }

           
        }


        public List<Fråga> XmlToList()
        {
            List<Fråga> x = new List<Fråga>();

            string path = Server.MapPath(@"xml\kunskap.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList provdel = doc.SelectNodes("/kunskapsprov/provdel/fråga");
            

            foreach (XmlNode node in provdel)
            {
                Fråga f = new Fråga();

                f.fråga = node["text"].InnerText;
                f.provdel = node.ParentNode["namn"].InnerText;
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

            //List<Fråga> testlista = (from e in doc.Load(@"xml\kunskap.xml").Root.Elements("kunskapsprov")
            //                         select new Fråga
            //                         {
            //                             provdel = (string).e.Element("namn"),
            //                             fråga = (string).e.Element("text")
            //                         }).ToList(); 

            return x;
        }

        //public void skrivTillXml()
        //{
        //    Provklass p = new Provklass();
        //    p.userID = 1; // ska komma från click_event
        //    string path = Server.MapPath(@"xml\kunskap.xml");
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(path);
        //    XmlNode root = doc.DocumentElement;

        //    XmlElement user_svar = doc.CreateElement("user_svar");
        //    XmlNodeList node = doc.SelectNodes("/kunskapsprov/provdel/fråga/svarsalternativ");
        //    user_svar.InnerText = ""

        //    nytt.InnerText = "Test"; //den data som ska lagras i elementet
        //    barn.InnerText = "barntest";
        //    nytt.AppendChild(barn);

        //    root.AppendChild(nytt);
        //    string nyttxml = Server.MapPath(@"xml\" + p.userID + ".xml");

        //    doc.Save(nyttxml);
        //    p.xmldatabas = doc.ToString();
            
        //}
    }
}

    