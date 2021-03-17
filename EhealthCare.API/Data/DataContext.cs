using EhealthCare.API.Models;
using Microsoft.EntityFrameworkCore;


namespace EhealthCare.API.Data
{
    public class DataContext : DbContext   
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Value> Values {get; set;}

        public DbSet<Admin> Admin {get; set;}

        public DbSet<Doctors> Doctor {get; set;}

        public DbSet<Patients> Patient {get; set;}
        

    }
}