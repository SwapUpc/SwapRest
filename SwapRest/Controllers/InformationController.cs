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
    public class InformationController : ApiController
    {
        ILanguageService languageServ;
        ICountryService countryServ;
        ILevelService levelServ;
        IRolService rolServ;
        ITaskService taskServ;
        IWishService wishServ;

        public InformationController()
        {
            languageServ = new LanguageServiceImpl();
            countryServ = new CountryServiceImpl();
            levelServ = new LevelServiceImpl();
            rolServ = new RolServiceImpl();
            taskServ = new TaskServiceImpl();
            wishServ = new WishServiceImpl();
        }

        [Route("api/information/language/{id}")]
        [HttpGet]
        public NameResponse GetLanguage(int id)
        {
            NameResponse response = new NameResponse();

            try
            {
                Language language = languageServ.FindById(id);
                response.id = language.id;
                response.name = language.name;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/country/{id}")]
        [HttpGet]
        public NameResponse GetCountry(int id)
        {
            NameResponse response = new NameResponse();

            try
            {
                Country country = countryServ.FindById(id);
                response.id = country.id;
                response.name = country.name;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/level/{id}")]
        [HttpGet]
        public NameResponse GetLevel(int id)
        {
            NameResponse response = new NameResponse();

            try
            {
                Level level = levelServ.FindById(id);
                response.id = level.id;
                response.name = level.name;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/rol/{id}")]
        [HttpGet]
        public NameResponse GetRol(int id)
        {
            NameResponse response = new NameResponse();

            try
            {
                Rol rol = rolServ.FindById(id);
                response.id = rol.id;
                response.name = rol.name;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/task/{id}")]
        [HttpGet]
        public NameResponse GetTask(int id)
        {
            NameResponse response = new NameResponse();

            try
            {
                Task task = taskServ.FindById(id);
                response.id = task.id;
                response.name = task.name;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/wish/{id}")]
        [HttpGet]
        public NameResponse GetWish(int id)
        {
            NameResponse response = new NameResponse();

            try
            {
                Wish wish = wishServ.FindById(id);
                response.id = wish.id;
                response.name = wish.name;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/languages")]
        [HttpGet]
        public List<NameResponse> GetLanguages()
        {
            List<NameResponse> response = new List<NameResponse>();
            List<Language> lngs = languageServ.FindAll();
            int n = lngs.Count();
            try
            {
                for(int i = 0; i < n; i++)
                {
                    NameResponse language = new NameResponse();
                    language.id = lngs[i].id;
                    language.name = lngs[i].name;
                    response.Add(language);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/countries")]
        [HttpGet]
        public List<NameResponse> GetCountries()
        {
            List<NameResponse> response = new List<NameResponse>();
            List<Country> lngs = countryServ.FindAll();
            int n = lngs.Count();
            try
            {
                for (int i = 0; i < n; i++)
                {
                    NameResponse country = new NameResponse();
                    country.id = lngs[i].id;
                    country.name = lngs[i].name;
                    response.Add(country);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/levels")]
        [HttpGet]
        public List<NameResponse> GetLevels()
        {
            List<NameResponse> response = new List<NameResponse>();
            List<Level> lngs = levelServ.FindAll();
            int n = lngs.Count();
            try
            {
                for (int i = 0; i < n; i++)
                {
                    NameResponse level = new NameResponse();
                    level.id = lngs[i].id;
                    level.name = lngs[i].name;
                    response.Add(level);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }

        [Route("api/information/tasks")]
        [HttpGet]
        public List<NameResponse> GetTasks()
        {
            List<NameResponse> response = new List<NameResponse>();
            List<Task> lngs = taskServ.FindAll();
            int n = lngs.Count();
            try
            {
                for (int i = 0; i < n; i++)
                {
                    NameResponse task = new NameResponse();
                    task.id = lngs[i].id;
                    task.name = lngs[i].name;
                    response.Add(task);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            return response;
        }
    }
}
