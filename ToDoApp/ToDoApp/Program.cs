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
            var toDos = new List<ToDo>(); 
            string checkSign;

            if (args.Length == 0)
            {
                PrintUsage();
            }

            if (args.Contains("-l"))
            {
                try
                {
                    Console.WriteLine("\n");
                    content = ReadFile();
                    for (int i = 0; i < content.Count(); i++)
                    {
                        ToDo todo = new ToDo(content[i]);
                        toDos.Add(todo);
                    }
                    WriteToConsole(toDos);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Could not read the file!");
                }
            }

            //if (args.Contains("-a"))
            //{
            //    path = @"./todolist.txt";
            //    using (StreamWriter writer = File.AppendText(path))
            //    {
            //        writer.WriteLine(args[1] + ";false;" + args[1]);
            //    }
            //}

            //if (args.Contains("-c"))
            //{
            //    path = @"./todolist.txt";
            //    content = File.ReadAllLines(path);
            //    using (StreamWriter writer = new StreamWriter(path))
            //    {
            //        for (int i = 0; i < content.Count(); i++)
            //        {
            //            contentDetailed.Add(content[i].Split(';'));
            //        }

            //        int inputTask = int.Parse(args[1]);
            //        contentDetailed[inputTask - 1][1] = "true";

            //        for (int i = 0; i < contentDetailed.Count(); i++)
            //        {
            //            writer.WriteLine(contentDetailed[i][0] + ";" + contentDetailed[i][1] + ";" + contentDetailed[i][2]);
            //        }
            //    }
            //}

            //if (args.Contains("-r"))
            //{
            //    path = @"./todolist.txt";
            //    content = File.ReadAllLines(path);
            //    using (StreamWriter writer = new StreamWriter(path))
            //    {
            //        for (int i = 0; i < content.Count(); i++)
            //        {
            //            contentDetailed.Add(content[i].Split(';'));
            //        }

            //        contentDetailed.RemoveAt(int.Parse(args[1]) - 1);

            //        for (int i = 0; i < contentDetailed.Count(); i++)
            //        {
            //            writer.WriteLine(contentDetailed[i][0] + ";" + contentDetailed[i][1] + ";" + contentDetailed[i][2]);
            //        }
            //    }
            //}
        }

        public static void PrintUsage()
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

        public static string[] ReadFile(string path = "./todolist.txt")
        {
            return File.ReadAllLines(path);
        }

        public static void WriteToConsole(List<ToDo> inputList)
        {
            if (inputList.Count == 0)
            {
                Console.WriteLine("  No todos for today! :) ");
            }
            else
            {
                for (int i = 0; i < inputList.Count(); i++)
                {
                    Console.WriteLine((i + 1) + ". - " + inputList[i].ToString());
                }
            }
        }
    }
}
