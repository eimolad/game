using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Distance : MonoBehaviour
{
    GameObject Player_Hero;
    void Start()
    {
        Player_Hero = GameObject.Find("Hero Variant");
    }

    
    void Update()
    {
        var dist = Vector3.Distance(transform.position, Player_Hero.transform.position); // дистанция до героя
        Debug.Log(dist);
    }
}
