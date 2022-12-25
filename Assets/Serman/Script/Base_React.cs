using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Base_React : MonoBehaviour
{

    public delegate void In_Message(string message);// делегат для события 
    public delegate void In_Message2(string message);// делегат для события 
    public delegate void In_Message3(string message);// делегат для события 
    public event In_Message Event_Message;// само событие
    public event In_Message Event_Message2;// само событие
    public event In_Message Event_Message3;// само событие

    //public GameObject For_Text;

    //[DllImport("__Internal")]
    //private static extern void GameOver(string userName, int score);

    [DllImport("__Internal")]
    private static extern void Info_Player(string Data_Json);// передаем в react

    [DllImport("__Internal")]
    private static extern void Attributes_Player(string Data_Json);// передаем в react

    [DllImport("__Internal")]
    private static extern void Inventory_Player(string Data_Json);// передаем в react

    void Start()
    {
        try
        {
            Info_Player("player?");
            Attributes_Player("attributes?");
            Inventory_Player("inventorys?");
        }
        catch { }
        Event_Message += Text_Message;// подписка на событие сообщение из react
        Event_Message2 += Text_Message_Attributes;// подписка на событие сообщение из react
        Event_Message3 += Text_Message_Inventorys;// подписка на событие сообщение из react
        //For_Text.GetComponent<Text>().text = "77777sssssssssssssssssssssssssssssssssss";
    }
    public void Inventory(string mess_out_reaact)
    {
        try
        {
            Inventory_Player(mess_out_reaact);
        }
        catch { }
    }
    public void Attributes(string mess_out_reaact)
    {
        try
        {
            Attributes_Player(mess_out_reaact);
        }
        catch { }
    }
    public void Go(string mess_out_reaact)
    {
        try
        {
            Info_Player(mess_out_reaact);
        }
        catch { }      
    }
    
    void Update()
    {
        
    }

    public void Text_Message(string mess)// принимаем сообщение из react
    {
        gameObject.GetComponent<Json_Player_info>().Load_json(mess);
    }
    public void Text_Message_Attributes(string mess)// принимаем сообщение из react
    {
        gameObject.GetComponent<Json_Attributes>().Load_json_Attributes(mess);
    }
    public void Text_Message_Inventorys(string mess)// принимаем сообщение из react
    {
        gameObject.GetComponent<Inventory_Backpack_json>().Load(mess);
    }
}
