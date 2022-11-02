using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_OBJ : MonoBehaviour
{
    public GameObject obj;
    VALUE val;

    private void OnTriggerEnter(Collider other)
    {
        if(!val.Quest_done)
        {
            obj.SetActive(true);
            obj.GetComponent<Dialog>().NPC = gameObject.name;
        }
        else
        {
            if(obj.GetComponent<Dialog>().NPC != null)
            {
                obj.GetComponent<Dialog>().Disconect_Obj();
                obj.SetActive(false);
                obj.GetComponent<Dialog>().NPC = "";
            }           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!val.Quest_done)
        {
            obj.GetComponent<Dialog>().Disconect_Obj();
            obj.SetActive(false);
            obj.GetComponent<Dialog>().NPC = "";
        }
        else
        {
            if (obj.GetComponent<Dialog>().NPC != null)
            {
                obj.GetComponent<Dialog>().Disconect_Obj();
                obj.SetActive(false);
                obj.GetComponent<Dialog>().NPC = "";
            }
        }

    }    
    void Start()
    {
        val = new VALUE();
    }


    void Update()
    {

    }
}
