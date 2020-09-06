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
                    new Message() { Text = "a" },
                    new Message() { Text = "b" },
                    new Message() { Text = "c" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Database already have data");
            }
        }
    }
}
