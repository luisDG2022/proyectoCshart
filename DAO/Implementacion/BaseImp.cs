using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAO.Implementacion
{
    public class BaseImp
    {
        string connectionString = @"server=localhost;database=bdincos2023;Uid=root;pwd=1234;Port=3306";
        public string query="";
        public MySqlCommand CreateBasicCommand() {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand comannd = new MySqlCommand();
            comannd.Connection = connection;
            return comannd;
        }
        public MySqlCommand CreateBasicCommand(String query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand comannd = new MySqlCommand(query,connection);
            return comannd;
        }
        public int ExecuteBasicCommand(MySqlCommand command) {//insert update delete
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                command.Connection.Close();
            }
        }

        public DataTable ExecuteDataTableCommand(MySqlCommand command) {
            DataTable dt = new DataTable();
            try
            {
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                command.Connection.Close();
            }
            return dt;
        }
    }
}
