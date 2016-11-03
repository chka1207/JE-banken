using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using System.Web;


namespace JE_Bank
{
    public class postgres
    {
        private NpgsqlConnection _conn;
        private NpgsqlCommand _cmd;
        private NpgsqlDataReader _dr;
        public DataTable _tablell = new DataTable();
        private string _fel;
        public static List<NpgsqlParameter> lista { get; set; }
        public postgres()
        {
             // Inlogg ändras i webconfig
            _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            try
            {
                _conn.Open();
            }
            catch (Exception ex)
            {
                _fel = ex.Message;
            }
        }
        public void SqlParameters(string sqlfraga, List<NpgsqlParameter> parametrar)
        {
            try
            {
                _cmd = new NpgsqlCommand(sqlfraga, _conn);
                _cmd.Parameters.AddRange(parametrar.ToArray());
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _fel = ex.Message;
            }

            finally
            {
                _conn.Close();
            }
        }
        public DataTable SqlFrågaParameters(string sqlfraga, List<NpgsqlParameter> parametrar)
        {
            try
            {
                _cmd = new NpgsqlCommand(sqlfraga, _conn);
                _cmd.Parameters.AddRange(parametrar.ToArray());
                _dr = _cmd.ExecuteReader();
                _tablell.Load(_dr);
                return _tablell;

            }
            catch (Exception ex)
            {
                _fel = ex.Message;
                return null;
            }

            finally
            {
                _conn.Close();
            }
        }
    }
}
