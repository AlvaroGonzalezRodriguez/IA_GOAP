using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("aliensWhoKnows", 1);
        return true;
    }
}