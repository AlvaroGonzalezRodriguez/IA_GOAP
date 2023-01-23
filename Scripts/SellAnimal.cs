using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAnimal : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("sellingFood", 1);
        beliefs.ModifyState("isSelling", 0);
        return true;
    }
}