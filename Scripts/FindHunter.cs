using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHunter : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        if(beliefs.HasState("isSelling"))
            return false;
        
        target = GWorld.Instance.RemoveHunter();
        if (target == null)
            return false;

        if(!target.GetComponent<GAgent>().beliefs.HasState("waitingForVendor"))
        {
            GWorld.Instance.AddHunter(target);
            target = null;
            return false;
        }

        resource = target.GetComponent<GAgent>().inventory.FindItemWithTag("Animal");
        if (resource == null)
        {
            GWorld.Instance.AddHunter(target);
            target = null;
            return false;
        }

        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("hunterWaiting", -1);
        if (target)
        {
            GWorld.Instance.AddHunter(target);
            target.GetComponent<GAgent>().beliefs.RemoveState("waitingForVendor");
            GetComponent<GAgent>().inventory.AddItem(resource);
            target.GetComponent<GAgent>().inventory.RemoveItem(resource);
        }
        return true;
    }
}