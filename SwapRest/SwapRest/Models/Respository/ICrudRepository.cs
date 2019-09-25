using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapRest.Models.Respository
{
    public interface ICrudRepository<T>
    {
        bool Save(T t);
        bool Update(T t);
        bool Delete(T t);
        List<T> FindAll();
        T FindById(int? id);
    }
}
