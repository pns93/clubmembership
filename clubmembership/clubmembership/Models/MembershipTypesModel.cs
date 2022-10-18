namespace clubmembership.Models
{
    public class MembershipTypesModel
    {
        public Guid IdmembershipType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int SubscriptionLengthInMonths { get; set; }
    }
}
