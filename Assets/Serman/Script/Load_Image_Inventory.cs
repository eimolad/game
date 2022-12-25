using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Load_Image_Inventory : MonoBehaviour
{
    public GameObject Canvas_Game;
    VALUE Val;
    public int Count_equipment;
    public Sprite[] Image;

    void Start()
    {        
        //Canvas_Game = GameObject.Find("Canvas_Game");
        Val = Canvas_Game.GetComponent<VALUE>();
        StartCoroutine(Change_Image());
    }

    public IEnumerator Change_Image()
    {

        var Eq = Convert.ToInt32(Val.equipment[Count_equipment]);
        gameObject.GetComponent<Image>().sprite = Image[Eq];
        //Debug.Log("загрузка картинки амуниции " + Image[Eq]);
        yield return null;
    }
    
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    Change_Image();
        //}
    }
}
