using Microsoft.EntityFrameworkCore;
using rft.Models;

namespace rft.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Register> Registers { get; set; }
    }
}
