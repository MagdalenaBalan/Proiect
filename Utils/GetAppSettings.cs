using System;
using System.Configuration;

namespace ISA_TWAAOS.Utils
{
    public static class GetAppSettings
    {
        public static string GetAttachmentDirectoryPath()
        {
            return Convert.ToString(ConfigurationManager.AppSettings["AttachmentDirectory"]);
        }
    }
}