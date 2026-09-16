using System;
using System.Collections.Generic;

namespace LibraryAutomation.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Publisher { get; set; }

        public int PublishYear { get; set; }

        public int PageCount { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }

        public Book()
        {
            Loans = new HashSet<Loan>();
        }
    }
}
