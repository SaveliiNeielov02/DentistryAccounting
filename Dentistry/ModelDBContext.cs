using Microsoft.EntityFrameworkCore;
using Dentistry.Models;
namespace Dentistry.Services
{

    public class ModelDBContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<Reception> Receptions { get; set; }

        public ModelDBContext(DbContextOptions<ModelDBContext> options) : base(options)
        {
        }

    }
}
