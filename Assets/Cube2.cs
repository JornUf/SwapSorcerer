using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : SwapStats
{
    public float timeBetweenJumps = 5f;
    
    public float gravityX = 9.8f;
    public float gravityY = 9.8f;
    public float gravityZ = 9.8f;


    public float jumpHeight = 2f;

    public List<FloatRef> InitializeList = new List<FloatRef>();

    private Rigidbody rb;

    private float currenttime = 0f;

    private FloatRef refTimebetweenJumps;
    private FloatRef refGravityX;
    private FloatRef refGravityY;
    private FloatRef refGravityZ;
    private FloatRef refJumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        
        refTimebetweenJumps = ScriptableObject.CreateInstance<FloatRef>();
        refTimebetweenJumps.Name = "TimeBetweenJumps";
        refTimebetweenJumps.Value = timeBetweenJumps;
        floatList.Add(refTimebetweenJumps);
        
        refGravityX = ScriptableObject.CreateInstance<FloatRef>();
        refGravityX.Name = "Gravity X";
        refGravityX.Value = gravityX;
        floatList.Add(refGravityX);
        
        refGravityY = ScriptableObject.CreateInstance<FloatRef>();
        refGravityY.Name = "Gravity Y";
        refGravityY.Value = gravityY;
        floatList.Add(refGravityY);
        
        refGravityZ = ScriptableObject.CreateInstance<FloatRef>();
        refGravityZ.Name = "Gravity Z";
        refGravityZ.Value = gravityZ;
        floatList.Add(refGravityZ);
        
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
        rb.AddForce(new Vector3(refGravityX.Value, refGravityY.Value, refGravityZ.Value)*rb.mass);  
    }
    
    void jump()
    {
        rb.AddForce(new Vector3(0, 10f, 0)*rb.mass*refJumpHeight.Value);
        currenttime = refTimebetweenJumps.Value;
    }
}