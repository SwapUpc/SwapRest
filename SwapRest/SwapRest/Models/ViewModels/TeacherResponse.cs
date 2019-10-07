using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.ViewModels
{
    public class TeacherResponse
    {
        public int id;
        public string name;
        public string lastname;
        public string mobilephone;
        public string description;
        public string gender;
        public string country;
        public byte[] image;
        public List<string> languages;
    }
}