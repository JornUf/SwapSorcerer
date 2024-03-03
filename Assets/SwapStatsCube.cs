using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapStatsCube : SwapStats
{
    public float StartSize = 5;

    public List<FloatRef> InitializeList = new List<FloatRef>();

    // Start is called before the first frame update
    void Start()
    {
        //SizeRef = new FloatRef("Size", StartSize);
        //floatList.Add(SizeRef);
        floatList = InitializeList;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
