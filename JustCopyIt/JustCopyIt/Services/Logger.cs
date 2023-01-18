using System;
using System.Diagnostics;

namespace JustCopyIt.Services
{
    public class Logger : ILogger
    {
        public void LogError(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }
    }
}