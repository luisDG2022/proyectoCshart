using DAO.Interfaces;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAO.Implementacion
{
    public class CategoriaImp : BaseImp,ICategoria
    {
        public int Delete(Categoria t)
        {
            query = @"UPDATE categoria SET estado=0, fechaActualizacion=CURRENT_TIMESTAMP,
                    IdUsuario=@idUsuario 
                    WHERE id=@id";

            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idUsuario", 1);//OJO
            command.Parameters.AddWithValue("@id", t.Id);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Categoria Get(byte id)
        {
            Categoria t = null;
            query = @"SELECT id, nombre, descripcion, estado, fechaRegistro, IFNULL(fechaActualizacion,CURRENT_TIMESTAMP), idUsuario
                    FROM categoria
                    WHERE id=@id";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count>0)
                {
                    t = new Categoria(byte.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), byte.Parse(table.Rows[0][3].ToString()), DateTime.Parse(table.Rows[0][4].ToString()), DateTime.Parse(table.Rows[0][5].ToString()), byte.Parse(table.Rows[0][6].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return t;
        }

        public int Insert(Categoria t)
        {
            query = @"INSERT INTO categoria (nombre, descripcion, idUsuario)
            VALUES(@nombre, @descripcion, @idUsuario)";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@idUsuario", 1);//OJO

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT id, nombre AS Categoria, descripcion AS Descripcion, fechaRegistro AS 'creado en:'
                    FROM categoria
                    WHERE estado=1
                    ORDER BY 2";
            MySqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update(Categoria t)
        {
            query = @"UPDATE categoria SET nombre=@nombre, descripcion=@descripcion, fechaActualizacion=CURRENT_TIMESTAMP,
                    idUsuario=@idUsuario
                    WHERE id=@id";

            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombre", t.Nombre);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@idUsuario", 1);//ojo
            command.Parameters.AddWithValue("@id", t.Id);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
