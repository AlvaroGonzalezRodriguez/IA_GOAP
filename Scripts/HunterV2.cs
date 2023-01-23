using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterV2 : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("giveFood", 1, false);
        goals.Add(s1, 4);
        beliefs.ModifyState("atTown", 0);

        SubGoal s3 = new SubGoal("fed", 1, false);
        goals.Add(s3, 5);
        Invoke("IsHungry", Random.Range(30,50));

        SubGoal s4 = new SubGoal("killAlien", 1, false);
        goals.Add(s4, 6);
    }

    void IsHungry()
    {
        beliefs.ModifyState("isHungry", 0);
        Invoke("IsHungry", Random.Range(30,50));
    }
    
}
