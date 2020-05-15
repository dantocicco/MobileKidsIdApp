namespace MobileKidsIdApp.ViewModels
{
    public class FriendInfo
    {
        public FriendInfo(ContactInfo contact)
        {
            FamilyName = contact.FamilyName;
            GivenName = contact.GivenName;
            AdditionalName = contact.AdditionalName;

            Display = $"{GivenName} {FamilyName}";
        }

        public string FamilyName { get; }
        public string GivenName { get; }
        public string AdditionalName { get; }
        public string Display { get; set; }
    }
}
