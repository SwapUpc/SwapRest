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
    public class LessonController : BaseController
    {
        IUserService userService;
        ILessonService lessonService;
        ILanguageService languageService;

        public LessonController()
        {
            userService = new UserServiceImpl();
            lessonService = new LessonServiceImpl();
            languageService = new LanguageServiceImpl();
        }

        [Route("api/lesson/create")]
        [HttpPost]
        public Reply Create([FromBody] LessonRequest request)
        {
            Reply reply = new Reply();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                reply.message = "No esta autorizado";
                return reply;
            }
                 
            Lesson lesson = new Lesson(); 
            try
            {
                #region Lesson
                int user_id = userService.GetId(token);
                lesson.student_id = user_id;
                lesson.teacher_id = request.teacher_id;
                lesson.latitude = request.latitude;
                lesson.lenght = request.lenght;
                lesson.day = request.day;
                lesson.task_id = request.task_id;
                lesson.description = request.description;
                lesson.status = 0;
                #endregion

                lessonService.Save(lesson);
                reply.message = "Lesson Guardada";

            }
            catch (Exception exception)
            {
                reply.message = exception.Message.ToString();
            }

            return reply;
        } 

        [Route("api/lesson/accept/{id}")]
        [HttpPut]
        public Reply AcceptLesson(int id)
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
                Lesson lesson = lessonService.FindById(id);
                if(user_id == lesson.teacher_id)
                {
                    lessonService.AcceptLesson(id);
                    reply.message = "Clase Aceptada";
                }
                else
                {
                    reply.message = "No esta autorizado para aceptar";
                }  
            }
            catch (Exception exception)
            {
                reply.message = exception.Message.ToString();
            }
            return reply;
        }

        [Route("api/lesson/cancel/{id}")]
        [HttpPut]
        public Reply CancelLesson(int id)
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
                Lesson lesson = lessonService.FindById(id);
                if (user_id == lesson.teacher_id || user_id == lesson.student_id)
                {
                    lessonService.RejectLesson(id);
                    reply.message = "Clase Rechazada";
                }
                else
                {
                    reply.message = "No esta autorizado para Rechazar";
                }
            }
            catch (Exception exception)
            {
                reply.message = exception.Message.ToString();
            }
            return reply;
        }

        [Route("api/lesson/teachers")]
        [HttpGet]
        public List<UserResponse> WantToLearn()
        {
            string token = GetToken();
            List<int> users;
            List<User> lnuser = new List<User>();
            List<UserResponse> Uresponse = new List<UserResponse>();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                return null;
            }

            try
            {
                int user_id = userService.GetId(token);
                users = userService.WantToTeach(user_id);
                int n = users.Count();
                for(int i = 0; i < n; i++)
                {
                    User user = userService.FindById(users[i]);
                    UserResponse ur = new UserResponse();
                    ur.active = user.active;
                    ur.birthday = user.birthday;
                    ur.country = user.country_id;
                    ur.description = user.description;
                    ur.email = user.email;
                    ur.gender = user.gender;
                    ur.id = user.id;
                    ur.lastname = user.lastname;
                    ur.mobilephone = user.mobilephone;
                    ur.name = user.name;
                    ur.password = user.password;
                    ur.rol = user.rol_id;
                    ur.token = user.token;
                    ur.languages = languageService.WantToTeach(users[i]);
                    //aumentar lista con los lenguajes con user_id = users.id && wish_id == 1

                    Uresponse.Add(ur);
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }

            return Uresponse;
        }

        [Route("api/lesson/update/{id}")]
        [HttpPut]
        public Reply UpdateLesson(int id, [FromBody] LessonRequest request)
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
                Lesson lesson = new Lesson();
                #region Lesson
                lesson = lessonService.FindById(id);
                
                lesson.latitude = request.latitude;
                lesson.lenght = request.lenght;
                lesson.day = request.day;
                lesson.task_id = request.task_id;
                lesson.description = request.description;
                #endregion

                lessonService.Update(lesson);
                reply.message = "Lesson Actualizada";

            }
            catch (Exception exception)
            {
                reply.message = exception.Message.ToString();
            }

            return reply;
        }

        [Route("api/lesson/teacher/{id}")]
        [HttpGet]
        public UserResponse Teacher(int id)
        {
            UserResponse user = new UserResponse();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                return null;
            }

            try
            {
                User teacher = userService.FindById(id);
                user.id = teacher.id;
                user.name = teacher.name;
                user.lastname = teacher.lastname;
                user.birthday = teacher.birthday;
                user.mobilephone = teacher.mobilephone;
                user.description = teacher.description;
                user.active = teacher.active;
                user.gender = teacher.gender;
                user.country = teacher.country_id;
                user.token = teacher.token;
                user.rol = teacher.rol_id;
                user.languages = languageService.WantToTeach(id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }

            return user;
        }

        [Route("api/lesson/views")]
        [HttpGet]
        public List<LessonResponse> ViewLessons()
        {
            List<LessonResponse> lst = new List<LessonResponse>();
            List<Lesson> lessons = new List<Lesson>();

            UserResponse user = new UserResponse();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                return null;
            }

            try
            {
                int user_id = userService.GetId(token);
                lessons = lessonService.FindByUser(user_id);
                int n = lessons.Count();

                for(int i = 0; i < n; i++)
                {
                    LessonResponse response = new LessonResponse();
                    response.day = Convert.ToDateTime(lessons[i].day);
                    response.description = lessons[i].description;
                    response.id = lessons[i].id;
                    response.latitude = lessons[i].latitude;
                    response.lenght = lessons[i].lenght;
                    response.status = lessons[i].status;
                    response.student_id = lessons[i].student_id;
                    response.task = lessons[i].task_id;
                    response.teacher_id = lessons[i].teacher_id;

                    lst.Add(response);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }

            return lst;
        }

        [Route("api/lesson/detail/{id}")]
        [HttpGet]
        public LessonResponse ViewLesson(int id)
        {
            LessonResponse response = new LessonResponse();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                return null;
            }

            try
            {
                Lesson lesson = lessonService.FindById(id);
                response.day = Convert.ToDateTime(lesson.day);
                response.description = lesson.description;
                response.id = lesson.id;
                response.latitude = lesson.latitude;
                response.lenght = lesson.lenght;
                response.status = lesson.status;
                response.student_id = lesson.student_id;
                response.task = lesson.task_id;
                response.teacher_id = lesson.teacher_id;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }

            return response;
        }
    }
}
