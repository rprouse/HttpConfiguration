using System;
using System.Runtime.InteropServices;

namespace Alteridem.Http.Service.Native
{

    /// <summary>
    /// The HTTP_SERVICE_CONFIG_SSL_SET structure is used to add a new record to the SSL store or retrieve an existing
    /// record from it. An instance of the structure is used to pass data in to the HTTPSetServiceConfiguration function
    /// through the pConfigInformation parameter or to retrieve data from the HTTPQueryServiceConfiguration function
    /// through the pOutputConfigInformation parameter when the ConfigId parameter of either function is equal to
    /// HTTPServiceConfigSSLCertInfo.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct HTTP_SERVICE_CONFIG_SSL_SET
    {
        /// <summary>
        /// An HTTP_SERVICE_CONFIG_SSL_KEY structure that identifies the SSL certificate record.
        /// </summary>
        HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;
        /// <summary>
        /// An HTTP_SERVICE_CONFIG_SSL_PARAM structure that holds the contents of the specified SSL certificate record.
        /// </summary>
        HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
    }

    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/aa364646(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct HTTP_SERVICE_CONFIG_SSL_KEY
    {
        IntPtr pIpPort;
    }

    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/aa364647(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct HTTP_SERVICE_CONFIG_SSL_PARAM
    {
        int SslHashLength;
        IntPtr pSslHash;
        Guid AppId;
        [MarshalAs(UnmanagedType.LPWStr)]
        string pSslCertStoreName;
        uint DefaultCertCheckMode;
        int DefaultRevocationFreshnessTime;
        int DefaultRevocationUrlRetrievalTimeout;
        [MarshalAs(UnmanagedType.LPWStr)]
        string pDefaultSslCtlIdentifier;
        [MarshalAs(UnmanagedType.LPWStr)]
        string pDefaultSslCtlStoreName;
        uint DefaultFlags;
    }
}
