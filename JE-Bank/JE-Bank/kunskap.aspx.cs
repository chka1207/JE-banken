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
                div.InnerHtml = f.provdel +" " + f.fråga;
                test.Controls.Add(div);
            }
        }


        public List<Fråga> XmlToList()
        {
            List<Fråga> x = new List<Fråga>();

            string path = Server.MapPath(@"xml\kunskap.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList provdel = doc.SelectNodes("/kunskapsprov/provdel");
            XmlNodeList frågan = doc.SelectNodes("/kunskapsprov/provdel/fråga");

            foreach (XmlNode node in provdel)
            {
                Fråga f = new Fråga();
                f.provdel = node["namn"].InnerText;
                foreach (XmlNode node2 in frågan)
                {
                    
                    f.fråga = node2["text"].InnerText;
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
    }
}

    