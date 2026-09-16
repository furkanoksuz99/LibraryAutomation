using LibraryAutomation.DataAccess.Context;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.DataAccess.Repositories
{
    public class BookRepository
    {
        public List<Book> GetAll()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Books.ToList();
            }

        }

        public Book GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Books.FirstOrDefault(b => b.Id == id);
            }
        }

        public void Add(Book book)
        {
            using (var context = new LibraryDbContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            using (var context = new LibraryDbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public void Update(Book book)
        {
            using (var context = new LibraryDbContext())
            {
                var existingBook = context.Books.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.ISBN = book.ISBN;
                    existingBook.Loans = book.Loans;
                    existingBook.Author = book.Author;
                    existingBook.CategoryId = book.CategoryId;
                    existingBook.Name = book.Name;
                    existingBook.PageCount = book.PageCount;
                    existingBook.Publisher = book.Publisher;
                    existingBook.PublishYear = book.PublishYear;
                    existingBook.Stock = book.Stock;
                    existingBook.IsActive = book.IsActive;
                    context.SaveChanges();
                }
            }
        }
    }
}
