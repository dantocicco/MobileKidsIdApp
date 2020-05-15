using Foundation;
using MobileKidsIdApp.Platform;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Platform.WebViewContentHelper))]
namespace MobileKidsIdApp.iOS.Platform
{
    public class WebViewContentHelper : WebViewContentHelperBase
    {
        public override string GetBaseUrl()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}
