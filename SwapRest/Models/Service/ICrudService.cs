using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.Service
{
    public interface ICrudService<T>
    {
        bool Save(T t);
        bool Update(T t);
        bool Delete(T t);
        List<T> FindAll();
        T FindById(int? id);
    }
}