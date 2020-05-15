using System.IO;
using MobileKidsIdApp.Platform;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class StaticContentViewModel : NotifyPropertyChanged
    {
        private string _title;
        public string Title
        { get { return _title; } set { _title = value; OnPropertyChanged("Title"); } }

        private HtmlWebViewSource _htmlSource;
        public HtmlWebViewSource HtmlSource
        {
            get { return _htmlSource; }
            private set { _htmlSource = value; OnPropertyChanged("HtmlSource"); }
        }
        public StaticContentViewModel(string contentName)
        {
            var contentHelper = DependencyService.Get<IWebViewContentHelper>();

            HtmlSource = new HtmlWebViewSource();

            try
            {
                HtmlSource.Html = contentHelper.LoadContentString(contentName);
            }
            catch (FileNotFoundException)
            {
                HtmlSource.Html = "<html><body><div><h1>Topic Not Found</h1><p>The requested topic was not found.</p></div></body></html>";
            }

            HtmlSource.BaseUrl = contentHelper.GetBaseUrl();
        }

    }
}