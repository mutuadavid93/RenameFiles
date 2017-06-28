using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetDir = @"G:\LYNDATUTS\Typescript Essential Training";
            string cloneDir = targetDir + @"G:\LYNDATUTS\Typescript Essentials";
            listFilesInDir(targetDir, cloneDir);

            // Keep the Console Window open
            Console.WriteLine("Press Enter to Close");
            Console.Read();
        }

        public static void listFilesInDir(string WorkDir, string newDir)
        {
            var files = new DirectoryInfo(WorkDir).GetFiles("*.mp4", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                var x = file.Name;
                string realName = x.Split('-')[0];

                var fullPath = WorkDir + @"\" +x;
                string suffix = new String(x.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
                // suffix is fine
                File.Move(fullPath, newDir + @"\" + suffix+"-"+ realName + ".mp4");
            }

            Console.WriteLine("Mission ^_^ Complete");
        }
    }
}
