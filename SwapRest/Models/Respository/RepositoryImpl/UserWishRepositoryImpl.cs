using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class UserWishRepositoryImpl : IUserWishRepository
    {
        private swapdb context;

        public UserWishRepositoryImpl()
        {
            context = new swapdb();
        }

        public bool Delete(User_wish t)
        {
            bool flag = true;
            try
            {
                context.User_wish.Remove(t);
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        public List<User_wish> FindAll()
        {
            throw new NotImplementedException();
        }

        public User_wish FindById(int? id)
        {
            return context.User_wish.Find(id);
        }

        public List<User_wish> FindByUser(int id)
        {
            return context.User_wish.Where(d => d.user_id == id).ToList();
        }

        public bool Save(User_wish t)
        {
            bool flag = false;
            try
            {
                context.Entry(t).State = EntityState.Added;
                context.SaveChanges();
                flag = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return flag;
        }

        public bool Update(User_wish t)
        {
            bool flag = false;
            try
            {
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
                flag = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return flag;
        }
    }
}