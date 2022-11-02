using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich_Camera : MonoBehaviour
{
    public GameObject Camera_Start;
    public GameObject Camera_Hero;
    public bool Do_Once = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Do_Once)
        {
            //Debug.Log("!!!");
            Camera_Hero.SetActive(true);
            Camera_Start.SetActive(false);
            Do_Once = false;
        }
    }
}
