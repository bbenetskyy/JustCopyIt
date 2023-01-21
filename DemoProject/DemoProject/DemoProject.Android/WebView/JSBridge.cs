using System;
using Android.Webkit;
using DemoProject.Controls;
using Java.Interop;

namespace DemoProject.Droid.WebView
{
    public class JSBridge : Java.Lang.Object
    {
        readonly WeakReference<CustomWebViewRenderer> _hybridWebViewRenderer;

        public JSBridge(CustomWebViewRenderer hybridRenderer)
        {
            _hybridWebViewRenderer = new WeakReference<CustomWebViewRenderer>(hybridRenderer);
        }

        [Export]
        [JavascriptInterface]
        public void InvokeJSValueAction(string value)
        {
            if (_hybridWebViewRenderer != null && _hybridWebViewRenderer.TryGetTarget(out CustomWebViewRenderer hybridRenderer))
            {
                ((CustomWebView)hybridRenderer.Element).InvokeJSValueAction(value);
            }
        }
    }
}