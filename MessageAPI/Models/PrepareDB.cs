using MessageAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MessageAPI.Models
{
    public static class PrepareDB
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MessageContext>());
            }
        }

        public static void SeedData(MessageContext context)
        {
            System.Console.WriteLine("Appling migrations...");

            context.Database.Migrate();

            if (!context.Messages.Any())
            {
                System.Console.WriteLine("Adding data...");
                context.Messages.AddRange(
                    new Message() { Id = 1, Text = "a" },
                    new Message() { Id = 2, Text = "b" },
                    new Message() { Id = 3, Text = "c" });
            }
            else
            {
                System.Console.WriteLine("Database already have data");
            }
        }
    }
}
