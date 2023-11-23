using CRUD_EF_CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EF_CORE.Models
{
    public class TrainingDbContext : DbContext
    {
        //Keep ConnectionString

        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public TrainingDbContext()
        {

        }
        public TrainingDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."); ;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
                //Here Migration Assembly has been removed for simplicty but While we do Asp.Net web App, then we will add migrationAssembly after _connectionString in the above method.
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Course> Courses { get; set; } //This will make a trace of the Class where the Course Class Table will be created in the database according to command
        /*
         migrations generate command
         */
        
    }

}
