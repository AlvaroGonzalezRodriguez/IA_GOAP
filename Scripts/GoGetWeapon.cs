using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGetWeapon : GAction
{
    public override bool PrePerform()
    {
        if(beliefs.HasState("waitingForVendor"))
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
