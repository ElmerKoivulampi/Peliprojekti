using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class VatiController : MonoBehaviour
{
    [SerializeField] private int maxCarry = 4;
    private int currentCarryTotal = 0;
    private int currentCarryGold = 0;
    Camera cam;
    Vector2 lastTouchPosition = Vector2.zero;
    [SerializeField] Slider fillbar;
    JokiMinigame miniGamePointer;

    private void Awake()
    {
        cam = Camera.main;
        miniGamePointer = GameObject.Find("JokiMinigame").GetComponent<JokiMinigame>();
    }

    public void SetMaxCarry(int amt)
    {
        maxCarry = amt;
    }

    public int GetMaxCarry()
    {
        return maxCarry;
    }

    public int GetCurrentCarryTotalAmount()
    {
        return currentCarryTotal;
    }

    public int GetCurrentCarryGoldAmount()
    {
        return currentCarryGold;
    }

    public void EmptyCarry()
    {
        currentCarryGold = 0;
        currentCarryTotal = 0;
        UpdateFillBar();
    }

    void UpdateFillBar()
    {
        fillbar.value = (float)GetCurrentCarryTotalAmount() / (float)GetMaxCarry();
    }

    private void Update()
    {
        if(Mouse.current.wasUpdatedThisFrame)
        {
            lastTouchPosition = Mouse.current.position.ReadValue();
        }else{
            lastTouchPosition = Touchscreen.current.position.ReadValue();
        }

        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(lastTouchPosition.x, lastTouchPosition.y, cam.transform.position.y - transform.position.y));
        worldPos.y = transform.position.y;
        worldPos.x = transform.position.x; // todo: toggleable dir

        transform.position = worldPos;

        if(GetCurrentCarryTotalAmount() >= GetMaxCarry())
        {
            Debug.Log("Ending minigame");
            miniGamePointer.EndMinigame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Kultapala"))
        {
            currentCarryGold++;
        }

        currentCarryTotal++;
        UpdateFillBar();
        Destroy(other.gameObject);
    }
}
