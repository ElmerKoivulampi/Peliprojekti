using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;
using TMPro;

public class VatiController : MonoBehaviour
{
    [SerializeField] private int maxCarry = 4;
    private int currentCarryTotal = 0;
    private int currentCarryGold = 0;
    Camera cam;
    Vector2 lastTouchPosition = Vector2.zero;
    [SerializeField] Slider fillbar;
    JokiMinigame miniGamePointer;
    public GoldUIText textPointer;
    public TextMeshProUGUI stateText;
    bool dead = false;
    public LocalizedString localizedString;
    private void Awake()
    {
        cam = Camera.main;
        miniGamePointer = GameObject.Find("JokiMinigame").GetComponent<JokiMinigame>();
        stateText.text = "";
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
        if(dead) { return; }
        //if(Mouse.current.wasUpdatedThisFrame)
        ///{
        //    lastTouchPosition = Mouse.current.position.ReadValue();
        //}else{
            lastTouchPosition = Touchscreen.current.position.ReadValue();
        //}

        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(lastTouchPosition.x, lastTouchPosition.y, cam.transform.position.y - transform.position.y));
        worldPos.y = transform.position.y;
        worldPos.x = transform.position.x; // todo: toggleable dir

        transform.position = worldPos;

        /*if(GetCurrentCarryTotalAmount() >= GetMaxCarry())
        {
            Debug.Log("Ending minigame");
            miniGamePointer.EndMinigame();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(dead) { return; }
        if(other.gameObject.CompareTag("Kultapala"))
        {
            currentCarryGold++;
            textPointer.gold = currentCarryGold;
            Destroy(other.gameObject);
            return;
        }

        textPointer.gold = currentCarryGold;
        currentCarryTotal++;
        UpdateFillBar();
        Destroy(other.gameObject);
        stateText.text = string.Format("{0} {1}", localizedString, currentCarryGold);
        dead = true;
        Invoke("kicktomenu", 5.0f);
    }

    void kicktomenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
