using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JokiSpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnZoneWidth = 0.0f;
    [SerializeField] private float objectLifeTimeInDistance = 512.0f;
    [SerializeField] private GameObject[] spawnObjects;
    private float lastSpawnTime = 0.0f;
    [SerializeField] private float spawnFreqMin = 0.2f;
    [SerializeField] private float spawnFreqMax = 1.0f;
    [SerializeField] private float floatSpeedMin = 0.3f;
    [SerializeField] private float floatSpeedMax = 0.45f;


    private void OnDrawGizmos()
    {
        Vector3 rightPos = transform.position + transform.right * spawnZoneWidth;
        Vector3 leftPos = transform.position - transform.right * spawnZoneWidth;

        Gizmos.color = new Color(1.0f, 0.5f, 0.5f);
        Gizmos.DrawLine(transform.position, rightPos);
        Gizmos.DrawLine(transform.position, leftPos);
        
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
        Gizmos.DrawLine(rightPos - transform.up * 2.0f, rightPos + transform.up * 2.0f); 
        Gizmos.DrawLine(leftPos - transform.up * 2.0f, leftPos + transform.up * 2.0f);

        DEBUG_DrawArrow(transform.position);
        DEBUG_DrawArrow(transform.position + transform.right * spawnZoneWidth * 0.5f);
        DEBUG_DrawArrow(transform.position - transform.right * spawnZoneWidth * 0.5f);
        DEBUG_DrawArrow(rightPos);
        DEBUG_DrawArrow(leftPos);
    }

    

    void DEBUG_DrawArrow(Vector3 pos)
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f);
        Vector3 forwardPos = pos + transform.forward * 2.0f;
        Gizmos.DrawLine(pos, forwardPos);
        Gizmos.DrawLine(forwardPos, forwardPos - transform.forward * 0.33f + transform.right * 0.33f);
        Gizmos.DrawLine(forwardPos, forwardPos - transform.forward * 0.33f - transform.right * 0.33f);
    }

    public void EndCleanup()
    {
        JokiObject[] objects = GetComponentsInChildren<JokiObject>();
        foreach(JokiObject jokiobj in objects)
        {
            GameObject.Destroy(jokiobj.gameObject);
        }
    }
    void Update()
    {
        HandleObjectSpawn();
    }

    void HandleObjectSpawn()
    {
        if(lastSpawnTime > Time.time)
        {
            return;
        }

        //No object pooling, GC will cry.
        Vector3 leftPos = transform.position - transform.right * spawnZoneWidth;
        GameObject obj = Instantiate(spawnObjects[UnityEngine.Random.Range(0, spawnObjects.Length - 1)],
            leftPos + transform.right * spawnZoneWidth * 2.0f * UnityEngine.Random.Range(0.0f, 1.0f),
            Quaternion.identity);

        if(obj == null)
        {
            Debug.LogError("Failed to create new object. Check your spawnlist!");
            return;
        }

        obj.transform.SetParent(transform);

        JokiObject jokiObj = obj.GetComponent<JokiObject>();
        if(jokiObj == null)
        {
            Debug.LogError("Failed to grab JokiObject pointer from freshly made object. Check your spawnlist!");
            return;
        }

        jokiObj.SetFloatSpeed(transform.forward * UnityEngine.Random.Range(floatSpeedMin, floatSpeedMax));
        jokiObj.SetLifetime(objectLifeTimeInDistance);
        lastSpawnTime = Time.time + UnityEngine.Random.Range(spawnFreqMin, spawnFreqMax);
    }
}
