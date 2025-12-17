using System;
using System.Collections.Generic;
using System.Text;

namespace ezfetch.Systeminfo
{
    internal class HostHeaderdata
    {
        public static string Gethostheaderdata()
        {
            StringBuilder str8 = new StringBuilder(string.Empty);

            string host = Environment.MachineName ?? "Desktop";
            string user = Environment.UserName ?? "User";
            string hheader = $"{host}@{user}";
            str8.AppendLine(hheader + ":");
            str8.AppendLine(new string('-', hheader.Length) + ":");

            return str8.ToString();
        }
    }
}
