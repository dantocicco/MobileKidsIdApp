using System.Threading.Tasks;
using MobileKidsIdApp.Services;
using MobileKidsIdApp.ViewModels;
using MobileKidsIdApp.Views;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileKidsIdApp
{
    public partial class App : ApplicationBase
    {
        public App() => InitializeComponent();

        protected override void InitializeContainer()
        {
            Container.RegisterSingleton<AuthenticationService>();
            Container.RegisterSingleton<FamilyRepository>();
        }

        protected override Task<Page> CreateMainPage()
            => CreatePage<LoginPage, LoginViewModel>();
    }
}
