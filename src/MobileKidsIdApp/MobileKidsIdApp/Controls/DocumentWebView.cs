using Xamarin.Forms;

namespace MobileKidsIdApp
{
    public class DocumentWebView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(
            propertyName: nameof(Uri),
            returnType: typeof(string),
            declaringType: typeof(DocumentWebView),
            defaultValue: default(string));

        public string Uri
        {
            get => (string)GetValue(UriProperty);
            set => SetValue(UriProperty, value);
        }
    }
}
