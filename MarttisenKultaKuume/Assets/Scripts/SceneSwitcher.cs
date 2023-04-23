using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    ShopSceneDisabler disabler;
    private void Awake()
    {
        disabler = GetComponent<ShopSceneDisabler>();
    }
    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene current)
    {
        Debug.Log("Unload?!");
        disabler.EndShop();
    }
    public void LoadSceneOnTop(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadSceneOnTop(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
