using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Swapmanager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private SwapStats[] allSwapables;

    [SerializeField]
    private PlayerController _playerController;

    [SerializeField] private TextMeshProUGUI currentselection;

    private SwapStats.FloatRef nr1;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        allSwapables = FindObjectsOfType<SwapStats>();
        foreach (var swaps in allSwapables)
        {
            swaps.swapmanager = this;
        }
    }

    public void valueChosen(SwapStats.FloatRef floatref)
    {
        if (nr1 == null)
        {
            nr1 = floatref;
            currentselection.gameObject.SetActive(true);
            currentselection.text = "Currently selected (press 'R' to reset): " + nr1.Name + ": " + nr1.Value;
        }
        else
        {
            float tempvalue = floatref.Value;
            floatref.Value = nr1.Value;
            nr1.Value = tempvalue;
            nr1 = null;
            currentselection.gameObject.SetActive(false);
            _playerController.backtogame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            nr1 = null;
            currentselection.gameObject.SetActive(false);
        }
    }
}
