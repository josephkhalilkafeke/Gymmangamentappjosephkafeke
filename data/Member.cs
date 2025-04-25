namespace finalprojectjosephkafekecprg211.Data
{
    public class Member : Iperson
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime MembershipExpires { get; set; }
    }
}