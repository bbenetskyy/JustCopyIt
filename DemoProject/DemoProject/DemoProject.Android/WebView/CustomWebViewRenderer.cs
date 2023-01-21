using System;
using Android.Content;
using DemoProject.Controls;
using DemoProject.Droid.WebView;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]

namespace DemoProject.Droid.WebView
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        private const string JAVASCRIPT_FUNCTION = "function CounterResult(result){ Xamarin.InvokeJSValueAction(result); } ";
        
        public CustomWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (Element is CustomWebView webView)
            {
                if (e.OldElement != null)
                {
                    Control.RemoveJavascriptInterface("Xamarin");
                }
                if (e.NewElement != null)
                {

                    Control.SetWebViewClient(new JavascriptWebViewClient(this, $"javascript: {JAVASCRIPT_FUNCTION}"));
                    Control.AddJavascriptInterface(new JSBridge(this), "Xamarin");
                    
                }
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.JavaScriptEnabled = true;
#if DEBUG
                global::Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);
#endif
            }
        }
        
        private bool _isDisposed;
        protected override void Dispose(bool disposing)
        {
            //this is optional, but now we ensure we clear now
            
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            base.Dispose(disposing);
            GC.SuppressFinalize(this);
        }
    }
}