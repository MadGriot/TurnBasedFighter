using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorSequence : BehaviorNode
{
    public BehaviorSequence(string name)
    {
        Name = name;
    }

    public override bool Process()
    {
        bool childStatus = Children[CurrentChild].Process();
        if (childStatus == false)
        {
            CurrentChild = 0;
            return childStatus;
        }

        CurrentChild++;
        if (CurrentChild >= Children.Count)
        {
            CurrentChild = 0;
            childStatus = false;
        }

        return childStatus;
    }

    public override bool CanActivateCheck()
    {
        foreach (BehaviorNode child in Children)
        {
            if (!child.CanActivateCheck())
                return false;
        }
        return true;
    }
}
