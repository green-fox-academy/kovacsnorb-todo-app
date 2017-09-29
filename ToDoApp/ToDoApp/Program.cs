using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoApp
{
    class Program : Functions
    {
        static void Main(string[] args)
        {
            string[] content;
            var toDos = new List<ToDo>(); 

            if (!(args.Contains("-l") || args.Contains("-a") || args.Contains("-c") || args.Contains("-r") || args.Length == 0))
            {
                UnsupportedArg();
            }
            if (args.Length == 0)
            {
                PrintUsage();
            }
            if (args.Contains("-l"))
            {
                try
                {
                    content = ReadFile();
                    toDos = FillToDoList(content);
                    WriteToConsole(toDos);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("\nCould not read the file!");
                }
            }
            if (args.Contains("-a"))
            {
                try
                {
                    if (args.Count() == 1)
                    {
                        Console.WriteLine("\nUnable to add: no task provided");
                    }
                    else if (args.Count() == 2)
                    {
                        AddNewTask(args[1]);
                        WriteToConsole(FillToDoList(ReadFile()));
                    }
                    else if (1 != int.Parse(args[2]) && 2 != int.Parse(args[2]) && 3 != int.Parse(args[2]))
                    {
                        Console.WriteLine("\nPlease, give a priority 1, 2 or 3, or leave it empty to set the priority to the default (MEDIUM).");
                    }
                    else
                    {
                        AddNewTask(args[1], int.Parse(args[2]));
                        WriteToConsole(FillToDoList(ReadFile()));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease, give a priority 1, 2 or 3, or leave it empty to set the priority to the default (MEDIUM).");
                }
            }
            if (args.Contains("-c"))
            {
                if (args.Count() == 1)
                {
                    Console.WriteLine("\nUnable to check: no index provided");
                }
                else
                {
                    CheckTask(args[1]);
                    WriteToConsole(FillToDoList(ReadFile()));
                }
            }
            if (args.Contains("-r"))
            {
                if (args.Count() == 1)
                {
                    Console.WriteLine("\nUnable to remove: no index provided");
                }
                else
                {
                    RemoveTask(args[1]);
                    WriteToConsole(FillToDoList(ReadFile()));
                }
            }
        }       
    }
}
