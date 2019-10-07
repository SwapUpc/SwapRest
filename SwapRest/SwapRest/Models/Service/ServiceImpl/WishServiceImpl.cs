using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class WishServiceImpl : IWishService
    {
        IWishRepository wishRepo;

        public WishServiceImpl()
        {
            wishRepo = Factory.GetInstance().GetWish();
        }

        public bool Delete(Wish t)
        {
            throw new NotImplementedException();
        }

        public List<Wish> FindAll()
        {
            throw new NotImplementedException();
        }

        public Wish FindById(int? id)
        {
            return wishRepo.FindById(id);
        }

        public bool Save(Wish t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Wish t)
        {
            throw new NotImplementedException();
        }
    }
}