using System;

namespace JustCopyIt.Services
{
    public interface ILogger
    {
        void LogError(Exception ex);
    }
}