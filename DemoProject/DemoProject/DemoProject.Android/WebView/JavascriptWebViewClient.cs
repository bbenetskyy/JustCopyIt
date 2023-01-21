using Xamarin.Forms.Platform.Android;

namespace DemoProject.Droid.WebView
{
    public class JavascriptWebViewClient : FormsWebViewClient
    {
        private readonly string _javascript;

        public JavascriptWebViewClient(CustomWebViewRenderer renderer, string javascript) : base(renderer)
        {
            _javascript = javascript;
        }

        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.EvaluateJavascript(_javascript, null);
        }
    }
}