using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.ViewModels
{
    public class LessonResponse
    {
        public int id;
        public int student_id;
        public int teacher_id;
        public float latitude;
        public float lenght;
        public DateTime day;
        public int task;
        public string description;
        public int status;
    }
}