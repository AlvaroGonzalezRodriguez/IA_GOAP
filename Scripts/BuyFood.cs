using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFood : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveVendor();
        if (target == null)
            return false;
        
        if(!target.GetComponent<GAgent>().beliefs.HasState("isSelling"))
        {
            GWorld.Instance.AddVendor(target);
            target = null;
            return false;
        }

        resource = target.GetComponent<GAgent>().inventory.FindItemWithTag("Animal");
        if (resource == null)
        {
            GWorld.Instance.AddVendor(target);
            target = null;
            return false;
        }
        
        GWorld.Instance.GetWorld().ModifyState("sellingFood", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.AddVendor(target);
        if(target)
        {
            target.GetComponent<GAgent>().beliefs.RemoveState("isSelling");
            GetComponent<GAgent>().inventory.AddItem(resource);
            target.GetComponent<GAgent>().inventory.RemoveItem(resource);
        }
        return true;
    }
}