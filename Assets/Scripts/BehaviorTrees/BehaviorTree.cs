using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : BehaviorNode
{
    public BehaviorTree()
    {
        Name = "Tree";
    }

    public BehaviorTree(string name)
    {
        Name = name;
    }

    public override bool Process() => Children[CurrentChild].Process();

}
