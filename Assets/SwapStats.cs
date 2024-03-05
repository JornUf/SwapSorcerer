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

        public bool isSelected = false;

        public GameObject confirmbutton;


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
            isSelected = true;
            dropDown.gameObject.SetActive(true);
            confirmbutton.SetActive(true);
            //dropDown.onValueChanged.AddListener(valueChanged);

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
            isSelected = false;
            dropDown.ClearOptions();
            //dropDown.onValueChanged.RemoveAllListeners();
            dropDown.gameObject.SetActive(false);
            confirmbutton.SetActive(false);
        }

        public void ConfirmButton()
        {
            swapmanager.valueChosen(floatList[dropDown.value]);
        }

        [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Floatref", order = 1)]
        public class FloatRef : ScriptableObject
        {
            public float Value;
            public string Name;
        }
    }
