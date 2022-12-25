using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activated_Camera_Control_Player : MonoBehaviour
{
    public GameObject Cameta_Hero;
    
    void Start()
    {
        Cameta_Hero = GameObject.Find("CM FreeLook2");
    }

    public void Swich_Cameta_Hero(bool On_Off)
    {
        Cameta_Hero.SetActive(On_Off);
    }
 
}
