using System.Threading.Tasks;

namespace MobileKidsIdApp.Platform
{
    public interface IContactPicker
    {
        Task<ViewModels.ContactInfo> GetSelectedContactInfo();

        Task<ViewModels.ContactInfo> GetContactInfoForId(string id);
    }
}
