using MvvmCross.ViewModels;

namespace DemoProject.PageModels
{
    public class WebViewPageModel : MvxViewModel
    {
        private string _jSCounterValue = "### COUNTER VALUE ###";
        public string JSCounterValue
        {
            get => _jSCounterValue;
            set => SetProperty(ref _jSCounterValue, value);
        }


        public string HtmlSource { get; } = @"
<html>
<head>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
        </head>

        <body>
        <div>
        This is text from XAML: <div id=""place-for-text""></div>
        </div>
        <a href=""#"" onclick=""Count();"">Press To Count</a>
        <div id=""counterText""></div>
        <script type=""text/javascript"">
         var counter = 0;
        function Count() {
            try {
                counter++;
                document.getElementById(""counterText"").innerText = counter;
                CounterResult(counter);
            } catch (err) {
                alert(err);
            }
        }

        function SetXamlValue(text) {
            document.getElementById(""place-for-text"").innerText = text;
        }
//this is example of adding listeners: 
//document.getElementById(""btn-id"").addEventListener(""click"",() => InvokeXAMLAction());
        </script>
        </body>
        </html>
";
    }
}