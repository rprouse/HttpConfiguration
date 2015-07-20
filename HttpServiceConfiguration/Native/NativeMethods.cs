using System;
using System.Runtime.InteropServices;

namespace Alteridem.Http.Service.Native
{

    internal class NativeMethods
    {
        public const uint HTTP_INITIALIZE_CONFIG = 0x00000002;

        public static HTTPAPI_VERSION HTTPAPI_VERSION_1
        {
            get { return new HTTPAPI_VERSION(1, 0); }
        }

        #region HTTP_SERVICE_CONFIG_ID

        public enum HTTP_SERVICE_CONFIG_ID
        {
            /// <summary>
            /// Specifies the IP Listen List used to register IP addresses on which to listen for SSL connections.
            /// </summary>
            HttpServiceConfigIPListenList = 0,
            /// <summary>
            /// Specifies the SSL certificate store.
            /// </summary>
            /// <remarks>
            /// Note:  If SSL is enabled in the HTTP Server API, TLS 1.0 may be used in place of SSL when the client
            /// application specifies TLS.
            /// </remarks>
            HttpServiceConfigSSLCertInfo = 1,
            /// <summary>
            /// Specifies the URL reservation store.
            /// </summary>
            HttpServiceConfigUrlAclInfo = 2,
            /// <summary>
            /// Configures the HTTP Server API wide connection timeouts.
            /// </summary>
            /// <remarks>
            /// Note:  Windows Vista and later versions of Windows
            /// </remarks>
            HttpServiceConfigTimeout = 3,
            /// <summary>
            /// Used in the HttpQueryServiceConfiguration and HttpSetServiceConfiguration functions.
            /// </summary>
            /// <remarks>
            /// Note:  Windows Server 2008 R2 and Windows 7 and later versions of Windows.
            /// </remarks>
            HttpServiceConfigCache = 4,
            /// <summary>
            /// Specifies the SSL endpoint configuration with Hostname:Port as key. Used in the HttpDeleteServiceConfiguration,
            /// HttpQueryServiceConfiguration, and HttpSetServiceConfiguration functions
            /// </summary>
            /// <remarks>
            /// Note:  Windows 8 and later versions of Windows.
            /// </remarks>
            HttpServiceConfigSslSniCertInfo = 5,
            /// <summary>
            /// Terminates the enumeration; is not used to define a service configuration option.
            /// </summary>
            HttpServiceConfigMax = 6
        }

        #endregion

        #region HTTP_SERVICE_CONFIG_URLACL_SET

