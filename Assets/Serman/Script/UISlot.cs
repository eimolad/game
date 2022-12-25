using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IDropHandler
{
    public bool drop = false;
    public string Slot_for_name;
    public GameObject text;
    public bool Right_Hand;
    public bool Left_Hand;
    public GameObject Result_Obj;
    public bool empty = true;
    private GameObject Canvas_Game;
    VALUE VAL;
    string Left_Hànd_name;
    string Right_Hànd_name;
    bool stop_update = false;
    bool load = true;

    private void Start()
    {
        //Canvas_Game = GameObject.Find("Canvas_Game");
        //VAL = Canvas_Game.GetComponent<VALUE>();
        //drop_obj_in_slot("Grenlyn’s Shield");
        //text = new GameObject();
        //text.SetActive(false);
    }

    public void drop_obj_in_slot(string name_obj_slot)
    {
        //Debug.Log("â ñëîòå îáúåêò " + name_obj_slot);       
        Addressables.InstantiateAsync(name_obj_slot).Completed += Load_Bundle;
    }
    void Load_Bundle(AsyncOperationHandle<GameObject> obj)
    {
        Result_Obj = obj.Result;
    }
    public void OnDrop(PointerEventData eventData)
    {
       
        if (empty)
        {
            if (eventData.selectedObject.name == Slot_for_name || eventData.selectedObject.name == Slot_for_name + "(Clone)") drop = true;
            if (gameObject.name.Substring(0, 7) == "Ui_Slot") drop = true;

            if (drop)
            {
                var otherItemTransform = eventData.pointerDrag.transform;
                otherItemTransform.SetParent(transform);
                otherItemTransform.localPosition = Vector3.zero;
                drop = false;
                stop_update = true;
                if(gameObject.name.Substring(0, 7) != "Ui_Slot") drop_obj_in_slot(otherItemTransform.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().mainTexture.name);
            }
        }
    }
    void Update()
    {
        //Debug.Log(gameObject.transform.GetChild(1).name);

        try
        {
            if (gameObject.transform.childCount > 1)
            {
                empty = false;
                text.SetActive(false);

            }
            else
            {
                empty = true;
                if (Result_Obj != null) Destroy(Result_Obj);
            }

            if (gameObject.transform.childCount > 1 && stop_update)
            {
                if (text != null)
                {
                    text.SetActive(false);

                    if (Left_Hand && Result_Obj != null) Left_Hànd_name = Result_Obj.name;
                    if (Right_Hand && Result_Obj != null) Right_Hànd_name = Result_Obj.name;
                }
            }
            else
            {
                if (text != null)
                {
                    text.SetActive(true);

                    if (Left_Hand)
                    {
                        var obj = GameObject.Find(Left_Hànd_name);
                        if (obj != null) Destroy(obj);
                    }
                    if (Right_Hand)
                    {
                        var obj = GameObject.Find(Right_Hànd_name);
                        if (obj != null) Destroy(obj);
                    }
                }
            }
        }
        catch { }

       
    }
}
