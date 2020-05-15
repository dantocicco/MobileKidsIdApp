using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class BasicDetailsPage : ContentPage
    {
        public BasicDetailsPage() => InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //((ViewModels.IViewModel)BindingContext).SetActiveView();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            //await ((ViewModels.IViewModel)BindingContext).CloseView();
        }
    }
}
