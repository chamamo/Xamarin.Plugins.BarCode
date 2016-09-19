using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Plugins.BarCode.Abstractions
{
    public interface IBarCode : IDisposable
    {
        Task<BarCodeResult> ReadAsync(BarCodeReadConfiguration config = null,
            CancellationToken cancelToken = default(CancellationToken));
    }
}
