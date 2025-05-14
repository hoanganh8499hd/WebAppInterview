using Microsoft.EntityFrameworkCore;

namespace WebAppCRUD.Models
{
    // Role of DbContext in EF Core:

    // 1. Querying: 
    // DbContext provides the necessary methods and properties to query the database. 
    // It converts LINQ (Language Integrated Query) expressions into SQL queries 
    // that the database can understand.

    // 2. Saving Changes: 
    // It tracks changes made to objects and applies them to the database when 
    // SaveChanges() or SaveChangesAsync() is called. This includes translating 
    // the changes into insert, update, or delete commands.

    // 3. Model Mapping: 
    // DbContext maps classes to database tables and properties to table columns 
    // through the ModelBuilder class, which is used in the OnModelCreating method.

    // 4. Change Tracking: 
    // DbContext tracks entities’ states during their lifecycle. This tracking 
    // ensures that only actual changes are updated in the database during 
    // a save operation, helping optimize database access and improve performance.

    public class EFCoreDbContext : DbContext
    {
        //Constructor calling the Base DbContext Class Constructor
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {
        }

        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        //Adding Domain Classes as DbSet Properties
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
