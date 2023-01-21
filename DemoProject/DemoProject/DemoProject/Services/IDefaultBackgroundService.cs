using System;
using System.Threading;

namespace DemoProject.Services
{
    public interface IDefaultBackgroundService
    {
        CancellationTokenSource TokenSource { get; }
        void Start();
        void Stop();
    }
}

