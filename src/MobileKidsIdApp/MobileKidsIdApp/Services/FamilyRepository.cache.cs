using System.Collections.Generic;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.Services
{
    public partial class FamilyRepository
    {
        public List<Child> Family { get; } = new List<Child>();
    }
}
