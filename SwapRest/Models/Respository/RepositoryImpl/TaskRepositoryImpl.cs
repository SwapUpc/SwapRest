using SwapRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class TaskRepositoryImpl : ITaskRespository
    {
        private swapdb context;

        public TaskRepositoryImpl()
        {
            context = new swapdb();
        }

        public bool Delete(Task t)
        {
            throw new NotImplementedException();
        }

        public List<Task> FindAll()
        {
            return context.Tasks.ToList();
        }

        public Task FindById(int? id)
        {
            return context.Tasks.Find(id);
        }

        public bool Save(Task t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Task t)
        {
            throw new NotImplementedException();
        }
    }
}