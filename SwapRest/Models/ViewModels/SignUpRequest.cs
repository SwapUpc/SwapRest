using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SwapRest.Models.ViewModels
{
    public class SignUpRequest
    {
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
        [Required]
        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }
        [Required]
        [StringLength(50)]
        public string mobilephone { get; set; }
        [Required]
        [StringLength(100)]
        public string description { get; set; }
        [Required]
        [StringLength(50)]
        public string gender { get; set; }
        [Required]
        public int country { get; set; }
        [Required]
        public byte[] image { get; set; }
        public List<int> languages { get; set; }
        public List<int> wishes { get; set; }
        public List<int> levels { get; set; }
    }
}