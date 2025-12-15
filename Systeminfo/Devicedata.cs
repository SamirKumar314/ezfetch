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
            ManagementObjectSearcher mos7 = new ManagementObjectSearcher(
                "SELECT Manufacturer, Model, SystemFamily, UserName FROM Win32_ComputerSystem"
                );

            foreach (ManagementObject obj in mos7.Get())
            {
                string mfr = (obj["Manufacturer"]?.ToString() ?? "Unknown").Trim();
                string model = (obj["Model"]?.ToString() ?? "--").Trim();
                string sysfm = (obj["SystemFamily"]?.ToString() ?? "Unknown").Trim();
                string usrnm = (obj["UserName"]?.ToString() ?? "Unknown").Trim();
                str7.AppendLine($"Host: {mfr} {sysfm} ({model})");
                //str7.AppendLine($"Model: {model}");
                //str7.AppendLine($"Username: {usrnm}");
                break;
            }

            //uptime from environmant class...
            int timems = Environment.TickCount;
            TimeSpan ts = TimeSpan.FromMilliseconds(timems);
            int days = ts.Days;
            int hrs = ts.Hours;
            int mins = ts.Minutes;
            if (days > 0)
            {
                str7.AppendLine($"Uptime: {days}d, {hrs}h, {mins}m");
            }
            else if (hrs > 0)
            {
                str7.AppendLine($"Uptime: {hrs}h, {mins}m");
            }
            else
            {
                str7.AppendLine($"Uptime: {mins}m");
            }

            return str7.ToString();
        }
    }
}
