
using Microsoft.EntityFrameworkCore;
using TestAppWeb.Model;
using TestAppWeb.Model.AuthApp;

namespace WebAppRazorPages.Controller
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Marlboro> Cigarett { get; set; }
        public DbSet<AuthUser>? AuthUsers { get; set; }
        public DbSet<RegisterModel>? RegisterModels { get; set; }
        public DbSet<LoginModel>? LoginModels { get; set; }

    }
}