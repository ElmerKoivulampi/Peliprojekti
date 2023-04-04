using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokiMinigame : MonoBehaviour
{
    Camera worldCam;
    GameObject minigame;
    JokiSpawnManager minigameSpawnMan;
    VatiController vati;
    GameObject player;
    [SerializeField] public Canvas canvas;
    void Start()
    {
        worldCam = Camera.main;
        minigame = transform.Find("minigame").gameObject;
        minigameSpawnMan = minigame.GetComponentInChildren<JokiSpawnManager>();
        vati = minigame.GetComponentInChildren<VatiController>();
        player = GameObject.Find("Player");
    }

    public void StartMinigame()
    {
        player.SetActive(false);
        canvas.GetComponent<UIDisabler>().HideUI();
        worldCam.gameObject.SetActive(false);
        minigame.SetActive(true);

        vati.EmptyCarry(); // DEBUG DEBUG DEBUG
        Debug.Log("DEBUG: emptied vati");
    }

    public void EndMinigame()
    {
        minigameSpawnMan.EndCleanup();
        minigame.SetActive(false);
        worldCam.gameObject.SetActive(true);
        player.SetActive(true);
        canvas.GetComponent<UIDisabler>().ShowUI();
    }
}
