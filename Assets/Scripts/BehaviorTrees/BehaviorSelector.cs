using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorSelector : BehaviorNode
{
    public BehaviorNode SelectedSequence { get; private set; }

    public BehaviorSelector(string name)
    {
        Name = name;
    }

    public override bool Process()
    {
        foreach (BehaviorNode sequenceNode in Children)
        {
            if (sequenceNode.CanActivateCheck())
            {
                SelectedSequence = sequenceNode;
                return true;
            }
        }
        return false;
    }
}
