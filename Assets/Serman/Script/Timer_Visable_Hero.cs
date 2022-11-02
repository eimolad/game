using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Visable_Hero : MonoBehaviour
{
    public GameObject Hero;
    bool visable = false;
    float Time_Visable = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Time_Visable <= 0 && !visable)
        {
            visable = true;
            Hero.SetActive(true);
            //Debug.Log("Âðêìÿ");
        }
        Time_Visable -= Time.deltaTime;
    }
}
