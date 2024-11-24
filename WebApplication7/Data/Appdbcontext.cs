using Microsoft.EntityFrameworkCore;
using WebApplication7.modle;

namespace WebApplication7.Data
{
    public class Appdbcontext:DbContext
    {
        public Appdbcontext( DbContextOptions options):base(options) { }
        public DbSet<movie> movies { get; set; }
        public DbSet<categ > categs {  get; set; } 
        public DbSet<cinema> cinema { get; set; }
    }
}
