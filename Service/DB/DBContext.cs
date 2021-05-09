using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DB
{
    public class DBContext : DbContext 
    {
        public DbSet<BooksEntity> Books { get; set; }
        public DbSet<AuthorsEntity> Authors { get; set; }
        public DbSet<AccountEntity> Account { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksEntity>().ToTable("BooksEntity");
            modelBuilder.Entity<AuthorsEntity>().ToTable("AuthorsEntity");
            modelBuilder.Entity<AccountEntity>().ToTable("AccountEntity");
        }

        public System.Data.Entity.DbSet<WebApp_Book.Models.AuthorsView> AuthorsViews { get; set; }

        public System.Data.Entity.DbSet<WebApp_Book.Models.RegisterView> RegisterViews { get; set; }
    }
}
