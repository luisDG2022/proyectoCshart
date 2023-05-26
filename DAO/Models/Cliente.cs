using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Cliente:BaseModel
    {
        

        public short Id { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }

        //insert
        public Cliente(string nit, string razonSocial, byte idUsuario)
            :base(idUsuario)
        {
            Nit = nit;
            RazonSocial = razonSocial;
        }
        //get
        public Cliente(short id, string nit, string razonSocial, byte estado, DateTime fechaRegistro, DateTime fechaAactualizacion, byte idUsuario)
            :base(estado, fechaRegistro, fechaAactualizacion, idUsuario)
        {
            Id = id;
            Nit = nit;
            RazonSocial = razonSocial;
        }
    }
}
