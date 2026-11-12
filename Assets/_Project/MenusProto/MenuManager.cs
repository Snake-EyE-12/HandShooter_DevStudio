using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private BaseMenu[] menus;

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
    public virtual void OpenMenu()
    {
        gameObject.SetActive(true);
    }
    public virtual void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
