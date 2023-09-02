using Microsoft.EntityFrameworkCore;
using RubikBook.Database.Models;
using RubikBook.Database.Classes;

namespace RubikBook.Database.Context
{
    internal class DbInitializer
    {
        private ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal async void Seed()
        {
            Role adminRole = new Role()
            {
                Id = Guid.NewGuid(),
                RoleName = "admin",
                RoleTitle = "مدیر",
            }; _modelBuilder.Entity<Role>().HasData(adminRole);


            Role userRole = new Role()
            {
                Id= Guid.NewGuid(),
                RoleName= "user",
                RoleTitle = "کاربر",
            }; _modelBuilder.Entity<Role>().HasData(userRole);


            User adminUser = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = adminRole.Id,
                Mobile = "09115523293",
                Password = await new Security().HashPassword("12345678"), 
                IsActive = true,
            }; _modelBuilder.Entity<User>().HasData(adminUser);

            List<Group> defaultgroups = new List<Group>()
            {
                new Group() { Id = 1, GroupName = "فلسفه و روانشناسی" },
                new Group() { Id = 2, GroupName = "تاریخ و جغرافیا" },
                new Group() { Id = 3, GroupName = "رمان و داستان" },
                new Group() { Id = 4, GroupName = "کتاب صوتی" },
            }; _modelBuilder.Entity<Group>().HasData(defaultgroups);

            Author author = new Author()
            {
                Id = 1,
                AuthorName = "جورج اورول",

            }; _modelBuilder.Entity<Author>().HasData(author);


            List<AgeCategory> ageCategories = new List<AgeCategory>()
            {
                new AgeCategory() {Id = 1, AgeCategoryName = "کودک"},
                new AgeCategory() {Id = 2, AgeCategoryName = "نوجوان"},
                new AgeCategory() {Id = 3, AgeCategoryName = "جوان"},
                new AgeCategory() {Id = 4, AgeCategoryName = "بزرگسال"},
            }; _modelBuilder.Entity<AgeCategory>().HasData(ageCategories);

            Publisher publisher = new Publisher()
            {
                Id = 1,
                PublisherName = "پرتقال",
            }; _modelBuilder.Entity<Publisher>().HasData(publisher);
        }
    }
}