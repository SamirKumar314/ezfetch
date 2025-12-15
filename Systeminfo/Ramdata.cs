using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Ramdata
    {
        public static string Getramdata()
        {
            StringBuilder str4 = new StringBuilder(string.Empty);
            ManagementObjectSearcher mos4 = new ManagementObjectSearcher(
                "SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem"
                );

            foreach (ManagementObject obj in mos4.Get())
            {
                double ramFree = Convert.ToDouble(obj["FreePhysicalMemory"] ?? 0);
                double ramTotl = Convert.ToDouble(obj["TotalVisibleMemorySize"] ?? 0);
                ramFree = ramFree / 1024.0 / 1024.0;
                ramTotl = ramTotl / 1024.0 / 1024.0;
                double ramUsed = ramTotl - ramFree;
                double freeMb = ramFree * 1024.0;
                if (freeMb < 950.0)
                {
                    return str4.AppendLine($"Memory Usage: {ramUsed:F1} GB / {ramTotl:F1} GB (Free: {freeMb:F1} MB)").ToString();
                }
                str4.AppendLine($"Memory Usage: {ramUsed:F1} GB / {ramTotl:F1} GB (Free: {ramFree:F2} GB)");
                break;
            }

            return str4.ToString();
        }
    }
}
