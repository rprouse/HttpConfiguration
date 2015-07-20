namespace Alteridem.Http.Service.Native
{
    enum HTTP_SERVICE_CONFIG_ID
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
}
