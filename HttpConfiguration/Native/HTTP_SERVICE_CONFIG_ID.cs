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
