﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace JE_Bank
{
    public partial class frågor : System.Web.UI.Page
    {
        List<Fråga> lista = new List<Fråga>();
        private Dictionary<string, Control> fDynamicControls = new Dictionary<string, Control>();
        protected void Page_Init(object sender, EventArgs e)
        {
          
               laddaFragor();
       
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //ContentPlaceHolder MainC = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            
            //var rd1 = (RadioButton)MainC.FindControl("test").FindControl("banan");
            //rd1.Text = "hejigen";
            if (!IsPostBack)
            {

            }
           // lista = XmlToList();
        }

        public void laddaFragor()
        {
            lista = XmlToList();
            
            string fråga;
            for (int i = 0; i < lista.Count; i++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                //if (lista[i].provdel)
                //{

                //}
                //div.ID= 
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
                    radio.ID = "rd"+i.ToString()+r.ToString();
                    radio.GroupName = "gn"+i.ToString();
                    string text ="";
                    if(r ==0)
                    {
                        text =lista[i].svar1;
                    }
                    if (r == 1)
                    {
                        text = lista[i].svar2;
                    }
                    if (r == 2)
                    {
                        text = lista[i].svar3;
                    }
                    if (r== 3)
                    {
                        text = lista[i].svar4;
                    }
                    radio.Text = text;
                    div.Controls.Add(radio);
                }
                test.Controls.Add(div);




                //HtmlInputRadioButton rd1 = new HtmlInputRadioButton();
                //HtmlGenericControl rd11 = new HtmlGenericControl("span");
                //HtmlInputRadioButton rd2 = new HtmlInputRadioButton();
                //HtmlGenericControl rd22 = new HtmlGenericControl("span");
                //HtmlInputRadioButton rd3 = new HtmlInputRadioButton();
                //HtmlGenericControl rd33 = new HtmlGenericControl("span");
                //HtmlInputRadioButton rd4 = new HtmlInputRadioButton();
                //HtmlGenericControl rd44 = new HtmlGenericControl("span");


                //div.Attributes.Add("Id","gurka");
                //rd1.ID = "rd1"+i.ToString();
                //rd2.Attributes.Add("Id",lista[i].svar2);
                //rd3.Attributes.Add("Id", lista[i].svar3  );
                //rd4.Attributes.Add("Id", lista[i].svar4  );
                //rd1.Attributes.Add("name", lista[i].fråga+i);
                //rd2.Attributes.Add("name", lista[i].fråga+i);
                //rd3.Attributes.Add("name", lista[i].fråga+i);
                //rd4.Attributes.Add("name", lista[i].fråga+i);
                
                ////  "<input type='radio' id='" + lista[i].svar2 + "'name='radiobutton' value='" + lista[i].svar2 +"'>" + lista[i].svar2 + "<br />" + 
                ////  "<input type='radio' id='" + lista[i].svar3 + "'name='radiobutton' value='" + lista[i].svar3 +"'>" + lista[i].svar3 + "<br />" + 
                ////  "<input type='radio' id='" + lista[i].svar4 + "'name='radiobutton' value='" + lista[i].svar4 +"'>" + lista[i].svar4 + "<br />" + 
                ////  "<br /> </form>";

                //rd11.InnerText = lista[i].svar1;
                //rd22.InnerText = lista[i].svar2;
                //rd33.InnerText = lista[i].svar3;
                //rd44.InnerText = lista[i].svar4;
                //div.InnerHtml = fråga;
               
                //div.Controls.Add(rd1);
                //div.Controls.Add(rd11);
                //div.Controls.Add(rd2);
                //div.Controls.Add(rd22);
                //div.Controls.Add(rd3);
                //div.Controls.Add(rd33);
                //div.Controls.Add(rd4);
                //div.Controls.Add(rd44);
                //test.Controls.Add(div);
                
                
                
            }
        }

    public void test1()
        {
            Fråga f = new Fråga();
            f.provdel = "Etik";
            f.fråga = "vad är grus?";
            f.svar1 = "jesus";
            f.svar2 = "kul";
            f.svar3 = "hajk";
            f.svar4 = "baloba";
            Fråga f1 = new Fråga();
            lista.Add(f);
            f1.provdel = "Etik2";
            f1.fråga = "vad är grus?2";
            f1.svar1 = "jesus2";
            f1.svar2 = "kul2";
            f1.svar3 = "hajk2";
            f1.svar4 = "baloba2";
            lista.Add(f1);
            Fråga f2 = new Fråga();
            f2.provdel = "Etik3";
            f2.fråga = "vad är grus?3";
            f2.svar1 = "jesus2";
            f2.svar2 = "kul2";
            f2.svar3 = "hajk2";
            f2.svar4 = "baloba2";
            lista.Add(f2);
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


            return x;
        }

        protected void Ratta_Click(object sender, EventArgs e)
        {
            int resultat = 0;
            ContentPlaceHolder MainC = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");

            for (int i = 0; i < lista.Count; i++)
            {
                for (int r = 0; r < 4; r++)
                {
                    var rd1 = (RadioButton)MainC.FindControl("test").FindControl("rd"+i.ToString()+r.ToString());
                    if(rd1.Checked)
                    {
                        if(rd1.Text== lista[i].rättSvar)
                        {
                            resultat++;
                        }
                    }
                }
            }
            

        }
       


    }
}