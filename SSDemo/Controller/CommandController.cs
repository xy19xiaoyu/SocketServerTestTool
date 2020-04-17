using SSDemo.Model;
using SSDemo.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SSDemo.Controller
{
    public class CommandController
    {
        private static string Dir { get; set; }
        public static List<Command> Commands { get; set; }
        public static List<Command> His { get; set; }

        public static Regex reg = new Regex("^\\[(?<no>\\d*\\.?\\d*?)\\].*");
        private static void SetCmdNo(Command cmd)
        {
            Match mh = reg.Match(cmd.Name);
            if (mh.Success)
            {
                var tmp = mh.Groups["no"].Value;
                double no = 0d;
                if (double.TryParse(tmp, out no))
                {
                    cmd.No = no;
                }
            }
        }
        public static void LoadCommands(string dir)
        {
            Dir = dir;
            string[] json_files = Directory.GetFiles(dir, "*.json");
            string[] txt_files = Directory.GetFiles(dir, "*.txt");
            Commands = new List<Command>();
            foreach (var json in json_files)
            {
                var cmd = new Command()
                {
                    type = "json",
                    Name = Path.GetFileNameWithoutExtension(json),
                    Content = File.ReadAllText(json, Encoding.GetEncoding("gb2312")).FormatJSON()
                };
                SetCmdNo(cmd);
                Commands.Add(cmd);
            }

            foreach (var txt in txt_files)
            {
                var cmd = new Command()
                {
                    type = "txt",
                    Name = Path.GetFileNameWithoutExtension(txt),
                    Content = File.ReadAllText(txt, Encoding.GetEncoding("gb2312"))
                };
                Commands.Add(cmd);
            }
            Commands = Commands.OrderBy(x => x.No).ToList();
            Commands.Insert(0, new Command() { Name = "空", Content = "", type = "json" });
            
            //his

            var his = Path.Combine(dir, "His");
            his.CheckDir();
            json_files = Directory.GetFiles(his, "*.json");
            txt_files = Directory.GetFiles(his, "*.txt");

            His = new List<Command>();
            foreach (var json in json_files)
            {
                var cmd = new Command()
                {
                    type = "json",
                    Name = Path.GetFileNameWithoutExtension(json),
                    Content = File.ReadAllText(json, Encoding.UTF8).FormatJSON()
                };
                His.Add(cmd);
            }

            foreach (var txt in txt_files)
            {
                var cmd = new Command()
                {
                    type = "txt",
                    Name = Path.GetFileNameWithoutExtension(txt),
                    Content = File.ReadAllText(txt, Encoding.UTF8)
                };
                His.Add(cmd);
            }
        }



        public static void AddHis(string content)
        {
            Command cmd = new Command() { Name = DateTime.Now.ToString("yyMMddHHmmss"), Content = content, type = "txt" };
            His.Add(cmd);

        }

        public static void AddHis(Command cmd)
        {
            His.Add(cmd);
            WriteHis(cmd);
        }
        private static void WriteHis(Command cmd)
        {
            var file = Path.Combine(Dir, "His", $"{cmd.Name}.{cmd.type}");
            File.WriteAllText(file, cmd.Content, Encoding.UTF8);
        }
    }
}
