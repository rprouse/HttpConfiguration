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

using System;
using System.Runtime.InteropServices;

namespace Alteridem.Http.Configuration.Native
{
    internal class NativeMethods
    {
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
        public static unsafe extern uint HttpQueryServiceConfiguration(
            IntPtr ServiceHandle,
            HTTP_SERVICE_CONFIG_ID ConfigId,
            [Optional] IntPtr pInputConfigInfo,
            [Optional] int InputConfigInfoLength,
            [In, Out, Optional] byte* pOutputConfigInfo,
            [Optional] int OutputConfigInfoLength,
            [Out, Optional] out int pReturnLength,
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
