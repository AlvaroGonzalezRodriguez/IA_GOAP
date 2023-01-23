using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStore : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.ModifyState("atTown", 0);
        beliefs.ModifyState("waitingForVendor", 0);
        GWorld.Instance.GetWorld().ModifyState("hunterWaiting", 1);
        //GWorld.Instance.AddHunter(this.gameObject);
        //beliefs.ModifyState("atHospital", 1);
        return true;
    }
}