using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IBase<T>//para genericos, Categoria y Cliente
    {
        int Delete(T t);
        int Insert(T t);
        int Update(T t);
        DataTable Select();
    }
}
