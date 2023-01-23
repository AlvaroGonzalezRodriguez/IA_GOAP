using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHunt : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveAnimal();
        if (target == null)
            return false;
        
        GWorld.Instance.GetWorld().ModifyState("freeAnimal", -1);
        beliefs.RemoveState("atTown");
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("freeAnimal", 1);
        if(target)
            GetComponent<GAgent>().inventory.AddItem(target);
        GWorld.Instance.AddAnimal(target);
        return true;
    }
}