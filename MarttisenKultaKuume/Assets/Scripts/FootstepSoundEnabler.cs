using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundEnabler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody rBody;
    void Update()
    {
        if (rBody.velocity.magnitude > 0.1)
        {
            audioSource.enabled = true;
        } else
        {
            audioSource.enabled = false;
        }
    }
}
