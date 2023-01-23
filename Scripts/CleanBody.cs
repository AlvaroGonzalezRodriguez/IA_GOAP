using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBody : GAction
{
    public override bool PrePerform()
    {
        if(beliefs.HasState("isSelling"))
            return false;
        
        target = GWorld.Instance.RemoveBody();
        if(target == null)
            return false;
        
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("bodyInFloor", -1);
        Destroy(target);
        return true;
    }
}
