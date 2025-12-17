using System;
using System.Collections.Generic;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Diskdata
    {
        public static string Getdiskdata()
        {
            StringBuilder str5 = new StringBuilder(string.Empty);
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (!drive.IsReady)
                    {
                        continue;
                    }
                    long total = drive.TotalSize / (1024 * 1024 * 1024);
                    long free = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
                    long used = total - free;
                    str5.AppendLine($"Disk ({drive.Name.Replace(":\\", "")}): {used} GB / {total} GB used (Free: {free} GB)");
                }
            }
            catch
            {
                str5.AppendLine("Disk: Unknown");
            }

            return str5.ToString();
        }
    }
}
