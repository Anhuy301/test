using Microsoft.EntityFrameworkCore;
using Web_Test_DevExpress_ClaudeAI.Models;

namespace Web_Test_DevExpress_ClaudeAI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<GateLog> GateLogs { get; set; }
    }
}