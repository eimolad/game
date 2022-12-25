using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class Add_Dinamic_Button_inventory : MonoBehaviour
{
    GameObject Canvas_Game;
    public List<GameObject> Slot;
    public GameObject PrifabButtonWeapon;
    public GameObject PrifabButtonShild;
    public GameObject PrifabButtonRecept;
    public GameObject PrifabButtonSkin;
    public GameObject PrifabButtonTP;
    public GameObject Active_bodey_slot;
    public Sprite[] Image_Weapon;
    public Sprite[] Image_Shild;
    public Sprite[] Image_Inventory;
    VALUE Val;
    int Count_Slot_busy;
    private GameObject Result_Obj;

    void Start()
    {
        Canvas_Game = GameObject.Find("Canvas_Game");
        Val = Canvas_Game.GetComponent<VALUE>();
        Add_weapon_btn();
        Add_Shild_btn();
        Add_Inventory();
        //await Task.Run(() => {  });     
        //await Task.Run(() => { });
        //await Task.Run(() => {  });       
    }
    void Add_Inventory()
    {
        for (int i = 0; i < Val.All_inventory.Count; i++)
        {
            if (Val.All_inventory[i] == "Recipe")
            {
                var obl = Instantiate(PrifabButtonRecept);
                obl.transform.SetParent(Slot[Count_Slot_busy].transform, false);
                //Slot[Count_Slot_busy].GetComponent<UISlot>().empty = false;
                //var child = obl.transform.GetChild(0).gameObject;
            }
            Count_Slot_busy += 1;
        }

    }
    void Add_Shild_btn()
    {
        for (int i = 0; i < Val.Shild_inventory.Count; i++)
        {
            //Debug.Log(Count_Slot_busy);
            var obl = Instantiate(PrifabButtonShild);
            obl.transform.SetParent(Slot[Count_Slot_busy].transform, false);
            //Slot[Count_Slot_busy].GetComponent<UISlot>().empty = false;
            var child = obl.transform.GetChild(0).gameObject;
            if (Val.Shild_inventory[i] == "Grenlyn’s Shield")
            {
                child.GetComponent<Image>().sprite = Image_Shild[i];
            }
            Count_Slot_busy += 1;
        }
    }
    void Add_weapon_btn()
    {
        for (int i = 0; i < Val.Weapon_inventory.Count; i++)
        {
            if (Val.Weapon_List_Count_num != i.ToString())
            {
                var obl = Instantiate(PrifabButtonWeapon);
                obl.transform.SetParent(Slot[Count_Slot_busy].transform, false);
                //Slot[Count_Slot_busy].GetComponent<UISlot>().empty = false;
                var child = obl.transform.GetChild(0).gameObject;
                for (int j = 0; j < Image_Weapon.Length; j++)
                {
                    if (Image_Weapon[j].name == Val.Weapon_inventory[i])
                    {
                        child.GetComponent<Image>().sprite = Image_Weapon[j];
                    }
                }
                Count_Slot_busy += 1;
            }
            else
            {
                var obl2 = Instantiate(PrifabButtonWeapon);
                obl2.transform.SetParent(Active_bodey_slot.transform, false);
                //Active_bodey_slot.GetComponent<UISlot>().empty = false;
                var child = obl2.transform.GetChild(0).gameObject;
                for (int j = 0; j < Image_Weapon.Length; j++)
                {
                    if (Image_Weapon[j].name == Val.Weapon_inventory[i])
                    {
                        child.GetComponent<Image>().sprite = Image_Weapon[j];// добавляем картинку к слоту тела
                        Active_bodey_slot.GetComponent<UISlot>().text.SetActive(false);// убираем текст
                        Active_bodey_slot.GetComponent<UISlot>().drop_obj_in_slot(Image_Weapon[j].name);
                        //drop_obj_in_slot(Image_Weapon[j].name);
                    }
                }
            }
        }
    }
    public void drop_obj_in_slot(string name_obj_slot)
    {
        //Debug.Log("в слоте объект " + name_obj_slot);

        Addressables.InstantiateAsync(name_obj_slot).Completed += Load_Bundle;
    }
    void Load_Bundle(AsyncOperationHandle<GameObject> obj)
    {
        Result_Obj = obj.Result;
        //Active_bodey_slot.GetComponent<UISlot>().Result_Obj = Result_Obj;
    }
    void Update()
    {

    }
}
