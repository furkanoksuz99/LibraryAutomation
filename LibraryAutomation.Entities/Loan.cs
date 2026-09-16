using System;

namespace LibraryAutomation.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int MemberId { get; set; }

        public int UserId { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public LoanStatus Status { get; set; }

        public string Notes { get; set; }

        public virtual Book Book { get; set; }

        public virtual Member Member { get; set; }

        public virtual User User { get; set; }
    }
}
