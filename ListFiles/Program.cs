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
            string srcPath = @"\\STREETMONEY\Nodejs\Building a Website in Node.js and Express.js";
            string destPath = /*srcPath.Split('\\')[0] +*/ @"G:\HONEYPOT\" + srcPath.Split('\\').Last();
            Directory.CreateDirectory(destPath); // Construct Path

            listFilesInDir(srcPath, destPath); //invoke

            // Keep the Console Window open
            Console.WriteLine("Press Enter to Close");
            Console.Read();
        }

        public static void listFilesInDir(string WorkDir, string newDir)
        {
            var files = new DirectoryInfo(WorkDir).GetFiles("*.mp4", SearchOption.TopDirectoryOnly);

            try
            {
                foreach (FileInfo file in files)
                {
                    var x = file.Name;
                    string realName = x.Split('-')[0];

                    var fullPath = WorkDir + @"\" + x;
                    string suffix = new String(x.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
                    // suffix is fine
                    File.Copy(fullPath, newDir + @"\" + suffix + "-" + realName + ".mp4");
                }

                Console.WriteLine("Mission ^_^ Complete");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
