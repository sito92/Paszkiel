using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class SystemContext:DbContext
    {
        public SystemContext() : base("LocalConnection")
        {
            
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<LaptopBoolValue> LaptopBoolValues { get; set; }
        public DbSet<LaptopFuzzyValue> LaptopFuzzyValues { get; set; }
    }
}