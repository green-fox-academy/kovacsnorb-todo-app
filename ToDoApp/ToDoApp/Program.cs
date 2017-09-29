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
                    Console.WriteLine("Could not read the file!");
                }
            }
            if (args.Contains("-a"))
            {
                try
                {
                    if (args.Count() == 2)
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
                CheckTask(args[1]);
                WriteToConsole(FillToDoList(ReadFile()));
            }
            if (args.Contains("-r"))
            {
                RemoveTask(args[1]);
                WriteToConsole(FillToDoList(ReadFile()));
            }
        }

        public static void PrintUsage()
        {
            Console.WriteLine("\nCommand Line Todo application" +
            "\n=============================" +
            "\n" +
            "\nCommand line arguments:" +
            "\n-l   Lists all the tasks" +
            "\n-a   Adds a new task" +
            "\n-r   Removes a task" +
            "\n-c   Completes a task");
        }

        public static string[] ReadFile(string path = "./todolist.txt")
        {
            return File.ReadAllLines(path);
        }

        public static List<ToDo> FillToDoList(string[] inputArray)
        {
            var toDos = new List<ToDo>();
            for (int i = 0; i < inputArray.Count(); i++)
            {
                string[] taskToArray = inputArray[i].Split(';');
                ToDo todo = new ToDo(taskToArray[0], Convert.ToBoolean(taskToArray[1]), int.Parse(taskToArray[2]));
                toDos.Add(todo);
            }
            return toDos;
        }

        public static void WriteToConsole(List<ToDo> toDoList)
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("No todos for today! :) ");
            }
            else
            {
                Console.WriteLine("\nNo Done? Priority   Task");
                for (int i = 0; i < toDoList.Count(); i++)
                {
                    if( i < 9)
                    {
                        Console.WriteLine(" " + (i + 1) + toDoList[i].ToString());
                    }
                    else
                    {
                        Console.WriteLine((i + 1) + toDoList[i].ToString());
                    }
                }

                HighCounter(toDoList);
            }
        }

        public static void AddNewTask(string newTask, int priority, string path = "./todolist.txt")
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(newTask + ";false;" + priority);
            }
        }

        public static void AddNewTask(string newTask, string path = "./todolist.txt")
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(newTask + ";false;" + 2);
            }
        }

        public static void CheckTask(string finishedTask, string path = "./todolist.txt")
        {
            var list = FillToDoList(ReadFile());
            using (StreamWriter writer = new StreamWriter(path))
            {
                list[int.Parse(finishedTask) - 1].SetStatus(true);

                for (int i = 0; i < list.Count(); i++)
                {
                    writer.WriteLine(list[i].Name + ";" + list[i].IsDone + ";" + list[i].Priority);
                }
            }
        }

        public static void RemoveTask(string taskToRemove, string path = "./todolist.txt")
        {
            var list = FillToDoList(ReadFile());
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i] != list[int.Parse(taskToRemove) - 1])
                    {
                        writer.WriteLine(list[i].Name + ";" + list[i].IsDone + ";" + list[i].Priority);
                    }
                }
            }
        }

        public static void UnsupportedArg()
        {
            Console.WriteLine("\n *** Unsupported argument ***");
            PrintUsage();
        }

        public static void HighCounter(List<ToDo> toDoList)
        {
            int counter = 0;
            for (int i = 0; i < toDoList.Count(); i++)
            {
                if (toDoList[i].Priority == 3 && toDoList[i].IsDone != true)
                {
                    counter++;
                }
            }
            if (counter > 4)
            {
                Console.WriteLine("\nYou have {0} undone HIGH priority tasks. Highest time to take care of those.", counter);
            }
        }
    }
}
