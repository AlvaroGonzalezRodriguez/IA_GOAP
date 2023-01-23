using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTable : GAction
{
    public override bool PrePerform()
    {
        if(beliefs.HasState("waitingForVendor") || beliefs.HasState("isSelling"))
            return false;
        target = GWorld.Instance.RemoveTable();
        if(target == null)
            return false;
        //GWorld.Instance.GetWorld().ModifyState("tableWithFood", -1);
        //inventory.AddItem(target);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("tableWithFood", -1);
        GWorld.Instance.AddTable(target);
        //inventory.RemoveItem(target);
        beliefs.RemoveState("isHungry");
        return true;
    } 
}