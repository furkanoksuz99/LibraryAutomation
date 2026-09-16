using LibraryAutomation.DataAccess.Context;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.DataAccess.Repositories
{
    public class MemberRepository
    {
        public List<Member> GetAllMembers()
        {
            using (var context = new LibraryDbContext())
            {
                return context.Members.ToList(); 
            }
        }

        public Member GetByIdMember(int id)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Members.SingleOrDefault(
                    member => member.Id == id);
            }
        }

        public void AddMember(Member member)
        {
            using (var context = new LibraryDbContext())
            {
                context.Members.Add(member);
                context.SaveChanges();
            }
        }

        public void RemoveMember(int memberId)
        {
            using (var context = new LibraryDbContext())
            {
                var member = context.Members
                    .FirstOrDefault(x => x.Id == memberId);

                if (member != null)
                {
                    member.IsActive = false;
                    context.SaveChanges();
                }
            }
        }

        public void UpdateMember(Member member)
        {
            using (var context = new LibraryDbContext())
            {
                var existingMember = context.Members
                    .FirstOrDefault(x => x.Id == member.Id);

                if (existingMember == null)
                {
                    throw new Exception("Güncellenecek üye bulunamadı.");
                }

                existingMember.FirstName = member.FirstName;
                existingMember.LastName = member.LastName;
                existingMember.Email = member.Email;
                existingMember.Phone = member.Phone;
                existingMember.Address = member.Address;
                existingMember.BirthDate = member.BirthDate;
                existingMember.IsActive = member.IsActive;

                context.SaveChanges();
            }
        }

        public bool MemberNumberExists(string memberNumber)
        {
            using (var context = new LibraryDbContext())
            {
                return context.Members
                    .Any(m => m.MemberNumber == memberNumber);
            }
        }
    }
}
