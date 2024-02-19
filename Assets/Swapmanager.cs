using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Swapmanager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private SwapStats[] allSwapables;
    // Start is called before the first frame update
    void Start()
    {
        allSwapables = FindObjectsOfType<SwapStats>();
        foreach (var swaps in allSwapables)
        {
            print(swaps.floatList[0].Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
