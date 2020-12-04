using Microsoft.EntityFrameworkCore;
using Slot.Models;

namespace Slot.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Result> Results { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
    }
}