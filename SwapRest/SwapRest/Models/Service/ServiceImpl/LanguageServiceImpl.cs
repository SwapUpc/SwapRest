using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class LanguageServiceImpl : ILanguageService
    {
        ILanguageRepository languageRepo;

        public LanguageServiceImpl()
        {
            languageRepo = Factory.GetInstance().GetLanguageRepo();
        }

        public bool Delete(Language t)
        {
            throw new NotImplementedException();
        }

        public List<Language> FindAll()
        {
            throw new NotImplementedException();
        }

        public Language FindById(int? id)
        {
            return languageRepo.FindById(id);
        }

        public bool Save(Language t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Language t)
        {
            throw new NotImplementedException();
        }

        public List<int> WantToLearn(int id)
        {
            return languageRepo.WantToLearn(id);
        }

        public List<int> WantToTeach(int id)
        {
            return languageRepo.WantToTeach(id);
        }
    }
}