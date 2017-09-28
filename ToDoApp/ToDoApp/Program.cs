using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] content;
            string path;
            List<string[]> contentDetailed = new List<string[]>();
            string checkSign;

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
                    path = @"./todolist.txt";
                    Console.WriteLine("\n");
                    content = File.ReadAllLines(path);

                    if (content.Length != 0)
                    {
                        for (int i = 0; i < content.Count(); i++)
                        {
                            contentDetailed.Add(content[i].Split(';'));
                            if(contentDetailed[i][1] == "true")
                            {
                                checkSign = "[X] ";
                            }
                            else
                            {
                                checkSign = "[ ] ";
                            }

                            Console.WriteLine("  " + (i + 1) + " - " + checkSign + contentDetailed[i][0]);
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
                path = @"./todolist.txt";
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(args[1] + ";false;" + args[1]);
                }
            }

            if (args.Contains("-c"))
            {
                path = @"./todolist.txt";
                content = File.ReadAllLines(path);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    for (int i = 0; i < content.Count(); i++)
                    {
                        contentDetailed.Add(content[i].Split(';'));
                    }

                    int inputTask = int.Parse(args[1]);
                    contentDetailed[inputTask - 1][1] = "true";

                    for (int i = 0; i < contentDetailed.Count(); i++)
                    {
                        writer.WriteLine(contentDetailed[i][0] + ";" + contentDetailed[i][1] + ";" + contentDetailed[i][2]);
                    }
                }
            }

            if (args.Contains("-r"))
            {
                path = @"./todolist.txt";
                content = File.ReadAllLines(path);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    for (int i = 0; i < content.Count(); i++)
                    {
                        contentDetailed.Add(content[i].Split(';'));
                    }

                    contentDetailed.RemoveAt(int.Parse(args[1]) - 1);

                    for (int i = 0; i < contentDetailed.Count(); i++)
                    {
                        writer.WriteLine(contentDetailed[i][0] + ";" + contentDetailed[i][1] + ";" + contentDetailed[i][2]);
                    }
                }
            }
        }
    }
}
