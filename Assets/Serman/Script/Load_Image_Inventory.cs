using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Image_Inventory : MonoBehaviour
{
    private GameObject Canvas_Game;
    VALUE Val;
    public int Count_equipment;
    public Sprite[] Image;

    void Start()
    {
        Canvas_Game = GameObject.Find("Canvas_Game");
        Val = Canvas_Game.GetComponent<VALUE>();
        Change_Image();
    }

    public void Change_Image()
    {
        var Eq = Convert.ToInt32(Val.equipment[Count_equipment]);
        gameObject.GetComponent<Image>().sprite = Image[Eq];
        
    }
    
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    Change_Image();
        //}
    }
}
