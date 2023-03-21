using desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio.Data
{
    //representacao do banco de memoria
    public class AppDbContext : DbContext
    {
        //criar o dbset para as classes da model 
        //para saber que tem que fazer o mapeamento
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductLog> ProductLogs { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder) 
            =>  optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
            
    }
}

