using System.Runtime.InteropServices;

namespace Alteridem.Http.Service.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct HTTP_SERVICE_CONFIG_SSL_QUERY
    {
        public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;
        public HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;
        public uint dwToken;
    }
}
