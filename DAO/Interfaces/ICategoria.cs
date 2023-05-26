using DAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ICategoria:IBase<Categoria>
    {
        //DATA...
        Categoria Get(byte id);
 
    }
}
