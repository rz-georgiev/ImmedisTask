using ImmedisTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ImmedisTask.Tests
{
    public abstract class ParentTest
    {
        protected readonly ImmedisDbContext ImmedisDbContext;

        protected ParentTest()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var options = new DbContextOptionsBuilder();
            options.UseNpgsql(configuration.GetConnectionString("ImmedisDbConnection"));

            ImmedisDbContext = new ImmedisDbContext(options.Options);
        }
    }
}