using SwapRest.Models.Entities;
using SwapRest.Models.Service;
using SwapRest.Models.Service.ServiceImpl;
using SwapRest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwapRest.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService;
        private IUserWishService userwishService;
        private ILanguageService languageService;

        public UserController()
        {
            userService = new UserServiceImpl();
            userwishService = new UserWishServiceImpl();
            languageService = new LanguageServiceImpl();
        }

        [Route("api/user/update")]
        [HttpPut]
        public Reply UpdateUser([FromBody] UserRequest request)
        {
            Reply reply = new Reply();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                reply.message = "No esta autorizado";
                return reply;
            }

            try
            {
                int user_id = userService.GetId(token);
                User user = userService.FindById(user_id);
                user.description = request.description;
                user.lastname = request.lastname;
                user.name = request.name;
                user.password = request.password;
                user.image = request.image;
                userService.Update(user);

                int n = request.languages.Count();
                List<User_wish> lst = userwishService.FindByUser(user_id);
                int m = lst.Count();

                for (int j = 0; j < m; j++)
                {
                    userwishService.Delete(lst[j]);
                }

                for (int i = 0; i < n; i++)
                {
                    User_wish userwish = new User_wish();
                    userwish.user_id = user_id;
                    userwish.language_id = request.languages[i];
                    userwish.level_id = request.levels[i];
                    userwish.wish_id = request.wishes[i];
                    userwishService.Save(userwish);
                }

                reply.message = "Idiomas actualizados";
            }
            catch (Exception)
            {

                throw;
            }


            return reply;
        }

        [Route("api/user/delete")]
        [HttpDelete]
        public Reply DeleteUser()
        {
            Reply reply = new Reply();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                reply.message = "No esta autorizado";
                return reply;
            }

            try
            {
                int user_id = userService.GetId(token);
                User user = userService.FindById(user_id);
                user.active = 0;
                userService.Update(user);

                reply.message = "Usuario Borrado";
            }
            catch (Exception)
            {

                throw;
            }


            return reply;
        }

        [Route("api/user/profile")]
        [HttpGet]
        public UserResponse GetProfile()
        {
            UserResponse user = new UserResponse();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                return null;
            }

            try
            {
                int id = userService.GetId(token);
                User profile = userService.FindById(id);
                user.id = profile.id;
                user.name = profile.name;
                user.lastname = profile.lastname;
                user.email = profile.email;
                user.birthday = profile.birthday;
                user.mobilephone = profile.mobilephone;
                user.description = profile.description;
                user.active = profile.active;
                user.gender = profile.gender;
                user.country = profile.country_id;
                user.token = profile.token;
                user.rol = profile.rol_id;
                user.image = profile.image;
                user.languages = languageService.WantToTeach(id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }

            return user;
        }
    }
}
