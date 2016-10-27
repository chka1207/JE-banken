using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;
using System.Data;

namespace JE_Bank
{
    public class postgres
    {
        private NpgsqlConnection _conn;
        private NpgsqlCommand _cmd;
        private NpgsqlDataReader _dr;
        public DataTable _tablell;
        private string _fel;
        public static List<NpgsqlParameter> lista { get; set; }
        public postgres()
        {
            // db=vår databas
            // Inlogg ändras i appconfig
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