using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwapRest.Models.ViewModels
{
    public class LessonRequest
    {
        [Required]
        public int teacher_id;
        [Required]
        public float latitude;
        [Required]
        public float lenght;
        [Required]
        public DateTime day;
        [Required]
        public int task_id;
        [StringLength(100)]
        public string description;
    }
}