using System;
using System.Collections.Generic;

namespace MobileKidsIdApp.Models
{
    public partial class Child
    {
        public Guid Id { get; set; }

        public string GivenName { get; set; }

        public string NickName { get; set; }

        public string AdditionalName { get; set; }

        public string FamilyName { get; set; }

        public DateTime Birthday { get; set; }

        public string ContactID { get; set; }

        public string ContactNameManual { get; set; }

        public string ContactPhoneManual { get; set; }

        public List<DistinguishingFeature> DistinguishingFeatures { get; set; } = new List<DistinguishingFeature>();

        public List<CareProvider> ProfessionalCareProviders { get; set; }

        public List<FamilyMember> FamilyMembers { get; set; }

        public List<Friend> Friends { get; set; }

        public List<FileReference> Documents { get; set; }

        public List<FileReference> Photos { get; set; }
    }
}
