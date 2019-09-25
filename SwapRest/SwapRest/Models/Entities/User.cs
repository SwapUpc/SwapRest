namespace SwapRest.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        [Required]
        [StringLength(50)]
        public string mobilephone { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }

        public int active { get; set; }

        [Required]
        [StringLength(50)]
        public string gender { get; set; }

        public int country_id { get; set; }

        [StringLength(50)]
        public string token { get; set; }

        public int rol_id { get; set; }

        public virtual Country country { get; set; }

        public virtual ICollection<Lesson> lesson { get; set; }

        public virtual ICollection<Lesson> lesson1 { get; set; }

        public virtual Rol rol { get; set; }

        public virtual ICollection<User_wish> user_wish { get; set; }
    }
}
