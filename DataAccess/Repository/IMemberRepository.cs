using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        List<MemberObject> getListMember();
        public MemberObject GetMemberById(int id);
        public MemberObject GetMemberByEP(string email, string password);
        void Add(MemberObject member);
        void Update(MemberObject member);
        void Delete(int id);
        
    }
}
