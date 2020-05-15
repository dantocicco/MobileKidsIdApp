using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Platform;
using MobileKidsIdApp.Services;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class BasicDetailsViewModel : ViewModelBase
    {
        private readonly FamilyRepository _family;
        private readonly IContactPicker _contactPicker;

        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        private ContactInfo _contact;
        public ContactInfo Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        public Command ChangeContactCommand { get; private set; }

        public BasicDetailsViewModel(FamilyRepository family, IContactPicker contactPicker)
        {
            _family = family;
            _contactPicker = contactPicker;

            ChangeContactCommand = new Command(async () => ChangeContact());
        }

        private async Task ChangeContact()
        {
            ContactInfo contact = await _contactPicker.GetSelectedContactInfo();

            if (contact != null)
            {
                Contact = contact;

                //Only overwrite name fields if they were blank.
                if (string.IsNullOrEmpty(Model.FamilyName))
                    Model.FamilyName = contact.FamilyName;
                if (string.IsNullOrEmpty(Model.NickName))
                    Model.NickName = contact.NickName;
                if (string.IsNullOrEmpty(Model.AdditionalName))
                    Model.AdditionalName = contact.AdditionalName;
                if (string.IsNullOrEmpty(Model.GivenName))
                    Model.GivenName = contact.GivenName;
                if (string.IsNullOrEmpty(Model.ContactNameManual))
                    Model.ContactNameManual = contact.ContactNameManual;
                if (string.IsNullOrEmpty(Model.ContactPhoneManual))
                    Model.ContactPhoneManual = contact.ContactPhoneManual;
            }
        }
    }
}
