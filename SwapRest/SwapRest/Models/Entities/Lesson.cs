namespace SwapRest.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int student_id { get; set; }

        public int teacher_id { get; set; }

        public float latitude { get; set; }

        public float lenght { get; set; }

        public DateTime? day { get; set; }

        public int task_id { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }

        public int status { get; set; }

        public virtual Task task { get; set; }

        public virtual User student { get; set; }

        public virtual User teacher { get; set; }
    }
}
