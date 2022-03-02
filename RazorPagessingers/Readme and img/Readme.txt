
/// to create RazorPagessingers....
dotnet new webapp -o RazorPagessingers
code -r RazorPagessingers

///The preceding command doesn't work on Linux. See your Linux distribution's documentation for trusting a certificate.
dotnet dev-certs https --trust

/// make Models folder and in that singers.cs page 
using System.ComponentModel.DataAnnotations;
//////////////////////////////
namespace RazorPagessingers.Models
{
    public class singers
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string PopularAlbum { get; set; } = string.Empty;
        public decimal NumberOfAwards { get; set; }
    }
}
//////////////////////////////////

///Add NuGet packages and EF tools
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

///Scaffold the movie model
dotnet-aspnet-codegenerator razorpage -m singers -dc RazorPagessingersContext -udl -outDir Pages/singers --referenceScriptLibraries -sqlite
dotnet-aspnet-codegenerator razorpage -h

///migrations to run the web app
dotnet ef migrations add InitialCreate
dotnet ef database update

///run code to check it.........

//////////////////////////////////

///add the Seed the database

///////////////////////////////////
using Microsoft.EntityFrameworkCore;
using RazorPagessingers.Models;

namespace RazorPagessingers.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagessingersContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagessingersContext>>()))
            {
                if (context == null || context.singers == null)
                {
                    throw new ArgumentNullException("Null RazorPagessingersContext");
                }

                // Look for any singerss.
                if (context.singers.Any())
                {
                    return;   // DB has been seeded
                }

                context.singers.AddRange(
                    new singers
                    {
                        Name = "Arijit Singh",
                        BirthDate = DateTime.Parse("1982-6-15"),
                        PopularAlbum = "Rabata",
                        NumberOfAwards = 4
                    },

                    new singers
                    {
                        Name = "Atif Aslam",
                        BirthDate = DateTime.Parse("1979-9-29"),
                        PopularAlbum = "Yaariya",
                        NumberOfAwards = 6
                    },

                    new singers
                    {
                        Name = "Kishor Kumar",
                        BirthDate = DateTime.Parse("1956-7-07"),
                        PopularAlbum = "Sholey",
                        NumberOfAwards = 12
                    },

                    new singers
                    {
                        Name = "A P Dhilon",
                        BirthDate = DateTime.Parse("1989-02-03"),
                        PopularAlbum = "Kendi",
                        NumberOfAwards = 10
                    },

                    new singers
                    {
                        Name = "Baadshaah",
                        BirthDate = DateTime.Parse("1988-01-19"),
                        PopularAlbum = "RaOne",
                        NumberOfAwards = 7
                    }
                );
                context.SaveChanges();
            }
        }
    }
}using Microsoft.EntityFrameworkCore;
using RazorPagessingers.Models;

namespace RazorPagessingers.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagessingersContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagessingersContext>>()))
            {
                if (context == null || context.singers == null)
                {
                    throw new ArgumentNullException("Null RazorPagessingersContext");
                }

                // Look for any singerss.
                if (context.singers.Any())
                {
                    return;   // DB has been seeded
                }

                context.singers.AddRange(
                    new singers
                    {
                        Name = "Arijit Singh",
                        BirthDate = DateTime.Parse("1982-6-15"),
                        PopularAlbum = "Rabata",
                        NumberOfAwards = 4
                    },

                    new singers
                    {
                        Name = "Atif Aslam",
                        BirthDate = DateTime.Parse("1979-9-29"),
                        PopularAlbum = "Yaariya",
                        NumberOfAwards = 6
                    },

                    new singers
                    {
                        Name = "Kishor Kumar",
                        BirthDate = DateTime.Parse("1956-7-07"),
                        PopularAlbum = "Sholey",
                        NumberOfAwards = 12
                    },

                    new singers
                    {
                        Name = "A P Dhilon",
                        BirthDate = DateTime.Parse("1989-02-03"),
                        PopularAlbum = "Kendi",
                        NumberOfAwards = 10
                    },

                    new singers
                    {
                        Name = "Baadshaah",
                        BirthDate = DateTime.Parse("1988-01-19"),
                        PopularAlbum = "RaOne",
                        NumberOfAwards = 7
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
/////////////////////////////////////

///then update the program.cs file  
 //////////////////////////
 using Microsoft.EntityFrameworkCore;

using RazorPagessingers.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RazorPagessingersContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagessingersContext")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
////////////////////////////////


Now there we can access the singers page.........................................................


