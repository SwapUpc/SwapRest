using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class UserRepositoryImpl : IUserRepository
    {

        private swapdb context;

        public UserRepositoryImpl()
        {
            context = new swapdb();
        }

        public User Authentication(string email, string password)
        {
            User user = null;
            try
            {
                var lst = context.Users.Where(u => u.email == email && u.password == password && u.active == 1);
                if(lst.Count() > 0)
                {
                    user = lst.First();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return user;
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
            bool flag = false;
            try
            {
                var lst = context.Users.Where(u => u.email == email);
                if (lst.Count() > 0)
                {
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return flag;
        }

        public User FindById(int? id)
        {
            return context.Users.Find(id);
        }

        public bool Save(User t)
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

        public bool Update(User t)
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

        public User FindByEmail(string email)
        {
            User user = null;
            try
            {
                var lst = context.Users.Where(u => u.email == email);
                if (lst.Count() > 0)
                {
                    user = lst.First();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return user;
        }

        public int VerifyRol(string token)
        {
            int verifyRol = 0;
            try
            {
                if(context.Users.Where(u => u.token == token && u.active == 1 && u.rol_id == 1).ToList().Count() > 0)
                    verifyRol = 1;
                else if (context.Users.Where(u => u.token == token && u.active == 1 && u.rol_id == 2).ToList().Count() > 0)
                    verifyRol = 2;
                else if (context.Users.Where(u => u.token == token && u.active == 1 && u.rol_id == 3).ToList().Count() > 0)
                    verifyRol = 3;
                else
                    verifyRol = 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return verifyRol;
        }

        public int GetId(string token)
        {
            User user = context.Users.Where(d => d.token == token).ToList().First();
            return user.id;
        }

        public List<int> WantToTeach(int id)
        {
            List<int> lstInt = (from d in context.Users where d.rol_id == 3 && d.id != id select d.id).ToList();
            return lstInt;
        }
    }
}