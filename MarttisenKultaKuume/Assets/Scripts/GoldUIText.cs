using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldUIText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldAmount;
    private int gold;

    private void Start()
    {
        gold = PlayerPrefs.GetInt("Gold");
        goldAmount.text = "Gold: " + gold.ToString();
    }

    public void LoadGold()
    {
        gold = PlayerPrefs.GetInt("Gold");
        goldAmount.text = "Gold: " + gold.ToString();
    }
}
