using LibraryAutomation.DataAccess.Repositories;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Business.Managers
{
    public class BookManager
    {
        private readonly BookRepository _bookRepository;

        public BookManager()
        {
            _bookRepository = new BookRepository();
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public bool DeleteBook(int id)
        {
            return _bookRepository.Delete(id);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

    }
}
