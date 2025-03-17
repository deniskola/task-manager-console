using System.Text.Json;
using TaskManagerConsole;

class Program
{
    static readonly string SaveFile = "tasks.json";
    static List<TaskItem> tasks = new();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        LoadTasks();
        Console.WriteLine("\n===== 📝 TASK MANAGER CONSOLE =====\n");

        while (true)
        {
            Console.Write("Enter command (add/list/done/remove/clear/exit): ");
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
                    Console.WriteLine("\n👋 Exiting Task Manager. Have a great day!\n");
                    return;
                default:
                    Console.WriteLine("⚠️ Unknown command. Try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task description: ");
        string? description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("⚠️ Task description cannot be empty.");
            return;
        }
        
        Console.Write("Enter due date (yyyy-MM-dd) or leave blank: ");
        string dueDateInput = Console.ReadLine();
        DateTime? dueDate = DateTime.TryParse(dueDateInput, out DateTime parsedDate) ? parsedDate : null;

        Console.Write("Enter priority (low, normal, high): ");
        string priority = Console.ReadLine()?.Trim().ToLower() switch
        {
            "low" => "Low",
            "high" => "High",
            _ => "Normal" // default
        };

        tasks.Add(new TaskItem { Description = description, IsCompleted = false, DueDate = dueDate, Priority = priority });
        SaveTasks();
        Console.WriteLine("✅ Task added successfully!");
    }

    static void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("📭 No tasks available! Add some tasks first.");
            return;
        }

        Console.WriteLine("\n===== 📌 YOUR TASKS =====\n");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsCompleted ? "[✓]" : "[ ]";
            string dueDate = tasks[i].DueDate.HasValue ? $"(Due: {tasks[i].DueDate:yyyy-MM-dd})" : "";
            string priorityColor = tasks[i].Priority switch
            {
                "High" => "\x1b[31m", // Red
                "Low" => "\x1b[32m", // Green
                _ => "\x1b[33m" // Yellow (Normal)
            };
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Description} {dueDate} {priorityColor}[{tasks[i].Priority}]\x1b[0m");
        }
        Console.WriteLine();    
    }

    static void CompleteTask()
    {
        Console.Write("Enter task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            SaveTasks();
            Console.WriteLine("🎉 Task marked as completed!");
        }
        else
        {
            Console.WriteLine("⚠️ Invalid task number. Please try again.");
        }
    }

    static void RemoveTask()
    {
        Console.Write("Enter task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            SaveTasks();
            Console.WriteLine("🗑️ Task removed successfully!");
        }
        else
        {
            Console.WriteLine("⚠️ Invalid task number. Please try again.");
        }
    }

    static void ClearTasks()
    {
        tasks.Clear();
        SaveTasks();
        Console.WriteLine("🚀 All tasks cleared!");
    }

    static void SaveTasks()
    {
        File.WriteAllText(SaveFile, JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }));
    }

    static void LoadTasks()
    {
        if (File.Exists(SaveFile))
        {
            string json = File.ReadAllText(SaveFile);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            Console.WriteLine("📂 Tasks loaded successfully!");
        }
        else
        {
            Console.WriteLine("📂 No existing tasks found. Starting fresh!");
        }
    }
}