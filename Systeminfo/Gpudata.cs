using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Gpudata
    {
        public static string Getgpudata()
        {
            StringBuilder str2 = new StringBuilder(string.Empty);
            try
            {
                using(ManagementObjectSearcher mos2 = new ManagementObjectSearcher(
                    "SELECT VideoProcessor, AdapterRAM, DriverVersion, CurrentHorizontalResolution, CurrentVerticalResolution, MaxRefreshRate FROM Win32_VideoController"
                    ))
                {
                    foreach (ManagementObject obj in mos2.Get())
                    {
                        string gpuname = (obj["VideoProcessor"]?.ToString() ?? "Unknown").Trim();
                        //string driver = obj["DriverVersion"]?.ToString().Trim() ?? "Unknown";
                        double gram = Convert.ToDouble(obj["AdapterRAM"] ?? 0);  //memory in bytes
                        int scrwidth = Convert.ToInt32(obj["CurrentHorizontalResolution"] ?? 0);
                        int scrheight = Convert.ToInt32(obj["CurrentVerticalResolution"] ?? 0);
                        int screfresh = Convert.ToInt32(obj["MaxRefreshRate"] ?? 0);
                        gram = gram / 1024.0 / 1024.0;    //converts to mb
                        str2.AppendLine($"GPU: {gpuname}");
                        str2.AppendLine($"GPU memory: {gram:F1} MB");
                        str2.AppendLine($"Display: {scrwidth}x{scrheight} @{screfresh}Hz");
                        //str2.AppendLine($"GPU Driver Version: {driver}");
                        break;
                    }
                }
            }
            catch(ManagementException)
            {
                str2.AppendLine("GPU: Unknown");
                str2.AppendLine("GPU memory: Unknown");
                str2.AppendLine("Display: Unknown");
            }
            return str2.ToString();
        }
    }
}
