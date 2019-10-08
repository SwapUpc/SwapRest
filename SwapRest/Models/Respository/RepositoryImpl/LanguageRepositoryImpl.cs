using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class LanguageRepositoryImpl : ILanguageRepository
    {
        private swapdb context;

        public LanguageRepositoryImpl()
        {
            context = new swapdb();
        }

        public bool Delete(Language t)
        {
            throw new NotImplementedException();
        }

        public List<Language> FindAll()
        {
            return context.Languages.ToList();
        }

        public Language FindById(int? id)
        {
            return context.Languages.Find(id);
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
            List<int> lstInt = (from d in context.User_wish where d.user_id == id && d.wish_id == 2 select d.language_id).ToList();
            //List<User_wish> lst = context.User_wish.Where(d => d.user_id == id && d.wish_id == 2).ToList();
            List<int> lstLanguage = new List<int>();
            Language lgn;
            int n = lstInt.Count();
            for (int i = 0; i < n; i++)
            {
                lgn = FindById(lstInt[i]);
                lstLanguage.Add(lgn.id);
            }
            return lstLanguage;
        }

        public List<int> WantToTeach(int id)
        {
            List<int> lstInt = (from d in context.User_wish where d.user_id == id && d.wish_id == 1 && d.level_id >= 3 select d.language_id).ToList();
            //List<User_wish> lst = context.User_wish.Where(d => d.user_id == id && d.wish_id == 1 && d.level_id >= 3).ToList();
            List<int> lstLanguage = new List<int>();
            Language lgn;
            int n = lstInt.Count();
            for (int i = 0; i < n; i++)
            {
                lgn = FindById(lstInt[i]);
                lstLanguage.Add(lgn.id);
            }
            return lstLanguage;
        }
    }
}