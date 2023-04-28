using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
public class GoldUIText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldAmount;
    public int gold = 0;
    public LocalizedString localizedString;
    /*
    private void Start()
    {
        gold = PlayerPrefs.GetInt("Gold");
        goldAmount.text = "Gold: " + gold.ToString();
    }

    public void LoadGold()
    {
        gold = PlayerPrefs.GetInt("Gold");
        goldAmount.text = "Gold: " + gold.ToString();
    }*/

    void Update()
    {
        goldAmount.text = string.Format("{0} {1}", localizedString.GetLocalizedString(), gold);
    }

}
