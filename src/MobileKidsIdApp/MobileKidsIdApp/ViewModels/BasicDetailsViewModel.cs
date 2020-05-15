using System.Threading.Tasks;
using System.Windows.Input;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Platform;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class BasicDetailsViewModel : ViewModelBase
    {
        private ContactInfo _contact;

        public ICommand ChangeContactCommand { get; private set; }

        public BasicDetailsViewModel(Child details)
        {
            ChangeContactCommand = new Command(async () =>
            {
                PrepareToShowModal();
                ContactInfo contact = await DependencyService.Get<IContactPicker>().GetSelectedContactInfo();
                if (contact == null)
                {
                    //Do nothing, user must have cancelled.
                }
                else
                {
                    _contact = contact;
                    Model.ContactId = contact.Id;

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

                    OnPropertyChanged(nameof(Contact));
                }
            });

            Model = details;
        }
        
        protected override async Task<ChildDetails> DoInitAsync()
        {
            if (!string.IsNullOrWhiteSpace(Model.ContactId))
            {
                _contact = await DependencyService.Get<IContactPicker>().GetContactInfoForId(Model.ContactId);
            }
            return Model;
        }

        public ContactInfo Contact { get { return _contact; } }
    }
}
