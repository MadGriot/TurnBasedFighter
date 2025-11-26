using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorLeaf : BehaviorNode
{
    public delegate bool Tick();
    public delegate bool CanActivate();

    public Tick ProcessMethod;
    public CanActivate CanActivateMethod;

    public BehaviorLeaf() { }

    public BehaviorLeaf(string name, Tick processMethod, CanActivate canActivate)
    {
        Name = name;
        ProcessMethod = processMethod;
        CanActivateMethod = canActivate;
    }

    public override bool Process() => ProcessMethod?.Invoke() ?? false;

    public override bool CanActivateCheck() => CanActivateMethod?.Invoke() ?? false;
}
