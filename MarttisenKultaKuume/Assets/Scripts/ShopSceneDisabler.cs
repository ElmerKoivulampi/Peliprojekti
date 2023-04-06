using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSceneDisabler : MonoBehaviour
{
    private GameObject worldCam;
    private GameObject eventSys;
    private GameObject goldText;
    [SerializeField] public Canvas canvas;
    void Start()
    {
        worldCam = GameObject.Find("Main Camera");
        eventSys = GameObject.Find("EventSystem");
        goldText = GameObject.Find("GoldAmount");
    }

    public void StartShop()
    {
        canvas.GetComponent<UIDisabler>().HideUI();
        worldCam.SetActive(false);
        eventSys.SetActive(false);
    }

    public void EndShop()
    {
        goldText.GetComponent<GoldUIText>().LoadGold();
        if (worldCam != null)
        {
            worldCam.SetActive(true);
        }
        if (eventSys != null)
        {
            eventSys.SetActive(true);
        }
        if (canvas != null)
        {
            canvas.GetComponent<UIDisabler>().ShowUI();
        }
    }
}
