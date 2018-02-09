using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watcher1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                int count = 0;
                var watcher = new FileSystemWatcher("\\\\engcdtrans\\fromjenkins\\sybil\\rp");
                watcher.Filter = "*";
//                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Created += (s, e) =>
                {
                    Console.WriteLine("Creation");
                };
                watcher.Changed += (s, e) =>
                {
                    Console.WriteLine($"{count++} Changed");
                };
                watcher.EnableRaisingEvents = true;
                System.Threading.Thread.Sleep(100000000);
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
