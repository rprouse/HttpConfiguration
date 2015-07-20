using Alteridem.Http.Service.Native;
using System;

namespace Alteridem.Http.Service
{
    public class HttpConfiguration : IDisposable
    {
        bool _initialized;

        public HttpConfiguration()
        {
            uint retVal = NativeMethods.HttpInitialize(NativeMethods.HTTPAPI_VERSION_1, NativeMethods.HTTP_INITIALIZE_CONFIG, IntPtr.Zero);
            if (retVal == ReturnCodes.NO_ERROR)
            {
                _initialized = true;
            }
        }

        #region IDisposable Support

        bool _disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                if(_initialized)
                {
                    NativeMethods.HttpTerminate(NativeMethods.HTTP_INITIALIZE_CONFIG, IntPtr.Zero);
                }

                _disposed = true;
            }
        }

        ~HttpConfiguration()
        {
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
