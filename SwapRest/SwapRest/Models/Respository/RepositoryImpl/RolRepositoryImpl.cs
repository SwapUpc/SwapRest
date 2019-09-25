using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class RolRepositoryImpl : IRolRepository
    {
        private swapdb context;

        public RolRepositoryImpl()
        {
            context = new swapdb();
        }

        public bool Delete(Rol t)
        {
            throw new NotImplementedException();
        }

        public List<Rol> FindAll()
        {
            throw new NotImplementedException();
        }

        public Rol FindById(int? id)
        {
            return context.Roles.Find(id);
        }

        public bool Save(Rol t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rol t)
        {
            throw new NotImplementedException();
        }
    }
}