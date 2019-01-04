using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.Contracts;
using Project.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Project.Services.Tests
{
    
    public class CategoryServiceTests
    {
        [Theory]
        [InlineData("FirstCategory",true)]
        [InlineData("SecondCategory", true)]
        [InlineData("false", false)]
        public void IsCategoryValidTest(string categoryName,bool expected)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Find_User_Database") 
            .Options;

            var result = true;
            using (var context = new ApplicationDbContext(options)) 
            {
                context.Categories.AddRange(GetTestCategories());
                context.SaveChanges();

                ICategoryService service = new CategoryService(context);
                result = service.IsCategoryValid(categoryName);
            }

            


            Assert.Equal(result,expected);
        }

        [Theory]
        [InlineData("FirstCategory", "SecondCategory", true)]
        [InlineData("FirstCategory","false", false)]
        public void AreCategoriesValidTest(string categoryName,string secondCategory, bool expected)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Find_User_Database")
            .Options;

            var categories = new List<string>
            {
                categoryName,secondCategory
            };
            var result = true;
            using (var context = new ApplicationDbContext(options))
            {
                context.Categories.AddRange(GetTestCategories());
                context.SaveChanges();

                
                ICategoryService service = new CategoryService(context);
                result = service.AreCategoriesValid(categories);
            }




            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetAllCategoriesNamesTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Get_All")
           .Options;

            var categories = new List<string>
            {
                "FirstCategory","SecondCategory"
            };
            IEnumerable<string> result;
            using (var context = new ApplicationDbContext(options))
            {
                context.Categories.AddRange(GetTestCategories());
                context.SaveChanges();


                ICategoryService service = new CategoryService(context);
                result = service.GetAllCategoriesNames();
            }
            
            Assert.Equal(categories, result);


        }

        [Fact]
        public void GetCategoriesByNameTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Find_User_Database")
           .Options;

            var categoriesNames = new List<string>
            {
                "FirstCategory","SecondCategory"
            };
            IEnumerable<Category> result;
            using (var context = new ApplicationDbContext(options))
            {
                context.Categories.AddRange(GetTestCategories());
                context.SaveChanges();


                ICategoryService service = new CategoryService(context);
                result = service.GetCategoriesByName(categoriesNames).ToList();
            }


            Assert.Equal(2, result.Count());


        }

        [Fact]
        public void CreateCategoryTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Create_Category")
           .Options;

            int result;
            using (var context = new ApplicationDbContext(options))
            {
                context.Categories.AddRange(GetTestCategories());
                context.SaveChanges();


                ICategoryService service = new CategoryService(context);
                service.CreateCategory("ThirdCategory");
                result = context.Categories.Count();
            }


            Assert.Equal(3, result);


        }
            public List<Category> GetTestCategories()
        {
            return new List<Category>
           {
               new Category
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "FirstCategory"
               },
                new Category
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "SecondCategory"
               },

           };
        }


       

    }
}
