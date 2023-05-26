using DAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IUsuario:IBase<Usuario>
    {
        DataTable login(string nombreUsuario, string contrasenia);

        
    }
}
