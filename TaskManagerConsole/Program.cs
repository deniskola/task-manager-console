using System.Text.Json;
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
                case "add":
                    AddTask();
                    break;
                case "list":
                    ListTasks();
                    break;
                case "done":
                    CompleteTask();
                    break;
                case "remove":
                    RemoveTask();
                    break;
                case "clear":
                    ClearTasks();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Unknown command. Try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task description: ");
        string? description = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(description))
        {
            tasks.Add(new TaskItem { Description = description, IsCompleted = false });
            SaveTasks();
            Console.WriteLine("Task added");
        }
    }

    static void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available!");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsCompleted ? "[✔]" : "[]";
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
        }
    }

    static void CompleteTask()
    {
        Console.WriteLine("Enter task number to mark as done: ");
        if(int.TryParse(Console.ReadLine(), out int index) && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            SaveTasks();
            Console.WriteLine("Task marked as completed");
        }
        else
        {
            Console.WriteLine("Invalid task number");
        }
    }

    static void RemoveTask()
    {
        Console.WriteLine("Enter task number to remove: ");
        if(int.TryParse(Console.ReadLine(), out int index) && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            SaveTasks();
            Console.WriteLine("Task removed");
        }
        else
        {
            Console.WriteLine("Invalid task number");
        }
    }

    static void ClearTasks()
    {
        tasks.Clear();
        SaveTasks();
        Console.WriteLine("All tasks cleared");
    }

    static void SaveTasks()
    {
        File.WriteAllText(SaveFile, JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }));
        Console.WriteLine("Tasks saved");
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