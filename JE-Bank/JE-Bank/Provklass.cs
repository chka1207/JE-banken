using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Xml;

namespace JE_Bank
{
    public class Provklass
    {
        public int userID { get; set; }
        public string namn { get; set; }
        public string xmldatabas { get; set; }
        public bool gjort_licens { get; set; }
        public DateTime licens { get; set; }
        public DateTime kunskap { get; set; }
        public bool godkänd_kunskap { get; set; }

        public List<Provklass> HämtafrånDb(string pid)
        {
            postgres x = new postgres();
            List<Provklass> prov = new List<Provklass>();
            DataTable table = new DataTable();
            table=x.SqlFrågaParameters("select * from users where user_id=@par1", postgres.lista = new List<NpgsqlParameter>(){
                    new NpgsqlParameter("@par1", pid),});
            foreach (DataRow dr in table.Rows)
            {

                string licens,kunskap,gjort_licens,Godkänd_kunskap;
                

                Provklass t = new Provklass();
                t.userID = Convert.ToInt16(dr["user_id"].ToString());
                t.xmldatabas = dr["xml"].ToString();
                gjort_licens = dr["gjort_licens"].ToString();
                licens = dr["datum_licens"].ToString();
                kunskap = dr["datum_kunskap"].ToString();
                Godkänd_kunskap = dr["godkänd_kunskap"].ToString();
                t.licens = Convert.ToDateTime(licens);
                t.kunskap = Convert.ToDateTime(kunskap);
                t.godkänd_kunskap = Convert.ToBoolean(Godkänd_kunskap);
                t.gjort_licens = Convert.ToBoolean(gjort_licens);

                prov.Add(t);
            }

            return prov;
        }

        public void XmltillDatabas(int id, string xml)
        {
            userID = id;
            xmldatabas = xml;
            string user_id = Convert.ToString(id);

            postgres x = new postgres();
            x.SqlParameters("update users set xml = @par2 where user_id = @par1;", postgres.lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@par1", user_id),
                new NpgsqlParameter("@par2", xml)
            });
        }
        public XmlDocument DatabasTillXml(int user_id)
        {
            userID = user_id;
            string id = Convert.ToString(user_id);
            string xml;

            XmlDocument doc = new XmlDocument();

            postgres x = new postgres();
            x.SqlFrågaParameters("select xml from users where user_id = @par1;", postgres.lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@par1", id)
            });
            foreach(DataRow d in x._tablell.Rows)
            {
                doc.LoadXml(d["xml"].ToString());

            }
                        
            return doc;
        }
        public List<Provklass> HämtafrånDbAlla()
        {
            postgres x = new postgres();
            List<Provklass> prov = new List<Provklass>();
            DataTable table = new DataTable();
            table = x.SqlFrågaParameters("select * from users", postgres.lista = new List<NpgsqlParameter>(){});
            foreach (DataRow dr in table.Rows)
            {

                string licens, kunskap, gjort_licens, Godkänd_kunskap;


                Provklass t = new Provklass();
                t.userID = Convert.ToInt16(dr["user_id"].ToString());
                t.xmldatabas = dr["xml"].ToString();
                t.namn = dr["namn"].ToString();
                gjort_licens = dr["gjort_licens"].ToString();
                licens = dr["datum_licens"].ToString();
                kunskap = dr["datum_kunskap"].ToString();
                Godkänd_kunskap = dr["godkänd_kunskap"].ToString();
                if (string.IsNullOrEmpty(licens) == false)
                {
                    t.licens = Convert.ToDateTime(licens);
                }
                if (string.IsNullOrEmpty(kunskap) == false)
                {
                    t.kunskap = Convert.ToDateTime(kunskap);
                }
                if (string.IsNullOrEmpty(Godkänd_kunskap) == false)
                {
                    t.godkänd_kunskap = Convert.ToBoolean(Godkänd_kunskap);
                }
                if (string.IsNullOrEmpty(gjort_licens) == false)
                {
                    t.gjort_licens = Convert.ToBoolean(gjort_licens);
                }                           
                
                prov.Add(t);
            }

            return prov;
        }
        public void laddaUppResultat(int id, bool resultat, string typ)
        {
            userID = id;
            string user_id = Convert.ToString(id);
            
            if (typ == "25")
            {
               
                postgres x = new postgres();
                x.SqlParameters("update users set gjort_licens = @par4, datum_licens= @par5 where user_id = @par1;", postgres.lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@par1", user_id),
                new NpgsqlParameter("@par4", resultat),
                new NpgsqlParameter("@par5", DateTime.Now)

            });

            }
            else
            {
                
                postgres x = new postgres();
                x.SqlParameters("update users set godkänd_kunskap = @par4, datum_kunskap= @par5 where user_id = @par1;", postgres.lista = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter("@par1", user_id),
                new NpgsqlParameter("@par4", resultat),
                new NpgsqlParameter("@par5", DateTime.Now)

            });
            }

            
            

           
        }

    }
}