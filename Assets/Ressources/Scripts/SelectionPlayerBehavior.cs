using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionPlayerBehavior : MonoBehaviour
{
    public Text Credits1;
    public Text Credits2;
    public Text Credits3;
    public Text Credits4;
    public Text Credits5;
    public Text Credits6;
    public Text Credits7;
    public Text Credits8;

    public Button bInfo;
    public Text tInfo;
    public Button ButtonBuyInfo;

    public Button bElec;
    public Text tElec;
    public Button ButtonBuyElec;

    public Button bMeca;
    public Text tMeca;
    public Button ButtonBuyMeca;

    public Button bFyki;
    public Text tFyki;
    public Button ButtonBuyFyki;

    public Button bMap;
    public Text tMap;
    public Button ButtonBuyMap;

    public Button bGc;
    public Text tGc;
    public Button ButtonBuyGc;

    public Button bGbio;
    public Text tGbio;
    public Button ButtonBuyGbio;
    // Start is called before the first frame update
    void Start()
    {
        /*PlayerPrefs.SetInt("InfoBuy",0);
        PlayerPrefs.SetInt("ElecBuy",0);
        PlayerPrefs.SetInt("MecaBuy",0);
        PlayerPrefs.SetInt("FykiBuy",0);
        PlayerPrefs.SetInt("MapBuy",0);
        PlayerPrefs.SetInt("GcBuy",0);
        PlayerPrefs.SetInt("GbioBuy",0);
        PlayerPrefs.SetInt("CreditsStage",61);*/

        Credits1.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits2.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits3.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits4.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits5.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits6.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits7.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits8.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();


        if(PlayerPrefs.GetInt("InfoBuy",0) == 1){
            GameObject.Find("CreditsInfo").SetActive(false);
            GameObject.Find("ButtonBuyInfo").SetActive(false);
        }
        else
        {
            bInfo.interactable = false;
            tInfo.text = "";
            if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
            {
                ButtonBuyInfo.interactable = false;
            }
        }

        if(PlayerPrefs.GetInt("ElecBuy",0) == 1){
            GameObject.Find("CreditsElec").SetActive(false);
            GameObject.Find("ButtonBuyElec").SetActive(false);
        }
        else
        {
            bElec.interactable = false;
            tElec.text = "";
            if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
            {
                ButtonBuyElec.interactable = false;
            }
        }

        if(PlayerPrefs.GetInt("MecaBuy",0) == 1){
            GameObject.Find("CreditsMeca").SetActive(false);
            GameObject.Find("ButtonBuyMeca").SetActive(false);
        }
        else
        {
            bMeca.interactable = false;
            tMeca.text = "";
            if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
            {
                ButtonBuyMeca.interactable = false;
            }
        }

        if(PlayerPrefs.GetInt("FykiBuy",0) == 1){
            GameObject.Find("CreditsFyki").SetActive(false);
            GameObject.Find("ButtonBuyFyki").SetActive(false);
        }
        else
        {
            bFyki.interactable = false;
            tFyki.text = "";
            if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
            {
                ButtonBuyFyki.interactable = false;
            }
        }

        if(PlayerPrefs.GetInt("MapBuy",0) == 1){
            GameObject.Find("CreditsMap").SetActive(false);
            GameObject.Find("ButtonBuyMap").SetActive(false);
        }
        else
        {
            bMap.interactable = false;
            tMap.text = "";
            if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
            {
                ButtonBuyMap.interactable = false;
            }
        }

        if(PlayerPrefs.GetInt("GcBuy",0) == 1){
            GameObject.Find("CreditsGc").SetActive(false);
            GameObject.Find("ButtonBuyGc").SetActive(false);
        }
        else
        {
            bGc.interactable = false;
            tGc.text = "";
            if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
            {
                ButtonBuyGc.interactable = false;
            }
        }

        if(PlayerPrefs.GetInt("GBiobuy",0) == 1){
            GameObject.Find("CreditsGbio").SetActive(false);
            GameObject.Find("ButtonBuyGbio").SetActive(false);
        }
        else
        {
            bGbio.interactable = false;
            tGbio.text = "";
            if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
            {
                ButtonBuyGbio.interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
        {
            ButtonBuyInfo.interactable = false;
        }
        if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
        {
            ButtonBuyElec.interactable = false;
        }
        if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
        {
            ButtonBuyMeca.interactable = false;
        }
        if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
        {
            ButtonBuyFyki.interactable = false;
        }
        if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
        {
            ButtonBuyMap.interactable = false;
        }
        if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
        {
            ButtonBuyGc.interactable = false;
        }
        if(PlayerPrefs.GetInt("CreditsStage",0) < 61)
        {
            ButtonBuyGbio.interactable = false;
        }

        Credits1.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits2.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits3.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits4.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits5.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits6.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits7.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
        Credits8.text = PlayerPrefs.GetInt("CreditsStage", 0).ToString();
    }

    public void SelectionInfo()
    {
        PlayerPrefs.SetString("TSTag", "PlayerInfo");
    }
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
    
    public void BuyInfo()
    {
        PlayerPrefs.SetInt("InfoBuy",1);
        GameObject.Find("CreditsInfo").SetActive(false);
        GameObject.Find("ButtonBuyInfo").SetActive(false);
        bInfo.interactable = true;
        tInfo.text = "Sélectionner";
        PlayerPrefs.SetInt("CreditsStage", PlayerPrefs.GetInt("CreditsStage",0) - 60);
    }
    public void BuyElec()
    {
        PlayerPrefs.SetInt("ElecBuy",1);
        GameObject.Find("CreditsElec").SetActive(false);
        GameObject.Find("ButtonBuyElec").SetActive(false);
        bElec.interactable = true;
        tElec.text = "Sélectionner";
        PlayerPrefs.SetInt("CreditsStage", PlayerPrefs.GetInt("CreditsStage",0) - 60);
    }
    public void BuyMeca()
    {
        PlayerPrefs.SetInt("MecaBuy",1);
        GameObject.Find("CreditsMeca").SetActive(false);
        GameObject.Find("ButtonBuyMeca").SetActive(false);
        bMeca.interactable = true;
        tMeca.text = "Sélectionner";
        PlayerPrefs.SetInt("CreditsStage", PlayerPrefs.GetInt("CreditsStage",0) - 60);
    }
    public void BuyFyki()
    {
        PlayerPrefs.SetInt("FykiBuy",1);
        GameObject.Find("CreditsFyki").SetActive(false);
        GameObject.Find("ButtonBuyFyki").SetActive(false);
        bFyki.interactable = true;
        tFyki.text = "Sélectionner";
        PlayerPrefs.SetInt("CreditsStage", PlayerPrefs.GetInt("CreditsStage",0) - 60);
    }
    public void BuyMap()
    {
        PlayerPrefs.SetInt("MapBuy",1);
        GameObject.Find("CreditsMap").SetActive(false);
        GameObject.Find("ButtonBuyMap").SetActive(false);
        bMap.interactable = true;
        tMap.text = "Sélectionner";
        PlayerPrefs.SetInt("CreditsStage", PlayerPrefs.GetInt("CreditsStage",0) - 60);
    }
    public void BuyGc()
    {
        PlayerPrefs.SetInt("GcBuy",1);
        GameObject.Find("CreditsGc").SetActive(false);
        GameObject.Find("ButtonBuyGc").SetActive(false);
        bGc.interactable = true;
        tGc.text = "Sélectionner";
        PlayerPrefs.SetInt("CreditsStage", PlayerPrefs.GetInt("CreditsStage",0) - 60);
    }
    public void BuyGbio()
    {
        PlayerPrefs.SetInt("GbioBuy",1);
        GameObject.Find("CreditsGbio").SetActive(false);
        GameObject.Find("ButtonBuyGbio").SetActive(false);
        bGbio.interactable = true;
        tGbio.text = "Sélectionner";
        PlayerPrefs.SetInt("CreditsStage", PlayerPrefs.GetInt("CreditsStage",0) - 60);
    }
}