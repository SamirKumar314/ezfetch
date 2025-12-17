using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Devicedata
    {
        public static string Getdevicedata()
        {
            StringBuilder str7 = new StringBuilder(string.Empty);
            try
            {
                using(ManagementObjectSearcher mos7 = new ManagementObjectSearcher(
                    "SELECT Manufacturer, Model, SystemFamily FROM Win32_ComputerSystem"))
                {
                    foreach (ManagementObject obj in mos7.Get())
                    {
                        string mfr = (obj["Manufacturer"]?.ToString() ?? "Unknown").Trim();
                        string model = (obj["Model"]?.ToString() ?? "--").Trim();
                        string sysfm = (obj["SystemFamily"]?.ToString() ?? "Unknown").Trim();
                        str7.AppendLine($"Host: {mfr} {sysfm} ({model})");
                        break;
                    }
                }
            }
            catch(ManagementException)
            {
                str7.AppendLine("Host: Unknown");
            }

            finally
            {
                //uptime from environmant class...
                long timems = Environment.TickCount64;
                TimeSpan ts = TimeSpan.FromMilliseconds(timems);
                
                if (ts.Days > 0)
                {
                    str7.AppendLine($"Uptime: {ts.Days}d, {ts.Hours}h, {ts.Minutes}m");
                }
                else if (ts.Hours > 0)
                {
                    str7.AppendLine($"Uptime: {ts.Hours}h, {ts.Minutes}m");
                }
                else
                {
                    str7.AppendLine($"Uptime: {ts.Minutes}m");
                }
            }


            return str7.ToString();
        }
    }
}
