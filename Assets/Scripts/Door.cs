using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    
    public void OpenDoor()
    {
        print("C");
        door.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
    }

    public void closeDoor()
    {
        print("D");
        door.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

    }
}
