using TaskTrackerCli.Core.Interfaces;

namespace TaskTrackerCli.src.Features.HelpTask
{
    public class HelpTaskCommand : ICommand
    {
        public string Name => "help";

        public void Execute(string[] parameters)
        {
            bool operationHelp = parameters[1] == "help";
            if (!operationHelp)
                return;
            Console.WriteLine(
            $@"
Usage: task-cli [operation] [arguments]

Operations:
  add                 
    Adiciona uma nova tarefa.
    Exemplo: task-cli add ""Buy groceries""
    Output: Task added successfully (ID: 1)

  update              
    Atualiza uma tarefa existente.
    Exemplo: task-cli update 1 ""Buy groceries and cook dinner""

  delete              
    Remove uma tarefa.
    Exemplo: task-cli delete 1

  mark-in-progress    
    Marca uma tarefa como em andamento.
    Exemplo: task-cli mark-in-progress 1

  mark-done           
    Marca uma tarefa como concluída.
    Exemplo: task-cli mark-done 1

  list                
    Lista todas as tarefas.
    Exemplo: task-cli list

  list [status]       
    Lista tarefas filtradas por status.
    Status disponíveis: done, todo, in-progress.
    Exemplos:
      task-cli list done
      task-cli list todo
      task-cli list in-progress
");
        }
    }
}