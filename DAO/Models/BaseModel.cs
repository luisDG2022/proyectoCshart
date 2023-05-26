using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class BaseModel
    {
        public byte Estado { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAactualizacion { get; set; }
        public byte IdUsuario { get; set; }

        public BaseModel()
        {

        }

        public BaseModel(byte estado, DateTime fechaRegistro, DateTime fechaAactualizacion, byte idUsuario)
        {
            Estado = estado;
            FechaRegistro = fechaRegistro;
            FechaAactualizacion = fechaAactualizacion;
            IdUsuario = idUsuario;
        }

        public BaseModel(byte idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}
