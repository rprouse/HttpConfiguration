namespace Alteridem.Http.Service
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
