using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent down = new UnityEvent();

    public UnityEvent up = new UnityEvent();

    private bool isPressed = false;

    private Vector3 startPos;

    [SerializeField] public bool vertical = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isPressed)
        {
            print("A");
            isPressed = true;
            if (!vertical)
            {
                transform.position = new Vector3(startPos.x, startPos.y - 0.1f, startPos.z);
            }

            down.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed)
        {
            print("B");
            isPressed = false;
            if (!vertical)
            {
                transform.position = startPos;
            }

            up.Invoke();
        }
    }
}
