using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace DataAccess
{
    public class MemberDAO
    {
        private List<MemberObject> ListMember = new List<MemberObject>
        {
            new MemberObject(){ MemberID = 1, MemberName="vu", Email="vu@gmail.com", Password="123", City="Ha Noi", Country="Viet Nam" },
            new MemberObject(){ MemberID = 2, MemberName="truong", Email="truong@gmail.com", Password="456", City="Ho Chi Minh", Country="Viet Nam" },
            new MemberObject(){ MemberID = 3, MemberName="an", Email="an@gmail.com", Password="789", City="Tokyo", Country="Japan" },
         };
        private static MemberDAO instance;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public List<MemberObject> getListMember()
        {
            ListMember.Sort(MemberObject.NameComparison);
            return ListMember;
        }

        public MemberObject GetMemberById(int id)
        {
            MemberObject member = null;
            member = ListMember.SingleOrDefault(x => x.MemberID == id);
            return member;
        }

        // create 
        public void Add(MemberObject member)
        {
            if (GetMemberById(member.MemberID) == null)
            {
                ListMember.Add(member);
            }
            else
            {
                throw new Exception("Add faild: have that id in List ");
            }
        }
        // update 
        public void Update(MemberObject member)
        {
            MemberObject mem = GetMemberById(member.MemberID);
            if (GetMemberById(member.MemberID) != null)
            {
                var index = ListMember.IndexOf(mem);
                ListMember[index] = member;
            }
            else
            {
                throw new Exception("Update faild: does not have that id in List ");
            }
        }
        // delete
        public void Delete(int id)
        {
            MemberObject mem = GetMemberById(id);
            if (mem != null)
            {
                ListMember.Remove(mem);
            }
            else
            {
                throw new Exception("Delete faild: does not have that id in List ");
            }

        }

        internal MemberObject GetMemberByEP(string email, string password)
        {
            MemberObject member = null;
            member = ListMember.SingleOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            return member;
        }
    }
}

