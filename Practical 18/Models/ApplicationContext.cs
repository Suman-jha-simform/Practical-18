using Microsoft.EntityFrameworkCore;
using Practical_18.ViewModels;

namespace Practical_18.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Practical_18.ViewModels.StudentViewModel> StudentViewModel { get; set; } = default!;

    }
}
