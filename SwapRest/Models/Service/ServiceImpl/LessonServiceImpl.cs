using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;
using SwapRest.Models.Respository;
using SwapRest.Models.Respository.FactoryMethod;

namespace SwapRest.Models.Service.ServiceImpl
{
    public class LessonServiceImpl : ILessonService
    {
        private ILessonRepository lessonRepo;

        public LessonServiceImpl()
        {
            lessonRepo = Factory.GetInstance().GetLessonRepo();
        }

        public void AcceptLesson(int id)
        {
            lessonRepo.AcceptLesson(id);
        }

        public bool Delete(Lesson t)
        {
            return lessonRepo.Delete(t);
        }

        public List<Lesson> FindAll()
        {
            return lessonRepo.FindAll();
        }

        public List<Lesson> FindByAceptedStudent(int id)
        {
            return lessonRepo.FindByAceptedStudent(id);
        }

        public List<Lesson> FindByAceptedTeacher(int id)
        {
            return lessonRepo.FindByAceptedTeacher(id);
        }

        public Lesson FindById(int? id)
        {
            return lessonRepo.FindById(id);
        }

        public List<Lesson> FindByUser(int id)
        {
            return lessonRepo.FindByUser(id);
        }

        public List<Lesson> FindRejectedByStudent(int id)
        {
            return lessonRepo.FindRejectedByStudent(id);
        }

        public List<Lesson> FindRejectedByTeacher(int id)
        {
            return lessonRepo.FindRejectedByTeacher(id);
        }

        public List<Lesson> FindWaitingByStudent(int id)
        {
            return lessonRepo.FindWaitingByStudent(id);
        }

        public List<Lesson> FindWaitingByTeacher(int id)
        {
            return lessonRepo.FindWaitingByTeacher(id);
        }

        public void RejectLesson(int id)
        {
            lessonRepo.RejectLesson(id);
        }

        public bool Save(Lesson t)
        {
            return lessonRepo.Save(t);
        }

        public bool Update(Lesson t)
        {
            return lessonRepo.Update(t);
        }
    }
}