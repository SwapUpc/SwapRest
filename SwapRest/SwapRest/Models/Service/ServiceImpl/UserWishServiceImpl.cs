using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class UserWishServiceImpl : IUserWishService
    {
        private IUserWishRepository userWishRepo;

        public UserWishServiceImpl()
        {
            userWishRepo= Factory.GetInstance().GetUserWishRepo();
        }

        public bool Delete(User_wish t)
        {
            return userWishRepo.Delete(t);
        }

        public List<User_wish> FindAll()
        {
            throw new NotImplementedException();
        }

        public User_wish FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<User_wish> FindByUser(int id)
        {
            return userWishRepo.FindByUser(id);
        }

        public bool Save(User_wish t)
        {
            return userWishRepo.Save(t);
        }

        public bool Update(User_wish t)
        {
            throw new NotImplementedException();
        }
    }
}