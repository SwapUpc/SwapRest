namespace SwapRest.Migrations
{
    using SwapRest.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SwapRest.Models.Entities.swapdb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SwapRest.Models.Entities.swapdb context)
        {
            //Iniciarlizar algunas tablas con datos

            var roles = new List<Rol>
            {
                new Rol { name = "Admin" },
                new Rol { name = "Student" },
                new Rol { name = "Teacher" }
            };
            roles.ForEach(r => context.Roles.AddOrUpdate(p => p.name, r));
            context.SaveChanges();

            var countries = new List<Country>
            {
                new Country { name = "Peru" },
                new Country { name = "United States" },
                new Country { name = "Japan" },
                new Country { name = "Brazil" }
            };
            countries.ForEach(c => context.Countries.AddOrUpdate(p => p.name, c));
            context.SaveChanges();

            var languages = new List<Language>
            {
                new Language { name = "Spanish" },
                new Language { name = "English" },
                new Language { name = "Japanese" },
                new Language { name = "Portuguese" }
            };
            languages.ForEach(f => context.Languages.AddOrUpdate(p => p.name, f));
            context.SaveChanges();

            var levels = new List<Level>
            {
                new Level { name = "Beginner" },
                new Level { name = "Basic" },
                new Level { name = "Intermediate" },
                new Level { name = "Advance" }
            };
            levels.ForEach(l => context.Levels.AddOrUpdate(p => p.name, l));
            context.SaveChanges();

            var tasks = new List<Task>
            {
                new Task { name = "Vocabulary" },
                new Task { name = "Grammar" },
                new Task { name = "Speaking" },
                new Task { name = "Writing" }

            };
            tasks.ForEach(t => context.Tasks.AddOrUpdate(p => p.name, t));
            context.SaveChanges();

            var wishes = new List<Wish>
            {
                new Wish { name = "Teach" },
                new Wish { name = "Learn" }
            };
            wishes.ForEach(w => context.Wishes.AddOrUpdate(p => p.name, w));
            context.SaveChanges();

            var users = new List<User>
            {
                new User { name = "daniel", lastname = "jimenez", email = "daniel@gmail.com", password = "123456", birthday = Convert.ToDateTime("2019-09-24"), mobilephone = "954136172", description = "Alegre 1", active = 1, gender = "Masculino", country_id = 1, token = "", rol_id = 3},
                new User { name = "paulo", lastname = "Gonzales", email = "paulo@gmail.com", password = "123456", birthday = Convert.ToDateTime("2019-09-24"), mobilephone = "921432015", description = "Alegre 2", active = 1, gender = "Masculino", country_id = 1, token = "aaeb973e-9bc7-48a0-a61d-da1d8ee0e523", rol_id = 3},
                new User { name = "luciana", lastname = "Romero", email = "luciana@gmail.com", password = "123456", birthday = Convert.ToDateTime("2019-09-24"), mobilephone = "945000654", description = "Alegre 3", active = 1, gender = "Masculino", country_id = 3, token = "6d410cd8-770d-407d-a211-9e494d1474b5", rol_id = 3}
            };
            users.ForEach(u => context.Users.AddOrUpdate(p => p.name, u));
            context.SaveChanges();

            var userwishes = new List<User_wish>
            {
                new User_wish { user_id = 1, language_id = 1, level_id = 1, wish_id = 1 },
                new User_wish { user_id = 1, language_id = 2, level_id = 4, wish_id = 1 },
                new User_wish { user_id = 2, language_id = 1, level_id = 4, wish_id = 1 },
                new User_wish { user_id = 2, language_id = 2, level_id = 3, wish_id = 1 },
                new User_wish { user_id = 3, language_id = 1, level_id = 3, wish_id = 1 },
                new User_wish { user_id = 3, language_id = 2, level_id = 4, wish_id = 2 },
                new User_wish { user_id = 3, language_id = 3, level_id = 1, wish_id = 2 }
            };
            userwishes.ForEach(uw => context.User_wish.AddOrUpdate(p => p.user_id, uw));
            context.SaveChanges();

            var lessons = new List<Lesson>
            {
                new Lesson { student_id = 3, teacher_id = 2, latitude = 12, lenght = -12, day = Convert.ToDateTime("2019-09-30 02:04:00.000"), task_id = 1, description = "Aprender", status = 0 },
                new Lesson { student_id = 3, teacher_id = 2, latitude = 12, lenght = -12, day = Convert.ToDateTime("2019-09-30 12:20:00.000"), task_id = 1, description = "Aprender 2", status = 0 },
            };
            lessons.ForEach(l => context.Lessons.AddOrUpdate(p => p.student_id, l));
            context.SaveChanges();

            
        }
    }
}
