using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class CountryRepositoryImpl : ICountryRespository
    {
        private swapdb context;
        
        public CountryRepositoryImpl()
        {
            context = new swapdb();
        }

        public bool Delete(Country t)
        {
            throw new NotImplementedException();
        }

        public List<Country> FindAll()
        {
            throw new NotImplementedException();
        }

        public Country FindById(int? id)
        {
            return context.Countries.Find(id);
        }

        public bool Save(Country t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Country t)
        {
            throw new NotImplementedException();
        }
    }
}