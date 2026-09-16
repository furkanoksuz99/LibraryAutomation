using System.Data.Entity;
using LibraryAutomation.Entities;
using MySql.Data.EntityFramework;

namespace LibraryAutomation.DataAccess.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
            : base("name=LibraryDbContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Loan>()
                .HasRequired(x => x.Book)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.BookId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Loan>()
                .HasRequired(x => x.Member)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Loan>()
                .HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}