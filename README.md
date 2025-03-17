# 📝 Task Manager Console  

A simple **task management CLI application** built with **.NET 8**.  

## 🚀 Features  
- ✅ Add, list, mark as done, remove, and clear tasks  
- 💾 Save and load tasks automatically using JSON  
- 📅 Set **due dates** for tasks  
- 🔝 Prioritize tasks (**High**, **Normal**, **Low**)  
- 🎨 **Color-coded** priorities (🔴 High, 🟡 Normal, 🟢 Low)  
- 📌 Tasks are **sorted by priority and due date**  
- 🖥 Simple and **easy-to-use** command-line interface  

---

## 🛠 Prerequisites  
- Install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  

---

## 📥 Installation  
Clone this repository:  
```sh
git clone https://github.com/deniskola/task-manager-console.git  
cd task-manager-console  
```

---

## ▶️ How to Run
```sh
dotnet run
```

---

## 📌 Usage
🔹 Available Commands
| Command  | Description | Example Usage |
|----------|------------|--------------|
| `add`    | Add a new task with a description, optional due date, and priority | `add` → (enter details) |
| `list`   | Show all tasks sorted by priority & due date | `list` |
| `done`   | Mark a task as completed | `done` → (enter task number) |
| `remove` | Remove a task | `remove` → (enter task number) |
| `clear`  | Delete all tasks | `clear` |
| `exit`   | Exit the application | `exit` |

---

## 🖥 Example
```sh
===== 📝 TASK MANAGER CONSOLE =====  

Enter command (add/list/done/remove/clear/exit): add  
Enter task description: Finish project report  
Enter due date (yyyy-MM-dd) or leave blank: 2024-08-15  
Enter priority (low, normal, high): high  
➕ Task added successfully!  

Enter command (add/list/done/remove/clear/exit): list  

===== 📌 YOUR TASKS =====  

1. [ ] Finish project report (Due: 2024-08-15) 🔴[High]
```

---

## 💾 Task Storage

- Tasks are stored in `tasks.json` in the same directory.  
- The app automatically saves and loads tasks on startup.
