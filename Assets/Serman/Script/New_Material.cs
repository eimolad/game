using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class New_Material : MonoBehaviour
{
   
    //public Material new_mat;
     
    void Start()
    {
        GameObject.Find("Canvas_Game").GetComponent<Material_SET>().Set_obj(gameObject);
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
