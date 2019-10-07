using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SwapRest.Models.ViewModels
{
    public class UserRequest
    {
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [StringLength(50)]
        public string lastname { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [Required]
        [StringLength(50)]
        public string mobilephone { get; set; }
        [Required]
        [StringLength(100)]
        public string description { get; set; }
        [Required]
        public byte[] image { get; set; }
        [Required]
        public List<int> languages { get; set; }
        [Required]
        public List<int> wishes { get; set; }
        [Required]
        public List<int> levels { get; set; }
    }
}