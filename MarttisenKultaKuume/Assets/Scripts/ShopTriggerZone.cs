using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTriggerZone : MonoBehaviour, IUsableObject
{
    private SceneSwitcher sceneSwitcher;
    private ShopSceneDisabler disabler;
    void Awake()
    {
        sceneSwitcher = GetComponent<SceneSwitcher>();
        disabler = GetComponent<ShopSceneDisabler>();
    }
    public void Use()
    {
        Debug.Log("Shop start");
        disabler.StartShop();
        sceneSwitcher.LoadSceneOnTop("ShopMenu");
    }
}
