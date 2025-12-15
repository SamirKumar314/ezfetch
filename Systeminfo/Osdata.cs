using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Osdata
    {
        public static string Getosdata()
        {
            StringBuilder str3 = new StringBuilder(string.Empty);
            ManagementObjectSearcher mos3 = new ManagementObjectSearcher(
                "SELECT Caption, OSArchitecture FROM Win32_OperatingSystem"
                );

            foreach (ManagementObject obj in mos3.Get())
            {
                string os = (obj["Caption"]?.ToString() ?? "Unknown").Trim();
                string arc = (obj["OSArchitecture"]?.ToString() ?? "Unknown").Trim();
                str3.AppendLine($"OS: {os} [{arc}]");
            }

            return str3.ToString();
        }
    }
}
