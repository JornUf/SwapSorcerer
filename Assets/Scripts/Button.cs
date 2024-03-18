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

    [SerializeField] private float neededweight = 5f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<SwapStatsCube>())
        {
            if (!isPressed && (other.gameObject.GetComponent<SwapStatsCube>().refGravity.Value >= neededweight))
            {
                isPressed = true;
                if (!vertical)
                {
                    transform.position = new Vector3(startPos.x, startPos.y - 1f, startPos.z);
                }

                down.Invoke();
            }
            else if(isPressed && (other.gameObject.GetComponent<SwapStatsCube>().refGravity.Value < neededweight))
            {
                isPressed = false;
                if (!vertical)
                {
                    transform.position = startPos;
                }

                up.Invoke();
            }
        }
    }
    

    private void OnCollsionExit(Collider other)
    {
        if (isPressed)
        {
            isPressed = false;
            if (!vertical)
            {
                transform.position = startPos;
            }

            up.Invoke();
        }
    }
}
