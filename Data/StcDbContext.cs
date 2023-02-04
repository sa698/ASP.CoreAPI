using Microsoft.EntityFrameworkCore;
using StcWebApi.Models;
 
using StcWebApi.Models.Cutomer;

namespace StcWebApi.Data
{
    public class StcDbContext:DbContext
    {
        public StcDbContext(DbContextOptions <StcDbContext> options):base (options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
  
        public DbSet<Customer> customers { get; set; }
       
       
    }
}
