using ezfetch.Systeminfo;
using ezfetch.Uitldir;

namespace ezfetch
{
    internal class Program
    {
        static List<(string label, string value)> infolist = new List<(string, string)>();
        static void PrintStyle(string rawtxt, string type)
        {
            var lines = rawtxt.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.Contains(":"))
                {
                    string labels, values;
                    var parts = line.Split(new[] { ':' }, 2);

                    labels = parts[0] + (type == "header" ? "" : ":");
                    values = parts.Length > 1 ? parts[1].Trim() : "";
                    infolist.Add((labels, values));   //storing label and value in a list
                }

            }
        }
        static void Main(string[] args)
        {
            string strCPU = Cpudata.Getcpudata();
            string strGPU = Gpudata.Getgpudata();
            string strOS = Osdata.Getosdata();
            string strRAM = Ramdata.Getramdata();
            string strDISK = Diskdata.Getdiskdata();
            string strNW = Networkdata.Getnwdata();
            string strDD = Devicedata.Getdevicedata();
            string strHH = HostHeaderdata.Gethostheaderdata();
            string strMB = Mainboarddata.Getmainboarddata();

            PrintStyle(strHH, "header");
            PrintStyle(strOS, "body");
            PrintStyle(strDD, "body");
            PrintStyle(strMB, "body");
            PrintStyle(strCPU, "body");
            PrintStyle(strGPU, "body");
            PrintStyle(strRAM, "body");
            PrintStyle(strDISK, "body");
            PrintStyle(strNW, "body");

            Displaymanager.Displaylayout(AsciiiArt.Wlogo, infolist);
        }
    }
}
