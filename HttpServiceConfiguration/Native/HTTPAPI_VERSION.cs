using System.Runtime.InteropServices;

namespace Alteridem.Http.Service.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    struct HTTPAPI_VERSION
    {
        public ushort HttpApiMajorVersion;
        public ushort HttpApiMinorVersion;

        public HTTPAPI_VERSION(ushort majorVersion, ushort minorVersion)
        {
            HttpApiMajorVersion = majorVersion;
            HttpApiMinorVersion = minorVersion;
        }

        public static HTTPAPI_VERSION VERSION_1
        {
            get { return new HTTPAPI_VERSION(1, 0); }
        }
    }
}
