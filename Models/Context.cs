using System;
using Microsoft.EntityFrameworkCore;
namespace ChefDish.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }
}