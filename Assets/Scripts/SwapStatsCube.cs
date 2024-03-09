using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapStatsCube : SwapStats
{
    public float timeBetweenJumps = 5f;
    
    public float gravity = 9.8f;

    public float jumpHeight = 2f;

    public List<FloatRef> InitializeList = new List<FloatRef>();

    private Rigidbody rb;

    private float currenttime = 0f;

    private FloatRef refTimebetweenJumps;
    private FloatRef refGravity;
    private FloatRef refJumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        
        refTimebetweenJumps = ScriptableObject.CreateInstance<FloatRef>();
        refTimebetweenJumps.Name = "TimeBetweenJumps";
        refTimebetweenJumps.Value = timeBetweenJumps;
        floatList.Add(refTimebetweenJumps);
        
        refGravity = ScriptableObject.CreateInstance<FloatRef>();
        refGravity.Name = "Gravity";
        refGravity.Value = gravity;
        floatList.Add(refGravity);
        
        refJumpHeight = ScriptableObject.CreateInstance<FloatRef>();
        refJumpHeight.Name = "JumpHeight";
        refJumpHeight.Value = jumpHeight;
        floatList.Add(refJumpHeight);
    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= Time.deltaTime;
        if (currenttime <= 0)
        {
            jump();
        }
    }
    
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, -1.0f, 0)*rb.mass*refGravity.Value);  
    }
    
    void jump()
    {
        rb.AddForce(new Vector3(0, 10f, 0)*rb.mass*refJumpHeight.Value);
        currenttime = refTimebetweenJumps.Value;
    }
}
