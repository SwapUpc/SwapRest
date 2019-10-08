namespace SwapRest.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class swapdb : DbContext
    {
        public swapdb()
            : base("name=swapdb")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }
        public virtual DbSet<User_wish> User_wish { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.user)
                .WithRequired(e => e.country)
                .HasForeignKey(e => e.country_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.user_wish)
                .WithRequired(e => e.language)
                .HasForeignKey(e => e.language_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Level>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Level>()
                .HasMany(e => e.user_wish)
                .WithRequired(e => e.level)
                .HasForeignKey(e => e.level_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.user)
                .WithRequired(e => e.rol)
                .HasForeignKey(e => e.rol_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.lesson)
                .WithRequired(e => e.task)
                .HasForeignKey(e => e.task_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.mobilephone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.lesson)
                .WithRequired(e => e.student)
                .HasForeignKey(e => e.student_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.lesson1)
                .WithRequired(e => e.teacher)
                .HasForeignKey(e => e.teacher_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.user_wish)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wish>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Wish>()
                .HasMany(e => e.user_wish)
                .WithRequired(e => e.wish)
                .HasForeignKey(e => e.wish_id)
                .WillCascadeOnDelete(false);
        }
    }
}
