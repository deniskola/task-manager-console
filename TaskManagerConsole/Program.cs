﻿using System.Text.Json;
using TaskManagerConsole;

class Program
{
    static readonly string SaveFile = "tasks.json";
    static List<TaskItem> tasks = new();

    static void Main()
    {
        LoadTasks();
        Console.WriteLine("\n----- Task Manager Console -----\n");

        while (true) {
            Console.Write("Enter command: ");
            string? command = Console.ReadLine()?.Trim().ToLower();

            switch (command) 
            {
                case "load":
                    LoadTasks();
                    break;
                default:
                    Console.WriteLine("Unknown command. Try again.");
                    break;
            }
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(SaveFile))
        {
            string json = File.ReadAllText(SaveFile);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            Console.WriteLine("Tasks loaded.");
        }
    }
}