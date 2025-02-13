# Task Tracer CLI

Task Tracer CLI is a command-line interface application designed to manage tasks quickly and efficiently. With a simple set of commands, you can add, update, delete, and list tasks, as well as mark them as in-progress or done.

## Technologies Used (Stack)

This project was built using the following technologies:

- **.NET 9.0** – Modern and high-performance framework for building applications.
- **C#** – The primary programming language used for development.

## Features

- **Add Task:** Create a new task with a given description.
- **Update Task:** Modify an existing task by its ID.
- **Delete Task:** Remove a task by its ID.
- **Mark In Progress:** Change a task's status to in-progress.
- **Mark Done:** Mark a task as completed.
- **List Tasks:** List all tasks or filter tasks by status (done, todo, in-progress).

## Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/limaenz/task-tracer-cli.git
   ```
2. **Navigate to the Project Directory:**
   ```bash
   cd task-tracer-cli
   ```
3. **Build the Project:**
   ```bash
   dotnet build
   ```
4. **Run the Project**
   ```bash
   dotnet run
   ```

## Usage

After building the project, you can run the CLI tool using the following commands:

```bash
Usage: task-cli [operation] [arguments]

Operations:
  add                 
    Adding a new task.
    Example: task-cli add "Buy groceries"
    Output: Task added successfully (ID: 1)

  update              
    Updating an existing task.
    Example: task-cli update 1 "Buy groceries and cook dinner"

  delete              
    Deleting a task.
    Example: task-cli delete 1

  mark-in-progress    
    Marking a task as in progress.
    Example: task-cli mark-in-progress 1

  mark-done           
    Marking a task as done.
    Example: task-cli mark-done 1

  list                
    Listing all tasks.
    Example: task-cli list

  list [status]       
    Listing tasks filtered by status.
    Available statuses: done, todo, in-progress.
    Examples:
      task-cli list done
      task-cli list todo
      task-cli list in-progress
``` 
