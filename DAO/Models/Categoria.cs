using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Categoria:BaseModel
    {

        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(string nombre, string descripcion, byte idUsuario):base(idUsuario)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Categoria(byte id, string nombre, string descripcion, byte estado, DateTime fechaRegistro, DateTime fechaAactualizacion, byte idUsuario)
            :base(estado,fechaRegistro,fechaAactualizacion,idUsuario)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
