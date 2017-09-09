using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlThread
{
    class Monitor
    {
        int counter = 1;
        int sleepSecond;
        public Queue<DateTime> timeChange = new Queue<DateTime>();
        public Queue<int> itemChange = new Queue<int>();
        NewFile file;
        FileSystemWatcher watcher;
        public Monitor(NewFile file, int sleepSecond)
        {
            this.sleepSecond = sleepSecond;
            this.file = file;
            watcher = new FileSystemWatcher();
        }
        public void Run()
        {
            watcher.Path = Directory.GetCurrentDirectory();
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = file.PathOfFile;
            watcher.Changed += new FileSystemEventHandler(onChanged);
            watcher.Created += new FileSystemEventHandler(onDelet);
            watcher.Deleted += new FileSystemEventHandler(onDelet);
            watcher.Renamed += new RenamedEventHandler(onRenamed);
            watcher.EnableRaisingEvents = true;
        }
        void onDelet(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " \t\t" + e.ChangeType + "\tTime: " + file.TimeCreate());
        }
        void onChanged(object source, FileSystemEventArgs e)
        {
            if (counter % 2 != 0)
            {
                Thread.Sleep(sleepSecond * 1000);
                Console.WriteLine("File content changed to {0} {1} seconds ago:Time changes: {2}", itemChange.Dequeue(), sleepSecond,timeChange.Dequeue());
            }
            counter++;
        }
        void onRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: " + e.OldFullPath + "renamed to " + e.FullPath + "\tTime: " + file.TimeCreate());
        }
    }
}
