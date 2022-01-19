#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodAPI.Models;

namespace FoodAPI.Data
{
    public class FoodAPIContext : DbContext
    {
        public FoodAPIContext (DbContextOptions<FoodAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FoodAPI.Models.Product> Product { get; set; }

        public DbSet<FoodAPI.Models.Category> Category { get; set; }

        public DbSet<FoodAPI.Models.Feedback> Feedback { get; set; }

        public DbSet<FoodAPI.Models.Order> Order { get; set; }

        public DbSet<FoodAPI.Models.OrderDetail> OrderDetail { get; set; }

        public DbSet<FoodAPI.Models.Account> Account { get; set; }
    }
}
