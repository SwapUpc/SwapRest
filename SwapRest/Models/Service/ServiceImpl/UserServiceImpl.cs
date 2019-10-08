using SwapRest.Models.Entities;
using SwapRest.Models.Service;
using SwapRest.Models.Respository.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Respository;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class UserServiceImpl : IUserService
    {
        private IUserRepository userRepo;
        private ILanguageRepository languageRepo;

        public UserServiceImpl()
        {
            userRepo = Factory.GetInstance().GetUserRepo();
            languageRepo = Factory.GetInstance().GetLanguageRepo();
        }

        public User Authentication(string email, string password)
        {
            return userRepo.Authentication(email, password);
        }

        public bool Delete(User t)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool ExitsEmail(string email)
        {
            return userRepo.ExitsEmail(email);
        }

        public User FindById(int? id)
        {
            return userRepo.FindById(id);
        }

        public bool Save(User t)
        {
            return userRepo.Save(t);
        }

        public bool Update(User t)
        {
            return userRepo.Update(t);
        }

        public User FindByEmail(string email)
        {
            return userRepo.FindByEmail(email);
        }

        public int VerifyRol(string token)
        {
            return userRepo.VerifyRol(token);
        }

        public int GetId(string token)
        {
            return userRepo.GetId(token);
        }

        public List<int> WantToTeach(int id)
        {
            List<int> wtt = new List<int>();
            List<int> lst = userRepo.WantToTeach(id);
            List<int> lstLng = languageRepo.WantToLearn(id);
            int n = lst.Count();
            int m = lstLng.Count();
            int p = 0;
            bool pass = false;

            for(int i = 0; i < n; i++)
            {
                pass = false;
                //Por cada usuario
                List<int> lstLngT = languageRepo.WantToTeach(lst[i]);
                p = lstLngT.Count();
                //Por cada lenguaje
                for(int j = 0; j < p; j++)
                {
                    int index = lstLngT[j];
                    for (int k = 0; k < m; k++)
                    {
                        if (index == lstLng[k])
                        {
                            wtt.Add(lst[i]);
                            pass = true;
                            break;
                        }    
                    }
                    if(pass)
                        break;
                }
            }
            return wtt;
        }
    }
}