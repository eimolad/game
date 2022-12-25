using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Base_React : MonoBehaviour
{

    public delegate void In_Message(string message);// ������� ��� ������� 
    public delegate void In_Message2(string message);// ������� ��� ������� 
    public delegate void In_Message3(string message);// ������� ��� ������� 
    public event In_Message Event_Message;// ���� �������
    public event In_Message Event_Message2;// ���� �������
    public event In_Message Event_Message3;// ���� �������

    //public GameObject For_Text;

    //[DllImport("__Internal")]
    //private static extern void GameOver(string userName, int score);

    [DllImport("__Internal")]
    private static extern void Info_Player(string Data_Json);// �������� � react

    [DllImport("__Internal")]
    private static extern void Attributes_Player(string Data_Json);// �������� � react

    [DllImport("__Internal")]
    private static extern void Inventory_Player(string Data_Json);// �������� � react

    void Start()
    {
        try
        {
            Info_Player("player?");
            Attributes_Player("attributes?");
            Inventory_Player("inventorys?");
        }
        catch { }
        Event_Message += Text_Message;// �������� �� ������� ��������� �� react
        Event_Message2 += Text_Message_Attributes;// �������� �� ������� ��������� �� react
        Event_Message3 += Text_Message_Inventorys;// �������� �� ������� ��������� �� react
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

    public void Text_Message(string mess)// ��������� ��������� �� react
    {
        gameObject.GetComponent<Json_Player_info>().Load_json(mess);
    }
    public void Text_Message_Attributes(string mess)// ��������� ��������� �� react
    {
        gameObject.GetComponent<Json_Attributes>().Load_json_Attributes(mess);
    }
    public void Text_Message_Inventorys(string mess)// ��������� ��������� �� react
    {
        gameObject.GetComponent<Inventory_Backpack_json>().Load(mess);
    }
}
