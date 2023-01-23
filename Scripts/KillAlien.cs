using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAlien : GAction
{
    public override bool PrePerform()
    {
        if(beliefs.HasState("waitingForVendor"))
            return false;
        
        target = GWorld.Instance.RemoveAlien();
        if(target == null)
            return false;

        return true;
    }

    public override bool PostPerform()
    {
        //GetComponent<GAgent>().inventory.AddItem(target);
        GWorld.Instance.AddBody(target);
        GWorld.Instance.GetWorld().ModifyState("alienFighting", -1);
        GWorld.Instance.GetWorld().ModifyState("bodyInFloor", 1);
        return true;
    }
}
