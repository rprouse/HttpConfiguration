// **********************************************************************************
// The MIT License (MIT)
//
// Copyright (c) 2015 Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// **********************************************************************************

using Alteridem.Http.Service.Native;
using System;

namespace Alteridem.Http.Service
{
    public class HttpConfiguration : IDisposable
    {
        bool _initialized;

        public HttpConfiguration()
        {
            uint retVal = NativeMethods.HttpInitialize(HTTPAPI_VERSION.VERSION_1, Flags.HTTP_INITIALIZE_CONFIG, IntPtr.Zero);
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
                    NativeMethods.HttpTerminate(Flags.HTTP_INITIALIZE_CONFIG, IntPtr.Zero);
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
