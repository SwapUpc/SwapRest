using SwapRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class LevelRepositoryImpl : ILevelRepository
    {
        private swapdb context;

        public LevelRepositoryImpl()
        {
            context = new swapdb();
        }


        public bool Delete(Level t)
        {
            throw new NotImplementedException();
        }

        public List<Level> FindAll()
        {
            throw new NotImplementedException();
        }

        public Level FindById(int? id)
        {
            return context.Levels.Find(id);
        }

        public bool Save(Level t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Level t)
        {
            throw new NotImplementedException();
        }
    }
}