using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents 
{
    public static event EventHandler DialogueInitiated;
    public static event EventHandler DialogueFinished;

    public static void InvokeDialogueInitiated()
    {
        DialogueInitiated(null,EventArgs.Empty);
    }

    public static void InvokeDialogueFinished()
    {
        DialogueFinished(null, EventArgs.Empty);
    }

}
