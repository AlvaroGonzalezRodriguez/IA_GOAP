using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFood : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GameObject food = GetComponent<GAgent>().inventory.FindItemWithTag("Animal");
        GetComponent<GAgent>().inventory.RemoveItem(food);
        return true;
    }
}
