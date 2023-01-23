using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congregate : GAction
{
    public override bool PrePerform()
    {
        if(GWorld.Instance.GetWorld().GetStates().ContainsKey("aliensWhoKnows"))
            if(GWorld.Instance.GetWorld().GetStates()["aliensWhoKnows"] <= 3)
                return false;

        GWorld.Instance.GetWorld().ModifyState("aliensWhoKnows", -3);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.AddAlien(this.gameObject);
        GWorld.Instance.GetWorld().ModifyState("alienFighting", 1);
        return true;
    }
}
