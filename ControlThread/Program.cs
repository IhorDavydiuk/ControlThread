using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlThread
{
    class Program
    {
        static void Main(string[] args)
        {
            NewFile file = new NewFile("3", 1);
            Monitor monitor = new Monitor(file,10);
            Thread threadFile = new Thread(monitor.Run);
            threadFile.Start();
            do
            {
                Console.WriteLine("Do you want to change the file?(y/n): ");
                char answer = char.Parse(Console.ReadLine());
                if (answer == 'y' || answer == 'Y')
                {
                    if (file.Item == 0)
                    {
                        file.WriteFile(1);
                        monitor.timeChange.Enqueue(file.TimeChanged());
                        monitor. itemChange.Enqueue(1);
                    }
                    else if (file.Item == 1)
                    {
                        file.WriteFile(0);
                        monitor.timeChange.Enqueue(file.TimeChanged());
                        monitor. itemChange.Enqueue(0);
                    }
                }
                else if (answer == 'n' || answer == 'N')
                {
                    return;
                }
            } while (true);
        }
    }
}
