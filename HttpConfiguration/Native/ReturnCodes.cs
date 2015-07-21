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
    /// <summary>
    /// Return codes from Native API's
    /// </summary>
    internal class ReturnCodes
    {
        #region Return Codes

        public const uint NO_ERROR = 0;
        public const uint ERROR_INVALID_HANDLE = 6;
        public const uint ERROR_INVALID_PARAMETER = 87;
        public const uint ERROR_INSUFFICIENT_BUFFER = 122;
        public const uint ERROR_ALREADY_EXISTS = 183;
        public const uint ERROR_MORE_DATA = 234;
        public const uint ERROR_NO_MORE_ITEMS = 259;
        public const uint ERROR_NO_SUCH_LOGON_SESSION = 1312;

        #endregion
    }
}
