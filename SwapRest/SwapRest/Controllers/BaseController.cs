using SwapRest.Models.Respository.FactoryMethod;
using SwapRest.Models.Service;
using SwapRest.Models.Service.ServiceImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwapRest.Controllers
{
    public class BaseController : ApiController
    {
        public string GetToken()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "Error con el Token";
            if (headers.Contains("Authorization"))
            {
                token = headers.GetValues("Authorization").First();
            }
            return token;
        }
    }
}
