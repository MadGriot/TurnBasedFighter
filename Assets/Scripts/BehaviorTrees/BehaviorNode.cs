using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorNode
{
    public List<BehaviorNode> Children { get; set; } = new();

    public int CurrentChild { get; set; } = 0;
    public string Name { get; set; }

    public BehaviorNode() { }
    public BehaviorNode(string name)
    {
        Name = name;
    }

    public virtual bool Process() => Children[CurrentChild].Process();
    public virtual bool CanActivateCheck() => Children[CurrentChild].CanActivateCheck();
    public void AddChild(BehaviorNode node)
    {
        Children.Add(node);
    }

}
