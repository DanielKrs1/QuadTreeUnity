using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{     // PATTERN 8: COMMAND
    List<ICommand> commands = new List<ICommand>();
    List<ICommand> undoneCommands = new List<ICommand>();
    public void Execute(ICommand command)
    {
        command.Execute();
        commands.Add(command);
        undoneCommands.Clear();
    }

    public void Undo()
    {
        if (commands.Count > 0)
        {
            ICommand command = commands[commands.Count - 1];
            command.Undo();
            undoneCommands.Add(command);
            commands.RemoveAt(commands.Count - 1);
        }
    }

    public void Redo()
    {
        if (undoneCommands.Count > 0)
        {
            ICommand command = undoneCommands[undoneCommands.Count - 1];
            command.Execute();
            commands.Add(command);
            undoneCommands.RemoveAt(undoneCommands.Count - 1);
        }
    }

    void OnStart() 
    { // Clear commands when buy phase ends
        commands.Clear();
        undoneCommands.Clear();
    }

    void Start()
    {
        ServiceLocator.Broker.SubStart(OnStart);
    }
}
