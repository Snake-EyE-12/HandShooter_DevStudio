using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    [SerializeField] private FingerCollector collector;
    [SerializeField] private HandDisplay display;
    
    private void Update()
    {
        RenderHand();
    }
    
    private void RenderHand()
    {
        bool[] input_array = new[]
        {
            Keyboard.current.digit1Key.isPressed && collector.Has(FingerType.Pinky),
            Keyboard.current.digit2Key.isPressed && collector.Has(FingerType.Ring),
            Keyboard.current.digit3Key.isPressed && collector.Has(FingerType.Middle),
            Keyboard.current.digit4Key.isPressed && collector.Has(FingerType.Index),
            Keyboard.current.digit5Key.isPressed && collector.Has(FingerType.Thumb)
        };
        display.Show(input_array);
    }
    
    
    public void AddFinger(Finger finger)
    {
        Debug.Log("Added a finger");
        collector.Collect(finger);
    }

    public bool Has(List<FingerType> requirements)
    {
        foreach (FingerType typeFinger in requirements)
        {
            if(!collector.Has(typeFinger))
                return false;
        }
        return true;
    }


}