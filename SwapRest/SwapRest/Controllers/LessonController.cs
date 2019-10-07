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
        ICountryService countryService;
        ITaskService taskService;

        public LessonController()
        {
            userService = new UserServiceImpl();
            lessonService = new LessonServiceImpl();
            languageService = new LanguageServiceImpl();
            countryService = new CountryServiceImpl();
            taskService = new TaskServiceImpl();
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
        public List<TeacherResponse> WantToLearn()
        {
            string token = GetToken();
            List<int> users;
            List<User> lnuser = new List<User>();
            List<TeacherResponse> Uresponse = new List<TeacherResponse>();

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
                    TeacherResponse tr = new TeacherResponse();

                    Country country = new Country();
                    country = countryService.FindById(user.country_id);

                    List<string> language = new List<string>();
                    List<int> wtt = languageService.WantToTeach(users[i]);
                    int m = wtt.Count();

                    for(int j = 0; j < m; j++)
                    {
                        Language lng = new Language();
                        lng = languageService.FindById(wtt[j]);
                        language.Add(lng.name);
                    }

                    tr.country = country.name;
                    tr.description = user.description;
                    tr.gender = user.gender;
                    tr.id = user.id;
                    tr.lastname = user.lastname;
                    tr.mobilephone = user.mobilephone;
                    tr.name = user.name;
                    tr.image = user.image;
                    tr.languages = language;
                    //aumentar lista con los lenguajes con user_id = users.id && wish_id == 1

                    Uresponse.Add(tr);
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
        public TeacherResponse Teacher(int id)
        {
            TeacherResponse tresponse = new TeacherResponse();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                return null;
            }

            try
            {
                User teacher = userService.FindById(id);
                Country country = new Country();
                country = countryService.FindById(teacher.country_id);

                List<string> language = new List<string>();
                List<int> wtt = languageService.WantToTeach(id);
                int n = wtt.Count();

                for (int j = 0; j < n; j++)
                {
                    Language lng = new Language();
                    lng = languageService.FindById(wtt[j]);
                    language.Add(lng.name);
                }

                tresponse.id = teacher.id;
                tresponse.name = teacher.name;
                tresponse.lastname = teacher.lastname;
                tresponse.mobilephone = teacher.mobilephone;
                tresponse.description = teacher.description;
                tresponse.gender = teacher.gender;
                tresponse.country = country.name;
                tresponse.image = teacher.image;
                tresponse.languages = language;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }

            return tresponse;
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
                    User tr = userService.FindById(lessons[i].teacher_id);
                    TeacherResponse teacher = new TeacherResponse();
                    Country country = countryService.FindById(tr.country_id);
                    List<string> language = new List<string>();
                    List<int> wtt = languageService.WantToTeach(tr.id);
                    int m = wtt.Count();

                    for (int j = 0; j < m; j++)
                    {
                        Language lng = new Language();
                        lng = languageService.FindById(wtt[j]);
                        language.Add(lng.name);
                    }

                    teacher.country = country.name;
                    teacher.description = tr.description;
                    teacher.gender = tr.gender;
                    teacher.id = tr.id;
                    teacher.image = tr.image;
                    teacher.languages = language;
                    teacher.lastname = tr.lastname;
                    teacher.mobilephone = tr.mobilephone;
                    teacher.name = tr.name;

                    LessonResponse response = new LessonResponse();
                    Task task = new Task();
                    task = taskService.FindById(lessons[i].task_id);
                    response.day = Convert.ToDateTime(lessons[i].day);
                    response.description = lessons[i].description;
                    response.id = lessons[i].id;
                    response.latitude = lessons[i].latitude;
                    response.lenght = lessons[i].lenght;
                    response.status = lessons[i].status;
                    response.student_id = lessons[i].student_id;
                    response.task = task.name;
                    response.teacher = teacher;
                    
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
            TeacherResponse tr = new TeacherResponse();
            User teacher = new User();
            string token = GetToken();

            if (userService.VerifyRol(token) != 2 && userService.VerifyRol(token) != 3)
            {
                return null;
            }

            try
            {
                Lesson lesson = lessonService.FindById(id);
                teacher = userService.FindById(lesson.teacher_id);
                Task task = taskService.FindById(lesson.task_id);
                
                Country country = countryService.FindById(teacher.country_id);

                List<string> language = new List<string>();
                List<int> wtt = languageService.WantToTeach(id);
                int n = wtt.Count();

                for (int j = 0; j < n; j++)
                {
                    Language lng = new Language();
                    lng = languageService.FindById(wtt[j]);
                    language.Add(lng.name);
                }


                tr.id = teacher.id;
                tr.image = teacher.image;
                tr.languages = language;
                tr.lastname = teacher.lastname;
                tr.mobilephone = teacher.mobilephone;
                tr.name = teacher.name;
                tr.country = country.name;
                tr.description = teacher.description;
                tr.gender = teacher.gender;


                response.day = Convert.ToDateTime(lesson.day);
                response.description = lesson.description;
                response.id = lesson.id;
                response.latitude = lesson.latitude;
                response.lenght = lesson.lenght;
                response.status = lesson.status;
                response.student_id = lesson.student_id;
                response.task = task.name;
                response.teacher = tr;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }

            return response;
        }
    }
}
