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
        HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;
        /// <summary>
        /// An HTTP_SERVICE_CONFIG_URLACL_PARAM structure that holds the contents of the specified URL reservation record.
        /// </summary>
        HTTP_SERVICE_CONFIG_URLACL_PARAM ParamDesc;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct HTTP_SERVICE_CONFIG_URLACL_KEY
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        string pUrlPrefix;

        HTTP_SERVICE_CONFIG_URLACL_KEY(string urlPrefix)
        {
            pUrlPrefix = urlPrefix;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct HTTP_SERVICE_CONFIG_URLACL_PARAM
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        string pStringSecurityDescriptor;

        HTTP_SERVICE_CONFIG_URLACL_PARAM(string securityDescriptor)
        {
            pStringSecurityDescriptor = securityDescriptor;
        }
    }
}
