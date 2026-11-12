using UnityEngine;

public class DebugMenuPauseThingScript : MonoBehaviour
{
    [SerializeField] private MenuManager mm;
    [SerializeField] private bool paused = false;

    public void Update()
    {
        // a bit hardcoded way to pauuse the game however we decide to do that properly.
        if (false)//Input.GetKeyDown(KeyCode.Tilde)) // or maybe not while the new unity input system is yelling at me
        {
            if (paused)
            {
                mm.DisplayMenu(0);
            } else
            {
                mm.DisplayMenu(1);
            }
            paused = !paused;
        }
    }
}
