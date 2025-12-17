using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Mainboarddata
    {
        public static string Getmainboarddata()
        {
            StringBuilder str = new StringBuilder(string.Empty);
            try
            {
                using ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT Product, Manufacturer FROM Win32_Baseboard");
                foreach (ManagementObject obj in mos.Get())
                {
                    string baseboard = obj["Product"]?.ToString() ?? "Unknown";
                    string boardmfr = obj["Manufacturer"]?.ToString() ?? "Unknown";
                    str.AppendLine($"Mainboard: {baseboard}");
                }
            }
            catch(ManagementException)
            {
                str.AppendLine("Mainboard: Unknown");
            }
            return str.ToString();
        }
    }
}
