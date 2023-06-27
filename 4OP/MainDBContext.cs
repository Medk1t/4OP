using Microsoft.EntityFrameworkCore;
using _4OP.Models;

namespace _4OP
{
    public class MainDBContext: DbContext
    {
        public DbSet<Personal> Personals { get; set; }

        public DbSet<Client> Clients { get; set; }
        public MainDBContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=192.168.0.222;User=root;Password=is410601;DataBase=CHOP2");
        }
    }
}
