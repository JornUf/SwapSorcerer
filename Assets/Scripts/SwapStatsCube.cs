using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapStatsCube : SwapStats
{
    public float gravity = 1f;

    public List<FloatRef> InitializeList = new List<FloatRef>();

    private Rigidbody rb;
    
    public FloatRef refGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();

        refGravity = ScriptableObject.CreateInstance<FloatRef>();
        refGravity.Name = "Weight";
        refGravity.Value = gravity;
        floatList.Add(refGravity);

    }

    // Update is called once per frame

    
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -1.0f, 0)*rb.mass*refGravity.Value);  
    }
    

}
