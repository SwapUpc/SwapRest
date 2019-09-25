using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class LevelServiceImpl : ILevelService
    {
        ILevelRepository levelRepo;

        public LevelServiceImpl()
        {
            levelRepo = Factory.GetInstance().GetLevel();
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
            return levelRepo.FindById(id);
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