using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class ChildProfileItemPage : ContentPage
    {
        public ChildProfileItemPage() => InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ViewModels.IViewModel)BindingContext).SetActiveView();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var vm = (ViewModels.ChildProfileItem)BindingContext;
            if (vm.Model.IsNew)
                await ((ViewModels.IViewModel)BindingContext).CloseView();
            else
                await ((ViewModels.IViewModel)BindingContext).CloseView(true);
        }
    }
}
