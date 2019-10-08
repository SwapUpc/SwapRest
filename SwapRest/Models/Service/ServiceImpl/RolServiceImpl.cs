using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class RolServiceImpl : IRolService
    {
        IRolRepository rolRepo;

        public RolServiceImpl()
        {
            rolRepo = Factory.GetInstance().GetRol();
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
            return rolRepo.FindById(id);
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