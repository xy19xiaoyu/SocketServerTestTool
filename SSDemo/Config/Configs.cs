using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSDemo.Config
{
    public static class Configs
    {
        public static string IP { get; set; }
        public static int Port { get; set; }

        public static string Type { get; set; }

        public static Encoding Encoding { get; set; } = Encoding.GetEncoding("gb2312");
    }


}
