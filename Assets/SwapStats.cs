using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapStats : MonoBehaviour
{
    public bool SwapPos = false;

    public bool SwapStat = false;
    
    internal List<FloatRef> floatList = new List<FloatRef>();
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public class FloatRef
    {
        public float Value { get; set; }
        public string Name { get; set; }

        public FloatRef(string name, float value)
        {
            Value = value;
            Name = name;    
        }
        
    }
}
