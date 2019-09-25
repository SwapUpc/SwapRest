using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class TaskServiceImpl : ITaskService
    {
        ITaskRespository taskRepo;

        public TaskServiceImpl()
        {
            taskRepo = Factory.GetInstance().GetTaskRepo();
        }

        public bool Delete(Task t)
        {
            throw new NotImplementedException();
        }

        public List<Task> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task FindById(int? id)
        {
            return taskRepo.FindById(id);
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