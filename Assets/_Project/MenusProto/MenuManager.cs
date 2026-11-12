using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private BaseMenu[] menus;

    // closes all other menus and displays the appropriate menu.
    public void DisplayMenu(int toDisplay)
    {
        foreach(var m in menus)
        {
            m.CloseMenu();
        }

        menus[toDisplay].OpenMenu();
    }

    public void Start()
    {
        DisplayMenu(0);
    }
}

public abstract class BaseMenu : MonoBehaviour
{
    // base class for all menus to allow some functionality on opening a menu
    public virtual void OpenMenu()
    {
        gameObject.SetActive(true);
    }
    public virtual void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
