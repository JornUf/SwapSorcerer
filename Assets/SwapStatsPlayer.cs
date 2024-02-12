using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapStatsPlayer : SwapStats
{
    public float StartSize = 5;

    public FloatRef WalkSpeed;
    public FloatRef RunSpeed;
    public FloatRef JumpSpeed;
    public FloatRef GravitySpeed;

    
    public float startWalkingSpeed = 7.5f;
    public float startRunningSpeed = 11.5f;
    public float startJumpSpeed = 8.0f;
    public float startGravity = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        WalkSpeed = new FloatRef("WalkSpeed", startWalkingSpeed);
        floatList.Add(WalkSpeed);
        RunSpeed = new FloatRef("RunSpeed", startRunningSpeed);
        floatList.Add(RunSpeed);
        JumpSpeed = new FloatRef("JumpSpeed", startJumpSpeed);
        floatList.Add(JumpSpeed);
        GravitySpeed = new FloatRef("FallSpeed", startGravity);
        floatList.Add(GravitySpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
