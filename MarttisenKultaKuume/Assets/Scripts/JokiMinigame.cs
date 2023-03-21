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
    GameObject ui;
    void Start()
    {
        worldCam = Camera.main;
        minigame = transform.Find("minigame").gameObject;
        minigameSpawnMan = minigame.GetComponentInChildren<JokiSpawnManager>();
        vati = minigame.GetComponentInChildren<VatiController>();
        player = GameObject.Find("Player");
        ui = GameObject.Find("UI");
    }

    public void StartMinigame()
    {
        player.SetActive(false);
        ui.SetActive(false);
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
        ui.SetActive(true);
    }
}
