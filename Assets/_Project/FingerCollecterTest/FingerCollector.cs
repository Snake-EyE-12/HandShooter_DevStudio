using System.Collections.Generic;
using UnityEngine;

public class FingerCollector : MonoBehaviour
{
    private List<Finger> fingers = new List<Finger>();

    public void Set(List<Finger> fingers) => this.fingers = fingers;
    public List<Finger> Get()  => this.fingers;

    public void Collect(Finger finger)
    {
        this.fingers.Add(finger);
    }

    public bool Has(FingerType type)
    {
        foreach (var finger in this.fingers)
        {
            if (finger.IsTypeOf(type))
            {
                return true;
            }
        }

        return false;
    }
}

public enum FingerType
{
    Thumb,
    Index,
    Middle,
    Ring,
    Pinky,
}

[System.Serializable]
public class FingerDefinition
{
    public FingerType type;

    public FingerDefinition(FingerType type)
    {
        this.type = type;
    }
}
public class Finger
{
    private FingerDefinition definition;

    public Finger(FingerDefinition definition)
    {
        this.definition = definition;
    }

    public bool IsTypeOf(FingerType type)
    {
        return this.definition.type == type;
    }
}


public class ExampleFingerCollectorUsage
{
    public void eg()
    {
        Finger thumb = new Finger(new FingerDefinition(FingerType.Thumb));
        Finger pointer = new Finger(new FingerDefinition(FingerType.Index));
        Finger middle = new Finger(new FingerDefinition(FingerType.Middle));
        Finger ring = new Finger(new FingerDefinition(FingerType.Ring));
        Finger pinkie = new Finger(new  FingerDefinition(FingerType.Pinky));

        List<Finger> realFingers = new List<Finger>()
        {
            pointer,
            middle,
            ring,
            pinkie
        };
        
        FingerCollector fingerCollector = new FingerCollector();
        
        fingerCollector.Set(realFingers);
        fingerCollector.Collect(thumb);
        
        List<Finger> active_fingers = fingerCollector.Get();
    }
}