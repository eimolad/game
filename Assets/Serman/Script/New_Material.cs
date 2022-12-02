using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class New_Material : MonoBehaviour
{

    public List<string> new_mat = new List<string>();

    void Start()
    {
        GameObject.Find("Address_load").GetComponent<Material_SET>().Set_obj(gameObject, new_mat);
        //Debug.Log("меня зовут " + gameObject.name);
        //gameObject.GetComponent<MeshRenderer>().sharedMaterial = new_mat;
        //for (int i = 0; i < 1; i++)
        //{

        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Thread.Sleep(5000);
        
    }
}