        /// <summary>
        /// The HTTP_SERVICE_CONFIG_URLACL_SET structure is used to add a new record to the URL reservation store or
        /// retrieve an existing record from it. An instance of the structure is used to pass data in through the pConfigInformation
        /// parameter of the HTTPSetServiceConfiguration function, or to retrieve data through the pOutputConfigInformation parameter
        /// of the HTTPQueryServiceConfiguration function when the ConfigId parameter of either function is equal to HTTPServiceConfigUrlAclInfo.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HTTP_SERVICE_CONFIG_URLACL_SET
        {
            /// <summary>
            /// An HTTP_SERVICE_CONFIG_URLACL_KEY structure that identifies the URL reservation record.
            /// </summary>
            HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;
            /// <summary>
            /// An HTTP_SERVICE_CONFIG_URLACL_PARAM structure that holds the contents of the specified URL reservation record.
            /// </summary>
            HTTP_SERVICE_CONFIG_URLACL_PARAM ParamDesc;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_URLACL_KEY
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            string pUrlPrefix;

            HTTP_SERVICE_CONFIG_URLACL_KEY(string urlPrefix)
            {
                pUrlPrefix = urlPrefix;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_URLACL_PARAM
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            string pStringSecurityDescriptor;

            HTTP_SERVICE_CONFIG_URLACL_PARAM(string securityDescriptor)
            {
                pStringSecurityDescriptor = securityDescriptor;
            }
        }

        #endregion

        #region HTTP_SERVICE_CONFIG_SSL_SET

        /// <summary>
        /// The HTTP_SERVICE_CONFIG_SSL_SET structure is used to add a new record to the SSL store or retrieve an existing
        /// record from it. An instance of the structure is used to pass data in to the HTTPSetServiceConfiguration function
        /// through the pConfigInformation parameter or to retrieve data from the HTTPQueryServiceConfiguration function
        /// through the pOutputConfigInformation parameter when the ConfigId parameter of either function is equal to
        /// HTTPServiceConfigSSLCertInfo.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HTTP_SERVICE_CONFIG_SSL_SET
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
        public struct HTTP_SERVICE_CONFIG_SSL_KEY
        {
            IntPtr pIpPort;
        }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/aa364647(v=vs.85).aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_SSL_PARAM
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

        #endregion

        #region HTTPAPI_VERSION

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct HTTPAPI_VERSION
        {
            public ushort HttpApiMajorVersion;
            public ushort HttpApiMinorVersion;

            public HTTPAPI_VERSION(ushort majorVersion, ushort minorVersion)
            {
                HttpApiMajorVersion = majorVersion;
                HttpApiMinorVersion = minorVersion;
            }
        }

        #endregion

        #region HTTP Server API Version 1.0 Configuration Functions

        /// <summary>
        /// The HttpInitialize function initializes the HTTP Server API driver, starts it, if it has not already been started, and
        /// allocates data structures for the calling application to support response-queue creation and other operations. Call this
        /// function before calling any other functions in the HTTP Server API.
        /// </summary>
        /// <param name="Version">HTTP version. This parameter is an HTTPAPI_VERSION structure. For the current version, declare
        /// an instance of the structure and set it to the pre-defined value HTTPAPI_VERSION_1 before passing it to HttpInitialize.</param>
        /// <param name="Flags">Initialization options</param>
        /// <param name="pReserved">This parameter is reserved and must be NULL.</param>
        /// <returns>If the function succeeds, the return value is NO_ERROR.</returns>
        [DllImport("httpapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint HttpInitialize(HTTPAPI_VERSION Version, uint Flags, IntPtr pReserved);

        /// <summary>
        /// The HttpTerminate function cleans up resources used by the HTTP Server API to process calls by an application. An application
        /// should call HttpTerminate once for every time it called HttpInitialize, with matching flag settings.
        /// </summary>
        /// <param name="Flags">Termination options.</param>
        /// <param name="pReserved">This parameter is reserved and must be NULL.</param>
        /// <returns>If the function succeeds, the return value is NO_ERROR.</returns>
        [DllImport("httpapi.dll", SetLastError = true)]
        public static extern uint HttpTerminate(uint Flags, IntPtr pReserved);

        /// <summary>
        /// The HttpQueryServiceConfiguration function retrieves one or more HTTP Server API configuration records.
        /// </summary>
        /// <remarks>https://msdn.microsoft.com/en-us/library/aa364491(v=vs.85).aspx</remarks>
        /// <param name="ServiceHandle">Reserved. Must be zero.</param>
        /// <param name="ConfigId">Type of configuration record to be set. This parameter can be one of the following values from the
        /// HTTP_SERVICE_CONFIG_ID enumeration.</param>
        /// <param name="pInputConfigInfo">A pointer to a structure whose contents further define the query and of the type that correlates
        /// with ConfigId in the following table.</param>
        /// <param name="InputConfigInfoLength">Size, in bytes, of the pInputConfigInfo buffer.</param>
        /// <param name="pOutputConfigInfo">A pointer to a buffer in which the query results are returned. The type of this buffer correlates
        /// with ConfigId.</param>
        /// <param name="OutputConfigInfoLength">Size, in bytes, of the pOutputConfigInfo buffer.</param>
        /// <param name="pReturnLength">A pointer to a variable that receives the number of bytes to be written in the output buffer. If the
        /// output buffer is too small, the call fails with a return value of ERROR_INSUFFICIENT_BUFFER. The value pointed to by pReturnLength
        /// can be used to determine the minimum length the buffer requires for the call to succeed.</param>
        /// <param name="pOverlapped">This parameter is reserved and must be NULL</param>
        /// <returns>If the function succeeds, the function returns NO_ERROR.</returns>
        [DllImport("httpapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint HttpQueryServiceConfiguration(
            IntPtr ServiceHandle,
            HTTP_SERVICE_CONFIG_ID ConfigId,
            [Optional] IntPtr pInputConfigInfo,
            [Optional] int InputConfigInfoLength,
            [In, Out, Optional] IntPtr pOutputConfigInfo,
            [Optional] int OutputConfigInfoLength,
            [Out, Optional] int pReturnLength,
            IntPtr pOverlapped);

        /// <summary>
        /// The HttpSetServiceConfiguration function creates and sets a configuration record for the HTTP Server API configuration store.
        /// The call fails if the specified record already exists. To change a given configuration record, delete it and then recreate it
        /// with a different value.
        /// </summary>
        /// <remarks>https://msdn.microsoft.com/en-us/library/aa364503(v=vs.85).aspx</remarks>
        /// <param name="ServiceHandle">Reserved. Must be zero.</param>
        /// <param name="ConfigId">Type of configuration record to be set. This parameter can be one of the following values from the
        /// HTTP_SERVICE_CONFIG_ID enumeration.</param>
        /// <param name="pConfigInformation">A pointer to a buffer that contains the appropriate data to specify the type of record to
        /// be set.</param>
        /// <param name="ConfigInformationLength">Size, in bytes, of the pConfigInformation buffer.</param>
        /// <param name="pOverlapped">This parameter is reserved and must be NULL</param>
        /// <returns>If the function succeeds, the function returns NO_ERROR.</returns>
        [DllImport("httpapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint HttpSetServiceConfiguration(
            IntPtr ServiceHandle,
            HTTP_SERVICE_CONFIG_ID ConfigId,
            IntPtr pConfigInformation,
            int ConfigInformationLength,
            IntPtr pOverlapped);

        /// <summary>
        /// The HttpDeleteServiceConfiguration function deletes specified data, such as IP addresses or SSL Certificates, from the HTTP Server
        /// API configuration store, one record at a time.
        /// </summary>
        /// <remarks>https://msdn.microsoft.com/en-us/library/aa364503(v=vs.85).aspx</remarks>
        /// <param name="ServiceHandle">Reserved. Must be zero.</param>
        /// <param name="ConfigId">Type of configuration record to be set. This parameter can be one of the following values from the
        /// HTTP_SERVICE_CONFIG_ID enumeration.</param>
        /// <param name="pConfigInformation">A pointer to a buffer that contains the appropriate data to specify the type of record
        /// to be set.</param>
        /// <param name="ConfigInformationLength">Size, in bytes, of the pConfigInformation buffer.</param>
        /// <param name="pOverlapped">This parameter is reserved and must be NULL</param>
        /// <returns>If the function succeeds, the function returns NO_ERROR.</returns>
        [DllImport("httpapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint HttpDeleteServiceConfiguration(
            IntPtr ServiceHandle,
            HTTP_SERVICE_CONFIG_ID ConfigId,
            IntPtr pConfigInformation,
            int ConfigInformationLength,
            IntPtr pOverlapped);

        #endregion
    }
}
