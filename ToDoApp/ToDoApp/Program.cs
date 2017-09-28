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
                try
                {
                    string path = @"./todolist.txt";
                    Console.WriteLine("\n");
                    string[] content = File.ReadAllLines(path);

                    if (content.Length != 0)
                    {
                        List<string[]> contentDetailed = new List<string[]>();

                        for (int i = 0; i < content.Count(); i++)
                        {
                            contentDetailed.Add(content[i].Split(';'));
                            Console.WriteLine("  " + (i + 1) + " - " + contentDetailed[i][0]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("  No todos for today! :) ");
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Could not read the file!");
                }
            }

            if (args.Contains("-a"))
            {
                string path = @"./todolist.txt";
                Console.WriteLine("\n");
                using (StreamWriter writer = File.AppendText(path))
                {
                    string inputTask = args[1];
                    writer.WriteLine(inputTask + ";false;" + inputTask);
                }
            }
        }
    }
}
