﻿using System.Runtime.InteropServices;

namespace Alteridem.Http.Service.Native
{
    [StructLayout(LayoutKind.Sequential)]
    struct HTTP_SERVICE_CONFIG_URLACL_QUERY
    {
        public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;
        public HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;
        public uint dwToken;
    }
}