using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCheese : SwapStats
{
    [HideInInspector] 
    public FloatRef ScaleRef;
    
    // Start is called before the first frame update
    void Start()
    {
        ScaleRef = ScriptableObject.CreateInstance<FloatRef>();
        ScaleRef.Name = "Size";
        ScaleRef.Value = transform.localScale.x;
        floatList.Add(ScaleRef);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(ScaleRef.Value, ScaleRef.Value, ScaleRef.Value);
    }
}
