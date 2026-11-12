using UnityEngine;

public class PauseMenuScript : BaseMenu
{
    public void QuitToMenu()
    {
        SceneLoader.LoadScene("MainMenu");
    }
}
