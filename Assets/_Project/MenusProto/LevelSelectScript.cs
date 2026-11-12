using TMPro;
using UnityEngine;

public class LevelSelectScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private LevelInfo myData;
    [SerializeField] private int selectID;
    [SerializeField] private LevelSelectMenuScript levelSelectMenu;

    public void Populate(LevelSelectMenuScript menu, LevelInfo ld, int select)
    {
        levelSelectMenu = menu;
        myData = ld;
        selectID = select;
        text.text = myData.scene.name;
    }

    public void Select()
    {
        levelSelectMenu.SelectLevel(selectID);
    }
}
