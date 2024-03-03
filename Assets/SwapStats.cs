using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

public class SwapStats : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    
    public bool SwapPos = false;

    public bool SwapStat = false;

    public Swapmanager swapmanager;
    
    internal List<FloatRef> floatList = new List<FloatRef>();
    

    // Start is called before the first frame update
    void Start()
    {
        dropDown = FindObjectOfType<TMP_Dropdown>();
        swapmanager = FindObjectOfType<Swapmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotSelected()
    {
        dropDown.gameObject.SetActive(true);
        dropDown.onValueChanged.AddListener(valueChanged);
        
        List<TMP_Dropdown.OptionData> optionslist = new List<TMP_Dropdown.OptionData>();

        foreach (FloatRef option in floatList)
        {
            TMP_Dropdown.OptionData optdata = new TMP_Dropdown.OptionData(option.Name + ": " + option.Value);
            optionslist.Add(optdata);
        }

        dropDown.options = optionslist;
    }

    public void unselected()
    {
        dropDown.ClearOptions();
        dropDown.onValueChanged.RemoveAllListeners();
        dropDown.gameObject.SetActive(false);
    }

    public void valueChanged(int index)
    {
        swapmanager.valueChosen(floatList[index]);
    }

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Floatref", order = 1)]
    public class FloatRef : ScriptableObject
    {
        public float Value;
        public string Name;
    }
}
