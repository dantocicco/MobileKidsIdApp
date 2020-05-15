using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _passwordConfirm;
        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set => SetProperty(ref _passwordConfirm, value);
        }

        private bool _firstRun;
        public bool FirstRun
        {
            get => _firstRun;
            set => SetProperty(ref _firstRun, value);
        }

        private bool _invalidPassword;
        public bool InvalidPassword
        {
            get => _invalidPassword;
            set => SetProperty(ref _invalidPassword, value);
        }

        private bool _passwordMustMatch;
        public bool PasswordsMustMatch
        {
            get => _passwordMustMatch;
            set => SetProperty(ref _passwordMustMatch, value);
        }

        public Command SigninCommand { get; private set; }

        public LoginViewModel()
        {
            SigninCommand = new Command(async () => await DoAuthentication());
        }

        private void SetFirstRun()
        {
            var cmd = Csla.DataPortal.Fetch<Models.FamilyExists>();
            FirstRun = !cmd.Exists;
            OnPropertyChanged("FirstRun");
        }

        private async Task DoAuthentication()
        {
            if (FirstRun)
            {
                if (Password != PasswordConfirm)
                {
                    PasswordsMustMatch = true;
                    OnPropertyChanged("PasswordsMustMatch");
                    return;
                }
                else
                {
                    PasswordsMustMatch = true;
                    OnPropertyChanged("PasswordsMustMatch");
                }
            }
            var identity = await Models.AppIdentity.LoginAsync(Password);
            Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
            if (Csla.ApplicationContext.User.Identity.IsAuthenticated)
            {
                SetRootPage?.Invoke();
            }
            else
            {
                InvalidPassword = true;
                OnPropertyChanged("InvalidPassword");
            }
        }
    }
}
