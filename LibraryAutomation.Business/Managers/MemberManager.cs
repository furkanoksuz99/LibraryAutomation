using LibraryAutomation.DataAccess.Repositories;
using LibraryAutomation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Business.Managers
{
    public class MemberManager
    {
        private readonly MemberRepository _memberRepository;

        public MemberManager()
        {
            _memberRepository = new MemberRepository();
          
        }
        
        public List<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        public Member GetMemberById(int id)
        {
            return _memberRepository.GetByIdMember(id);
        }

        public void AddMember(Member member)
        {
            _memberRepository.AddMember(member);
        }

        public void RemoveMember(int id)
        {
            _memberRepository.RemoveMember(id);
        }

        public void UpdateMember(Member member)
        { 
            _memberRepository.UpdateMember(member);
        }

        public bool MemberNumberExists(string memberNumber)
        {
            return _memberRepository.MemberNumberExists(memberNumber);
        }
    }
}
