using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;
using SwapRest.Models.Respository.RepositoryImpl;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class CountryServiceImpl : ICountryService
    {
        ICountryRespository countryServ;

        public CountryServiceImpl()
        {
            countryServ = Factory.GetInstance().GetCountryRepo();
        }

        public bool Delete(Country t)
        {
            throw new NotImplementedException();
        }

        public List<Country> FindAll()
        {
            return countryServ.FindAll();
        }

        public Country FindById(int? id)
        {
            return countryServ.FindById(id);
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