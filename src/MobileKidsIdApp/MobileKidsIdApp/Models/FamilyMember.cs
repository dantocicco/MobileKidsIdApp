using System;

namespace MobileKidsIdApp.Models
{
    public class FamilyMember
    {
        public Guid Id { get; set; }

        // TODO: What is the purpose of this? 
        public string ContactId { get; set; }

        public string Relation { get; set; }
    }
}
