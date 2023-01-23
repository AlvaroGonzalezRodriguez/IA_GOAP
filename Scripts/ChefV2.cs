using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefV2 : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("cook", 1, false);
        goals.Add(s1, 5);

        SubGoal s3 = new SubGoal("rested", 1, false);
        goals.Add(s3, 2);
        Invoke("GetTired", Random.Range(45,60));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(30, 60));
    }

}
