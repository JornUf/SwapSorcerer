using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cheesejumplvl1 : MonoBehaviour
{
    [SerializeField] private UnityEvent cheesedlvl1;

    private bool done = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!done)
            if (other.gameObject.tag == "Player")
            {
                cheesedlvl1.Invoke();
                done = true;
            }
    }
}
