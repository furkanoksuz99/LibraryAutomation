using LibraryAutomation.DataAccess.Context;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.DataAccess.Repositories
{
    public class LoanRepository
    {
        public List<Loan> GetAllLoan()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Loans.ToList();

            }
        }

        public Loan GetById(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Loans.SingleOrDefault(x => x.Id == id);
            }
        }

        public void AddLoan(Loan loan)
        {
            using (var context = new LibraryDbContext())
            {
                try
                {
                    var book = context.Books
                        .FirstOrDefault(x => x.Id == loan.BookId);

                    if (book == null)
                        throw new Exception("Kitap bulunamadı.");

                    if (book.Stock <= 0)
                        throw new Exception("Kitabın stoğu bulunmuyor.");

                    var member = context.Members
                        .FirstOrDefault(x => x.Id == loan.MemberId);

                    if (member == null)
                        throw new Exception("Üye bulunamadı.");

                    var user = context.Users
                        .FirstOrDefault(x => x.Id == loan.UserId);

                    if (user == null)
                        throw new Exception("Kullanıcı bulunamadı.");

                    book.Stock--;

                    context.Loans.Add(loan);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Ödünç verme hatası: " +
                        ex.Message +
                        " | INNER: " +
                        (ex.InnerException != null
                            ? ex.InnerException.Message
                            : "InnerException yok"),
                        ex);
                }
            }
        }

        public void updateLoan(Loan loan)
        {
            using (var context = new LibraryDbContext())
            {
                var existingLoan = context.Loans
                    .FirstOrDefault(x => x.Id == loan.Id);

                if (existingLoan == null)
                    throw new Exception("Güncellenecek ödünç kaydı bulunamadı.");

                if (existingLoan.Status == LoanStatus.Returned)
                    throw new Exception("İade edilmiş kayıt güncellenemez.");

                var oldBook = context.Books
                    .FirstOrDefault(x => x.Id == existingLoan.BookId);

                var newBook = context.Books
                    .FirstOrDefault(x => x.Id == loan.BookId);

                if (oldBook == null)
                    throw new Exception("Eski kitap bulunamadı.");

                if (newBook == null)
                    throw new Exception("Yeni kitap bulunamadı.");

                // Kitap değiştirildiyse stokları düzenle
                if (existingLoan.BookId != loan.BookId)
                {
                    if (newBook.Stock <= 0)
                        throw new Exception("Seçilen yeni kitabın stoğu bulunmuyor.");

                    // Eski kitap tekrar stoğa girer
                    oldBook.Stock++;

                    // Yeni kitap stoktan düşer
                    newBook.Stock--;

                    existingLoan.BookId = loan.BookId;
                }

                existingLoan.MemberId = loan.MemberId;
                existingLoan.BorrowDate = loan.BorrowDate;
                existingLoan.DueDate = loan.DueDate;
                existingLoan.Notes = loan.Notes;

                context.SaveChanges();
            }
        }

        public void deleteLoan(int id)
        {
            using (var context = new LibraryDbContext())
            {
                var deletedValue = GetById(id);
                context.Loans.Remove(deletedValue);
                context.SaveChanges();
            }
        }

        public void ReturnBook(int loanId)
        {
            using (var context = new LibraryDbContext())
            {
                try
                {
                    var loan = context.Loans
                        .FirstOrDefault(x => x.Id == loanId);

                    if (loan == null)
                        throw new Exception("Ödünç kaydı bulunamadı.");

                    if (loan.Status == LoanStatus.Returned)
                        throw new Exception("Bu kitap zaten iade edilmiş.");

                    var book = context.Books
                        .FirstOrDefault(x => x.Id == loan.BookId);

                    if (book == null)
                        throw new Exception("Kitap bulunamadı.");

                    loan.ReturnDate = DateTime.Now;
                    loan.Status = LoanStatus.Returned;

                    book.Stock += 1;

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "İade işlemi hatası: " +
                        ex.Message +
                        " | Inner: " +
                        (ex.InnerException != null
                            ? ex.InnerException.Message
                            : "InnerException yok"),
                        ex);
                }
            }
        }
    }
}
