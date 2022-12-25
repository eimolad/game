using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Active_OBJ : MonoBehaviour
{
    public GameObject[] Grid_Inventory;
    public GameObject[] Grid_Weapon_bar;
    public List<string> Search_obj_name_for_ON;
    public List<string> Search_obj_name_for_OFF;
    GameObject Canvas_Game;
    public List<GameObject> OBJ_OFF;
    public List<GameObject> OBJ_ON;
    void Start()
    {
        Canvas_Game = GameObject.Find("Canvas_Game");
        for (int i = 0; i < Search_obj_name_for_ON.Count; i++)
        {
            if (Search_obj_name_for_ON[i] != "")
            {
                OBJ_ON.Add(Canvas_Game.GetComponent<FindObjects_OFF_Action>().Seatch_not_action_obj(Search_obj_name_for_ON[i]));// ищем объект, даже если он не активен
            }
        }
        for (int i = 0; i < Search_obj_name_for_OFF.Count; i++)
        {
            if (Search_obj_name_for_OFF[i] != "")
            {
                OBJ_OFF.Add(Canvas_Game.GetComponent<FindObjects_OFF_Action>().Seatch_not_action_obj(Search_obj_name_for_OFF[i]));// ищем объект, даже если он не активен
            }
        }
    }


    void Update()
    {

    }
    public void Swich_ON_obj()
    {
        for (int i = 0; i < OBJ_ON.Count; i++) OBJ_ON[i].SetActive(true);

    }
    public void Swich_OFF_obj()
    {
        for (int i = 0; i < OBJ_OFF.Count; i++) OBJ_OFF[i].SetActive(false);
    }
    public void Grid_Inventory_OFF()
    {
        for (int i = 0; i < Grid_Inventory.Length; i++)
        {
            Grid_Inventory[i].SetActive(false);
        }
    }
    public void Grid_Inventory_ON()
    {
        for (int i = 0; i < Grid_Inventory.Length; i++)
        {
            Grid_Inventory[i].SetActive(true);
        }
    }
    public void Grid_Weapon_bar_OFF()
    {
        for (int i = 0; i < Grid_Weapon_bar.Length; i++)
        {
            Grid_Weapon_bar[i].SetActive(false);
        }
    }
    public void Grid_Weapon_bar_ON()
    {
        for (int i = 0; i < Grid_Weapon_bar.Length; i++)
        {
            Grid_Weapon_bar[i].SetActive(true);
        }
    }
}
