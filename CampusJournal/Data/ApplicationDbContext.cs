using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CampusJournal.Models;

namespace CampusJournal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CampusJournal.Models.StudentsViewModel> StudentsViewModel { get; set; } = default!;
        public DbSet<CampusJournal.Models.Payment> Payment { get; set; } = default!;
    }
}