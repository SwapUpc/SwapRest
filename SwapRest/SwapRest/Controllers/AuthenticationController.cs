using SwapRest.Models.Entities;
using SwapRest.Models.Service;
using SwapRest.Models.Service.ServiceImpl;
using SwapRest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwapRest.Controllers
{
    public class AuthenticationController : ApiController
    {
        private IUserService userService;
        private IUserWishService userwishService;

        public AuthenticationController()
        {
            userService = new UserServiceImpl();
            userwishService = new UserWishServiceImpl();
        }

        [Route("api/authentication/signIn")]
        [HttpPost]
        public Reply SignIn([FromBody] SignInRequest request)
        {
            Reply reply = new Reply();
            User user;
            try
            {
                user = userService.Authentication(request.email, request.password);
                if (user != null)
                {
                    reply.result = 200;
                    reply.data = Guid.NewGuid().ToString();
                    reply.message = "Se inicio sesion";
                    user.token = reply.data;
                    userService.Update(user);
                }
            }
            catch (Exception exception)
            {
                reply.result = 500;
                reply.message = "Ocurrio un error" + exception.Message.ToString();
            }
            return reply;
        }

        [Route("api/authentication/signUp")]
        [HttpPost]
        public Reply SignUp([FromBody] SignUpRequest request)
        {
            Reply reply = new Reply();
            User user = new User();
            
            bool exists;
            try
            {
                exists = userService.ExitsEmail(request.email);
                if (exists)
                {
                    reply.result = 409;
                    reply.message = "El email ya se encuentra registrado";
                }
                else
                {
                    #region User's request
                    user.name = request.name;
                    user.lastname = request.lastname;
                    user.active = 1;
                    user.birthday = request.birthday;
                    user.country_id = request.country;
                    user.description = request.description;
                    user.email = request.email;
                    user.gender = request.gender;
                    user.mobilephone = request.mobilephone;
                    user.password = request.password;
                    user.rol_id = 3;
                    user.token = "";
                    user.image = request.image;

                    #endregion

                    userService.Save(user);

                    #region Union with Language
                    int n = request.languages.Count();
                    user = userService.FindByEmail(request.email);
                    

                    for (int i = 0; i < n; i++)
                    {
                        User_wish userwish = new User_wish();
                        userwish.user_id = user.id;
                        userwish.language_id = request.languages[i];
                        userwish.level_id = request.levels[i];
                        userwish.wish_id = request.wishes[i];

                        userwishService.Save(userwish);
                    }
                    #endregion

                    reply.result = 200;
                    reply.message = "registro exitoso";
                }
            }
            catch (Exception exception)
            {
                reply.result = 500;
                reply.message = "Ocurrio un error" + exception.Message.ToString();
            }
            return reply;
        }
    }
}
