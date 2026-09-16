using LibraryAutomation.DataAccess.Repositories;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Business.Managers
{
    public class LoanManager
    {
        private readonly LoanRepository _loanRepository;
        public LoanManager()
        {
            _loanRepository = new LoanRepository();
        }
        public List<Loan> GetAllLoans()
        {
            return _loanRepository.GetAllLoan();
        }
        public Loan GetLoanById(int id)
        {
            return _loanRepository.GetById(id);
        }
        public void AddLoan(Loan loan)
        {
            _loanRepository.AddLoan(loan);
        }
        public void UpdateLoan(Loan loan)
        {
            _loanRepository.updateLoan(loan);
        }
        public void DeleteLoan(int id)
        {
            _loanRepository.deleteLoan(id);
        }

        public void ReturnBook(int loanId)
        {
            _loanRepository.ReturnBook(loanId);
        }
    }
}
