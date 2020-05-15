using System;

namespace MobileKidsIdApp.Models
{
    public class CareProvider
    {
        public Guid Id { get; set; }

        public string ProviderName { get; set; }

        public string ClinicName { get; set; }

        public string CareRoleDescription { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
