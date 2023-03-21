using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokiTriggerZone : MonoBehaviour, IUsableObject
{
    JokiMinigame miniGamePointer;
    // Start is called before the first frame update
    void Start()
    {
        miniGamePointer = GameObject.Find("JokiMinigame").GetComponent<JokiMinigame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        Debug.Log("Minigame started!");
        miniGamePointer.StartMinigame();
    }
}
