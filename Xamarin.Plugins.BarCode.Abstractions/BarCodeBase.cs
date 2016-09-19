using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Plugins.BarCode.Abstractions
{
    public class BarCodeBase : IDisposable
    {
        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose up
        /// </summary>
        ~BarCodeBase()
        {
            Dispose(false);
        }
        private bool disposed = false;
        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose only
                }

                disposed = true;
            }
        }
    }
}
