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

using System.Runtime.InteropServices;

namespace Alteridem.Http.Service.Native
{

    /// <summary>
    /// The HTTP_SERVICE_CONFIG_URLACL_SET structure is used to add a new record to the URL reservation store or
    /// retrieve an existing record from it. An instance of the structure is used to pass data in through the pConfigInformation
    /// parameter of the HTTPSetServiceConfiguration function, or to retrieve data through the pOutputConfigInformation parameter
    /// of the HTTPQueryServiceConfiguration function when the ConfigId parameter of either function is equal to HTTPServiceConfigUrlAclInfo.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct HTTP_SERVICE_CONFIG_URLACL_SET
    {
        /// <summary>
        /// An HTTP_SERVICE_CONFIG_URLACL_KEY structure that identifies the URL reservation record.
        /// </summary>
        public HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;
        /// <summary>
        /// An HTTP_SERVICE_CONFIG_URLACL_PARAM structure that holds the contents of the specified URL reservation record.
        /// </summary>
        public HTTP_SERVICE_CONFIG_URLACL_PARAM ParamDesc;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct HTTP_SERVICE_CONFIG_URLACL_KEY
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pUrlPrefix;

        public HTTP_SERVICE_CONFIG_URLACL_KEY(string urlPrefix)
        {
            pUrlPrefix = urlPrefix;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct HTTP_SERVICE_CONFIG_URLACL_PARAM
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pStringSecurityDescriptor;

        public HTTP_SERVICE_CONFIG_URLACL_PARAM(string securityDescriptor)
        {
            pStringSecurityDescriptor = securityDescriptor;
        }
    }
}
