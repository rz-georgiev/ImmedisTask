using ImmedisTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ImmedisTask.Data
{
    public class ImmedisDbContext : DbContext
    {
        public ImmedisDbContext(DbContextOptions options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var users = GetDeserializedObjects<Employee>(DataResources.Employees);
            var roles = GetDeserializedObjects<Comment>(DataResources.Comments);

            builder.Entity<Employee>().HasData(users);
            builder.Entity<Comment>().HasData(roles);
        }

        private IEnumerable<T> GetDeserializedObjects<T>(string resourceValue) where T : class
        {
            var objects = JsonConvert.DeserializeObject<List<T>>(resourceValue);
            return objects;
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}