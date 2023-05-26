using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Usuario:BaseModel
    {
        public string Id { get; set; }
        public string Ci { get; set; }


        
        public string NombreUsuario { get; set; }
        public string password { get; set; }




    }
   
}
