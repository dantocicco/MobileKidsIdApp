using Csla.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ProfessionalCareProvidersViewModel : ViewModelBase<Models.CareProviderList>
    {
        public ICommand NewItemCommand { get; private set; }

        public ProfessionalCareProvidersViewModel(Models.CareProviderList list)
        {
            NewItemCommand = new Command(() => BeginAddNew());

            Model = list;
        }
    }
}
