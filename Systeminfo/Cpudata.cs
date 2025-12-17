using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Cpudata
    {
        public static string Getcpudata()
        {
            StringBuilder str1 = new StringBuilder(string.Empty);
            try
            {
                using(ManagementObjectSearcher mos1 = new ManagementObjectSearcher(
                        "SELECT Name, NumberOfCores, MaxClockSpeed FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in mos1.Get())
                    {
                        string cpuname = (obj["Name"]?.ToString() ?? "Unknown").Trim();
                        string cores = (obj["NumberOfCores"]?.ToString() ?? "Unknown");
                        string maxcs = (obj["MaxClockSpeed"]?.ToString() ?? "Unknown");
                        str1.AppendLine($"CPU: {cpuname} ({cores}C)");
                        str1.AppendLine($"CPU clock speed: {maxcs}MHz");
                        break;
                    }
                }
            }
            catch(ManagementException)
            {
                str1.AppendLine($"CPU: Unknown");
                str1.AppendLine($"CPU clock speed: Unknown");
            }
            return str1.ToString();
        }
    }
}
