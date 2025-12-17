using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class Networkdata
    {
        public static string Getnwdata()
        {
            StringBuilder str6 = new StringBuilder(string.Empty);
            ManagementObjectSearcher mos6 = new ManagementObjectSearcher(
                "SELECT Name, MacAddress, NetConnectionID FROM Win32_NetworkAdapter WHERE NetConnectionID LIKE '%Wi-Fi%' OR Name LIKE '%Wireless%'"
                );

            foreach (ManagementObject obj in mos6.Get())
            {
                string name1 = (obj["Name"]?.ToString() ?? "Unknown").Trim();
                string macadd = (obj["MacAddress"]?.ToString() ?? "Unknown").Trim();
                string netid = (obj["NetConnectionID"]?.ToString() ?? "Unknown").Trim();

                //ulong speed = (ulong)(obj["Speed"] ?? 0UL);
                //double mbps = speed / 1_000_000.0;

                str6.AppendLine($"Wifi Adapter: {name1} ({netid})");
                //str6.AppendLine($"Wifi ID: {netid}");
                str6.AppendLine($"MAC-Address: {macadd}");
                //str6.AppendLine($"Link Speed: {mbps:F0} mbps");
                break;
            }

            //get IP address...
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endpoint = socket.LocalEndPoint as IPEndPoint;
                    string ip = endpoint?.Address.ToString() ?? "Unknown";
                    str6.AppendLine($"IP-Address: {ip}");
                }
            }
            catch
            {
                str6.AppendLine($"IP-Address: Not Connected");
            }
            return str6.ToString();
        }
    }
}
