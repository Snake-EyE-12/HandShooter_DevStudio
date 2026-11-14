using UnityEngine;

public class Tester : MonoBehaviour
{
    public void Hit(int value)
    {
        Debug.Log("Hit: " + gameObject.name + " value: " + value);
    }
}