using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    // PATTERN 8: COMMAND
    void Execute();
    void Undo();
}
