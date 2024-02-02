using System;

namespace BusinessObject
{
    //MemberID, MemberName, Email, Password, City, Country
    public class MemberObject 
    {
        public int MemberID { get; set; }
        public string MemberName{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string City{ get; set; }
        public  string Country{ get; set; }

        public static Comparison<MemberObject> NameComparison = (m1, m2) => m1.MemberName.CompareTo(m2.MemberName);
        public static Comparison<MemberObject> NameComparisonDesc = (m1, m2) => m2.MemberName.CompareTo(m1.MemberName);

    }
}
