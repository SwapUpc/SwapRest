using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwapRest.Models.ViewModels
{
    public class SignInRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}