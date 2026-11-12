using TMPro;
using UnityEngine;

public class LevelSelectScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private LevelInfo myData;
    [SerializeField] private int selectID;
    [SerializeField] private LevelSelectMenuScript levelSelectMenu;

    // this is the actual menu item that is generated on startup by the level select menu to populate the level list
    public void Populate(LevelSelectMenuScript menu, LevelInfo ld, int select)
    {
        levelSelectMenu = menu;
        myData = ld;
        selectID = select;
        text.text = myData.scene.name;
    }

    // tells the menu to select this level information for display
    public void Select()
    {
        levelSelectMenu.SelectLevel(selectID);
    }
}
