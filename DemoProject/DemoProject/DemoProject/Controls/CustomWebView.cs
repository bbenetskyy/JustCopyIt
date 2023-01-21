using Xamarin.Forms;

namespace DemoProject.Controls
{
    public class CustomWebView : WebView
    {
        #region XamlValue

        public static readonly BindableProperty XamlValueProperty = BindableProperty.Create(
            propertyName: nameof(XamlValue), 
            returnType: typeof(string), 
            declaringType: typeof(CustomWebView), 
            propertyChanged: XamlValuePropertyChanged);
        
        public string XamlValue
        {
            get => (string)GetValue(XamlValueProperty);
            set => SetValue(XamlValueProperty, value);
        }

        private static void XamlValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CustomWebView webView && newValue is string value)
            {
                Device.InvokeOnMainThreadAsync(async () => await webView.EvaluateJavaScriptAsync($"SetXamlValue('{value}')"));
            }
        }

        #endregion XamlValue
        
        #region JSValue

        public static readonly BindableProperty JSValueProperty = BindableProperty.Create(
            propertyName: nameof(JSValue), 
            returnType: typeof(string), 
            declaringType: typeof(CustomWebView));
        
        public string JSValue
        {
            get => (string)GetValue(JSValueProperty);
            set => SetValue(JSValueProperty, value);
        }
        
        public void InvokeJSValueAction(string value)
        {
            JSValue = value;
        }

        #endregion JSValue
    }
}