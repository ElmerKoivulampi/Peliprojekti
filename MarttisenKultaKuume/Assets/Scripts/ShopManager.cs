using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int gold;
    public TMP_Text goldUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    
    // Start is called before the first frame update
    void Start()
    {
        // ADD PLAYERPREF GOLD AMOUNT TO THE SHOP MENU GOLD AMOUNT
        AddGold(PlayerPrefs.GetInt("Gold"));

        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        goldUI.text = "Gold: " + gold.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold() // script to add gold for user
    {
        gold++;
        goldUI.text = "Gold: " + gold.ToString();
        CheckPurchaseable();
        SaveGoldPlayerPref();
    }

    //variant for when the player eventually washes the contents of the gold pan.
    public void AddGold(int amt)
    {
        gold += amt;
        goldUI.text = "Gold: " + gold.ToString();
        CheckPurchaseable();
        SaveGoldPlayerPref();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (gold >= shopItemsSO[i].baseCost) //onko massia tarpeeks
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (gold >= shopItemsSO[btnNo].baseCost)
        {
            gold = gold - shopItemsSO[btnNo].baseCost;
            goldUI.text = "Gold: " + gold.ToString();
            CheckPurchaseable();
            SaveGoldPlayerPref();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Gold: " + shopItemsSO[i].baseCost.ToString();
        }
    }

    public void SaveGoldPlayerPref()
    {
        PlayerPrefs.SetInt("Gold", gold);
    }

    public void ClearGold()
    {
        gold = 0;
        goldUI.text = "Gold: " + gold.ToString();
        PlayerPrefs.SetInt("Gold", 0);
    }
}
