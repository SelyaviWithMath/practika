using Microsoft.EntityFrameworkCore;
using System.IO;
using BMILibrary.Entity;

namespace BMILibrary
{
    public class ApplicationContext : DbContext //Главный класс для взаимодействия с базой данных
    {
        public DbSet<Bdbmi> Bdbmi{ get; set; }//Assign с таблицами баз данных (1 - Bdbmi)
        

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)//Конструктор для создания ... чтоб пользоваться базой данных
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Для заноса ручками базы данных(EntityConfigure)
        {
           
            modelBuilder.Entity<Bdbmi>(EntityConfigure.BdbmiConfigure);
        }
        
    }

}
