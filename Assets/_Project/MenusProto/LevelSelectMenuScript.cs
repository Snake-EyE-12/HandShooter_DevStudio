using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenuScript : BaseMenu
{
    [SerializeField] private LevelInfo[] levels;
    [SerializeField] private int currentlySelectedData = 0;

    [SerializeField] private GameObject levelSelectScrollContent;
    [SerializeField] private LevelSelectScript levelSelectPrefab;

    [SerializeField] private TextMeshProUGUI levelDescription;
    [SerializeField] private Button StartButton;


    private void Start()
    {
        // setsup all the levels in the level select
        for (int i = 0; i < levels.Length; i++)
        {
            LevelSelectScript level = Instantiate(levelSelectPrefab.gameObject, levelSelectScrollContent.transform).GetComponent<LevelSelectScript>();
            level.Populate(this, levels[i], i);
            //level.GetComponent<RectTransform>(). = new Rect(0, -30 * i, 0, 0);
        }
    }

    // displays the level information oof tthe selected level from tthe level select list.
    public void SelectLevel(int selectedLevel)
    {
        currentlySelectedData = selectedLevel;
        DisplayLevelInformation();
    }

    // updated displayed level information
    public void DisplayLevelInformation()
    {
        levelDescription.gameObject.SetActive(true);
        levelDescription.text = levels[currentlySelectedData].description;
        StartButton.gameObject.SetActive(true);
    }

    // actually loads the selected level
    public void StartGame()
    {
        SceneLoader.LoadScene(levels[currentlySelectedData].scene.name);
    }

    // unselects the level
    public void UnselectLevel()
    {
        levelDescription.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
    }

    public override void OpenMenu()
    {
        base.OpenMenu();
        UnselectLevel();
    }

    public override void CloseMenu()
    {
        base.CloseMenu();
    }
}


// info for diisplaying level information in the level select menu
[Serializable]
public struct LevelInfo
{
    public SceneAsset scene;
    public string description;
}
