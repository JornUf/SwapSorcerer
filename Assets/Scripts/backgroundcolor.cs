using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundcolor : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float shiftSpeed = 0.2f;
    private float red = 1.0f;
    private float green = 0.0f;
    private float blue = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = new Color(red, green, blue, 1.0f);
 
        //The idea here is to change the value of the floats every frame and check for 1.0 values then change the value being affected accordingly.
        if (red >= 1.0f)
        {
            if (blue > 0.0f)
            {
                blue = blue - shiftSpeed * Time.deltaTime;
            }
            if (blue <= 0.0f)
            {
                green = green + shiftSpeed * Time.deltaTime;
            }
        }
 
        if (green >= 1.0f)
        {
            if (red > 0.0f)
            {
                red = red - shiftSpeed * Time.deltaTime;
            }
            if (red <= 0.0f)
            {
                blue = blue + shiftSpeed * Time.deltaTime;
            }
        }
 
        if (blue >= 1.0f)
        {
            if (green > 0.0f)
            {
                green = green - shiftSpeed * Time.deltaTime;
            }
            if (green <= 0.0f)
            {
                red = red + shiftSpeed * Time.deltaTime;
            }
        }

        _camera.backgroundColor = newColor;
    }
}
