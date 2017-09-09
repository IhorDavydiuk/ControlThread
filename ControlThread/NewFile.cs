using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlThread
{
    class NewFile
    {
        public int Item;
        public string FileName { get; private set; }
        public string PathOfFile { get; set; }
        public NewFile(string nameFile, int item)
        {
            this.Item = item;
            FileName = nameFile;
            PathOfFile = String.Concat(nameFile, ".txt");
            File.WriteAllText(PathOfFile, item.ToString());
        }
        public void WriteFile(int item)
        {
            File.WriteAllText(PathOfFile, item.ToString());
            Item = item;
        }
        public void ReadFile()
        {
            Console.WriteLine(File.ReadAllText(PathOfFile));
        }
        public DateTime TimeChanged()
        {
            return File.GetLastWriteTime(PathOfFile);
        }
        public DateTime TimeCreate()
        {
            return Directory.GetLastWriteTime(Directory.GetCurrentDirectory());
        }
    }
}
