using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VatiController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Roska"))
        {
            Debug.Log("Roska'd!");
        }
        else if(other.gameObject.CompareTag("Kultapala"))
        {
            Debug.Log("Kulta'd!");
        }

        Destroy(other.gameObject);
    }
}
