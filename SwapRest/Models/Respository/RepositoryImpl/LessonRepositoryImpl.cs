using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SwapRest.Models.Entities;

namespace SwapRest.Models.Respository.RepositoryImpl
{
    public class LessonRepositoryImpl : ILessonRepository
    {
        private swapdb context;

        public LessonRepositoryImpl()
        {
            context = new swapdb();
        }

        public void AcceptLesson(int id)
        {
            Lesson lesson;
            try
            {
                lesson = FindById(id);
                lesson.status = 1; // 0 -> en espera, 1 -> aceptado, 2 -> rechazado, 3 -> eliminado
                context.Entry(lesson).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
        }

        public bool Delete(Lesson t)
        {
            Lesson lesson;
            try
            {
                lesson = FindById(t.id);
                lesson.status = 3; // 0 -> en espera, 1 -> aceptado, 2 -> rechazado, 3 -> eliminado
                context.Entry(lesson).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return false;
        }

        public List<Lesson> FindAll()
        {
            return context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .ToList();
        }

        public List<Lesson> FindByAceptedStudent(int id)
        {
            List<Lesson> lessons = context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .Where(d => d.status == 1 && d.student_id == id).ToList();
            return lessons;
        }

        public List<Lesson> FindByAceptedTeacher(int id)
        {
            List<Lesson> lessons = context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .Where(d => d.status == 1 && d.teacher_id == id).ToList();
            return lessons;
        }

        public Lesson FindById(int? id)
        {
            return context.Lessons
                .Find(id);
        }

        public List<Lesson> FindByUser(int id)
        {
            List<Lesson> lessons = context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .Where(d => d.student_id == id || d.teacher_id == id).ToList();
            return lessons;
        }

        public List<Lesson> FindRejectedByStudent(int id)
        {
            List<Lesson> lessons = context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .Where(d => d.status == 2 && d.student_id == id).ToList();
            return lessons;
        }

        public List<Lesson> FindRejectedByTeacher(int id)
        {
            List<Lesson> lessons = context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .Where(d => d.status == 2 && d.teacher_id == id).ToList();
            return lessons;
        }

        public List<Lesson> FindWaitingByStudent(int id)
        {
            List<Lesson> lessons = context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .Where(d => d.status == 0 && d.student_id == id).ToList();
            return lessons;
        }

        public List<Lesson> FindWaitingByTeacher(int id)
        {
            List<Lesson> lessons = context.Lessons
                .Include(s => s.student)
                .Include(ta => ta.task)
                .Include(t => t.teacher)
                .Where(d => d.status == 0 && d.teacher_id == id).ToList();
            return lessons;
        }

        public void RejectLesson(int id)
        {
            Lesson lesson;
            try
            {
                lesson = FindById(id);
                lesson.status = 2; // 0 -> en espera, 1 -> aceptado, 2 -> rechazado, 3 -> eliminado
                context.Entry(lesson).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
        }

        public bool Save(Lesson t)
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

        public bool Update(Lesson t)
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