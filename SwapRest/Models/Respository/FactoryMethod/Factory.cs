using SwapRest.Models.Respository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.Respository.FactoryMethod
{
    public class Factory
    {
        private static Factory _instance = null;

        private Factory() {}

        public static Factory GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Factory();
            }
            return _instance;
        }

        public IUserRepository GetUserRepo()
        {
            return new UserRepositoryImpl();
        }

        public IUserWishRepository GetUserWishRepo()
        {
            return new UserWishRepositoryImpl();
        }

        public ILessonRepository GetLessonRepo()
        {
            return new LessonRepositoryImpl();
        }

        public ILanguageRepository GetLanguageRepo()
        {
            return new LanguageRepositoryImpl();
        }

        public ITaskRespository GetTaskRepo()
        {
            return new TaskRepositoryImpl();
        }

        public ICountryRespository GetCountryRepo()
        {
            return new CountryRepositoryImpl();
        }

        public IRolRepository GetRol()
        {
            return new RolRepositoryImpl();
        }

        public ILevelRepository GetLevel()
        {
            return new LevelRepositoryImpl();
        }

        public IWishRepository GetWish()
        {
            return new WishRepositoryImpl();
        }
    }
}