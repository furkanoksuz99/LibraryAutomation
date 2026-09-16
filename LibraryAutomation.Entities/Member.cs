using System;
using System.Collections.Generic;

namespace LibraryAutomation.Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MemberNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }

        public Member()
        {
            Loans = new HashSet<Loan>();
        }
    }
}
