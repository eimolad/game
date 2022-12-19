using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Active_OBJ : MonoBehaviour
{
    public GameObject[] Grid_Inventory;
    public GameObject[] Grid_Weapon_bar;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Grid_Inventory_OFF()
    {
        for(int i = 0; i < Grid_Inventory.Length; i++)
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
