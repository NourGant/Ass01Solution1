using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void Add(MemberObject member) => MemberDAO.Instance.Add(member);

        public void Delete(int id) => MemberDAO.Instance.Delete(id);

        public List<MemberObject> getListMember() => MemberDAO.Instance.getListMember();

        public MemberObject GetMemberByEP(string email, string password) => MemberDAO.Instance.GetMemberByEP(email, password);

        public MemberObject GetMemberById(int id) => MemberDAO.Instance.GetMemberById(id);

        public void Update(MemberObject member) => MemberDAO.Instance.Update(member);
    }
}
