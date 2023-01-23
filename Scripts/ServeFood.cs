using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeFood : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveTable();
        if(target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("tableWithFood", 1);
        GWorld.Instance.AddTable(target);
        return true;
    }
}
