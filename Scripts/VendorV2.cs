using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorV2 : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("sellFood", 1, false);
        goals.Add(s1, 4);

        SubGoal s2 = new SubGoal("cleanBody", 1, false);
        goals.Add(s2, 5);
    }
}
