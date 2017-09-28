using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("\n  Command Line Todo application" +
                "\n  =============================" +
                "\n" +
                "\n  Command line arguments:" +
                "\n  -l   Lists all the tasks" +
                "\n  -a   Adds a new task" +
                "\n  -r   Removes a task" +
                "\n  -c   Completes a task");
            }

            if (args.Contains("-l"))
            {
                string path = @"./todolist.txt";
                try
                {
                    Console.WriteLine("\n");
                    string[] content = File.ReadAllLines(path);
                    List<string[]> contentDetailed = new List<string[]>();

                    for (int i = 0; i < content.Count(); i++)
                    {
                        contentDetailed.Add(content[i].Split(';'));
                        Console.WriteLine("  " + (i + 1) + " - " + contentDetailed[i][0]);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Could not read the file!");
                }
            }
        }
    }
}
