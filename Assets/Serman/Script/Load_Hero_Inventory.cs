using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Load_Hero_Inventory : MonoBehaviour
{
    //private GameObject Canvas_Game;
    private GameObject Result_Obj;
    VALUE VAL;
    List<string> equipment;
    string[] bronya = new string[7] {"1.0", "2.0", "3.0", "4.0", "5.0", "6.0", "1.0"};
    string[] hair = new string[5] { "h0", "h1", "h2", "h3", "h4" };
    string[] shram = new string[6] { "sh0", "sh1", "sh2", "sh3", "sh4", "sh5" };
    string[] perchatki = new string[7] { "1.3", "2.3", "3.3", "4.3", "5.3", "6.3", "1.3" };
    string[] botinki = new string[7] { "1.4", "2.4", "3.4", "4.4", "5.4", "6.4", "1.4" };
    void Start()
    {
        //Canvas_Game = GameObject.Find("Canvas_Game");
        VAL = gameObject.GetComponent<VALUE>();
        equipment = VAL.equipment;
        Addressables.InstantiateAsync(bronya[Convert.ToInt32(equipment[0])]).Completed += Load_Bundle;
        Addressables.InstantiateAsync(hair[Convert.ToInt32(equipment[1])]).Completed += Load_Bundle;
        Addressables.InstantiateAsync(shram[Convert.ToInt32(equipment[2])]).Completed += Load_Bundle;
        Addressables.InstantiateAsync(perchatki[Convert.ToInt32(equipment[3])]).Completed += Load_Bundle;
        Addressables.InstantiateAsync(botinki[Convert.ToInt32(equipment[4])]).Completed += Load_Bundle;
    }
    void Load_Bundle(AsyncOperationHandle<GameObject> obj)
    {
        Result_Obj = obj.Result;        
    }

    void Update()
    {
        
    }
}
