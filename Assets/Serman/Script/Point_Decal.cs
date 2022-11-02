using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Decal : MonoBehaviour
{
    float Time_Pulse_On;
    float Time_Pulse_Off;
    float Delta = 0.5f;
    bool Pulse_On = true;
    bool Pulse_Off = false;
    Vector3 Newscale_on;
    Vector3 Newscale_off;
    BoxCollider boxCollider;
    void Start()
    {
        //boxCollider = GetComponent<BoxCollider>();
        Time_Pulse_On = Delta;
        Time_Pulse_Off = Delta;
        Newscale_on = new Vector3(0.3f, 0.5f, 0.3f);
        Newscale_off = new Vector3(0.8f, 0.5f, 0.8f);
    }

    
    void Update()
    {
      
        if(Pulse_On == true)
        {
            Time_Pulse_On -= Time.deltaTime;
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Newscale_on, Time.deltaTime*5);
        }
        if (Pulse_Off == true)
        {
            Time_Pulse_Off -= Time.deltaTime;
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Newscale_off, Time.deltaTime*5);
        }

        //Time_Pulse_Off -= Time.deltaTime;
        if (Time_Pulse_On <= 0)
        {
            Pulse_On = false;
            Pulse_Off = true;
            Time_Pulse_On = Delta;
            //gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Newscale_on, Time.deltaTime);
        }
        if (Time_Pulse_Off <= 0)
        {
            Pulse_On = true;
            Pulse_Off = false;
            Time_Pulse_Off = Delta;
            //gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Newscale_off, Time.deltaTime);
        }
    }
}
