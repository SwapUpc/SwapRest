using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SwapRest.Models.ViewModels
{
    public class UserResponse
    {
        public int id;
        public string name;
        public string lastname;
        public string email;
        public string password;
        [Column(TypeName = "date")]
        public DateTime birthday;
        public string mobilephone;
        public string description;
        public int active;
        public string gender;
        public int country;
        public string token;
        public int rol;
        public List<int> languages;
    }
}