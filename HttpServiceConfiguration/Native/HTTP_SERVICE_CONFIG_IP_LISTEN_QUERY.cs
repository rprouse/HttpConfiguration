using System;
using System.Runtime.InteropServices;

namespace Alteridem.Http.Service.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY
    {
        public int AddrCount;
        public IntPtr AddrList;
    }
}
