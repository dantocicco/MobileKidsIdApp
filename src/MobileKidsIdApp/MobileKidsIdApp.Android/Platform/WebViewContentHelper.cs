using MobileKidsIdApp.Platform;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.Droid.Platform.WebViewContentHelper))]
namespace MobileKidsIdApp.Droid.Platform
{
    Platform
    public class WebViewContentHelper : WebViewContentHelperBase
    {
        public override string GetBaseUrl()
        {
            return "file:///android_asset/";
        }
    }
}
