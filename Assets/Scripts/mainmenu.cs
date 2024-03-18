using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void loadlvl1()
    {
        SceneManager.LoadScene("level0");
    }
    
    public void loadlvl2()
    {
        SceneManager.LoadScene("level1.1");
    }
    
    public void loadlvl3()
    {
        SceneManager.LoadScene("level1.2");
    }

    public void loadlvl4()
    {
        SceneManager.LoadScene("level1.3");
    }
}
