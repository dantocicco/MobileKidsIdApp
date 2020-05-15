using System;

namespace MobileKidsIdApp.Models
{
    public class DistinguishingFeature
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public FileReference FileReference { get; set; }
    }
}
