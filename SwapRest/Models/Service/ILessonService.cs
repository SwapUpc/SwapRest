using SwapRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapRest.Models.Service
{
    public interface ILessonService : ICrudService<Lesson>
    {
        List<Lesson> FindByAceptedStudent(int id);
        List<Lesson> FindByAceptedTeacher(int id);
        List<Lesson> FindRejectedByStudent(int id);
        List<Lesson> FindRejectedByTeacher(int id);
        List<Lesson> FindWaitingByStudent(int id);
        List<Lesson> FindWaitingByTeacher(int id);
        void AcceptLesson(int id);
        void RejectLesson(int id);
        List<Lesson> FindByUser(int id);
    }
}
