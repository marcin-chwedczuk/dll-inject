using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victim
{
    public class Program {
        static void Main(string[] args) {
            int pid = Process.GetCurrentProcess().Id;
            Console.WriteLine("PID: {0}", pid);

            string userInput;
            while ((userInput = Console.ReadLine()) != "quit")
                ;
        }
    }
}
