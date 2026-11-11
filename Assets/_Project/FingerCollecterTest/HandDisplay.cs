using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HandDisplay : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private Image thumb;
    [SerializeField] private Image index;
    [SerializeField] private Image middle;
    [SerializeField] private Image ring;
    [SerializeField] private Image pinky;

    private void Update()
    {
        
        pinky.gameObject.SetActive(actives[0]);
        ring.gameObject.SetActive(actives[1]);
        middle.gameObject.SetActive(actives[2]);
        index.gameObject.SetActive(actives[3]);
        thumb.gameObject.SetActive(actives[4]);
        
    }

    private bool[] actives =  new bool[5];
    public void Show(bool[] fingers)
    {
        if (fingers == null || fingers.Length == 0) return;
        actives = fingers;
        
        parent.SetActive(!(!fingers[0] && !fingers[1] && !fingers[2] && !fingers[3] && !fingers[4]));
        
    }
}
