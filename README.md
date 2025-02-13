# 📝 Task Tracker CLI

Task Tracker CLI is a command-line application designed to **track and manage tasks** efficiently. With this tool, you can **add, update, delete, and list tasks**, as well as mark them as **in-progress** or **done**.

## 🚀 Features

- ✅ **Add Task** – Create a new task with a short description.
- ✏️ **Update Task** – Modify an existing task by its ID.
- 🗑️ **Delete Task** – Remove a task by its ID.
- 🚧 **Mark In Progress** – Change a task’s status to *in-progress*.
- 🎯 **Mark Done** – Mark a task as *completed*.
- 📜 **List Tasks** – View all tasks or filter tasks by status (*done, todo, in-progress*).
- 💾 **Data Persistence** – Tasks are stored in a **JSON file**.

---

## 🛠️ Tech Stack

This project is built using:

- **.NET 9.0** – High-performance framework for CLI applications.
- **C#** – The primary programming language.
- **Native File System Handling** – Uses a JSON file to store tasks.

---

## 📥 Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/limaenz/task-tracer-cli.git
   ```
2. **Navigate to the project directory:**
   ```bash
   cd task-tracer-cli
   ```
3. **Build the project (Requires .NET 9.0):**
   ```bash
   dotnet build
   ```
3. **Run the project:**
   ```bash
   dotnet run
   ```
---

## 🚀 Usage

Run the CLI tool using the following commands:

```bash
Usage: task-cli [operation] [arguments]
```

### **Task Management Commands**
| Command | Description | Example |
|---------|------------|---------|
| `add` | Add a new task | `task-cli add "Buy groceries"` |
| `update` | Update an existing task | `task-cli update 1 "Buy groceries and cook dinner"` |
| `delete` | Delete a task | `task-cli delete 1` |
| `mark-in-progress` | Mark task as in-progress | `task-cli mark-in-progress 1` |
| `mark-done` | Mark task as done | `task-cli mark-done 1` |
| `list` | List all tasks | `task-cli list` |
| `list [status]` | List tasks by status (`todo`, `in-progress`, `done`) | `task-cli list done` |

---

## 🗂️ Task Properties

Each task is stored in a **JSON file** with the following properties:

- `id` – Unique identifier
- `description` – Short task description
- `status` – Task state (`todo`, `in-progress`, `done`)
- `createdAt` – Date and time of creation
- `updatedAt` – Last modified timestamp

---

## 📌 Project URL

This project is part of the **roadmap.sh** project list:  
🔗 **[Task Tracker on Roadmap.sh](https://roadmap.sh/projects/task-tracker)**  
