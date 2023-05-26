using DAO.Interfaces;
using DAO.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO.Implementacion
{
    public class UsuarioImp : BaseImp, IUsuario
    {
        public int Delete(Usuario t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Usuario t)
        {
            throw new NotImplementedException();
        }

        public DataTable login(string nombreUsuario, string contrasenia)
        {
            //DataTable dt = null;
            query = @"SELECT id, CONCAT(nombres,' ',primerApellido), rol, nombreUsuario
                    FROM usuario
                    WHERE estado=1 AND nombreUsuario=@nombreUsuario AND contrasenia=md5(@contrasenia)";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            command.Parameters.AddWithValue("@contrasenia", contrasenia);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                //mensaje();
                throw ex;
               
            }
            //return dt;
        }
        public string mensaje() {
            return "amigo error";
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
