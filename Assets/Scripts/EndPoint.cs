using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent finished = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cheese")
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            finished.Invoke();
        }
    }
}
