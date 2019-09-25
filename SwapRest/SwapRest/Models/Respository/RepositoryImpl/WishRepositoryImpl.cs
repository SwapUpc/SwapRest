using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class WishRepositoryImpl : IWishRepository
    {
        private swapdb context;

        public WishRepositoryImpl()
        {
            context = new swapdb();
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
            return context.Wishes.Find(id);
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