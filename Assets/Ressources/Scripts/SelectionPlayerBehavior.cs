using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }

    public void SelectionNormal()
    {
        PlayerPrefs.SetString("TSTag", "Untagged");
    }

    public void SelectionElec()
    {
        PlayerPrefs.SetString("TSTag", "PlayerElec");
    }

    public void SelectionMeca()
    {
        PlayerPrefs.SetString("TSTag", "PlayerMeca");
    }

    public void SelectionFyki()
    {
        PlayerPrefs.SetString("TSTag", "PlayerFyki");
    }

    public void SelectionGBio()
    {
        PlayerPrefs.SetString("TSTag", "PlayerGBio");
    }

    public void SelectionMath()
    {
        PlayerPrefs.SetString("TSTag", "PlayerMath");
    }

    public void SelectionGC()
    {
        PlayerPrefs.SetString("TSTag", "PlayerGC");
    }

    public void SelectionInfo()
    {
        PlayerPrefs.SetString("TSTag", "PlayerInfo");
    }
}