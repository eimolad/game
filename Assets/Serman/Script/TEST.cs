using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TEST : MonoBehaviour
{
    //public Transform player;
    //public List<GameObject> gameObj;
    public GameObject gameObj;

    //  Animator animator;

    void Start()
    {
        var chld = gameObj.GetComponentsInChildren<MeshRenderer>();
        //Debug.Log(chld[0].name);
        //Debug.Log(chld[0].material.name);
        for (int i = 0; i < chld.Length; i++)
        {
            //chld[i].sharedMaterials[0] = null;
            var mat = chld[i].sharedMaterials;
            for(int j = 0; j < mat.Length; j++)
            {
                Debug.Log(mat[j].name);
                mat[j] = null;
                //Debug.Log(mat[j].name);
            }
            chld[i].sharedMaterials = mat;
            //chld[i].AddComponent<New_Material>();
        }
        //gameObject.GetComponent<MeshRenderer>().sharedMaterial = null;
        //var obj = GameObject.FindGameObjectsWithTag("test");

        //for(int i = 0; i < obj.Length; i++)
        //{
        //    gameObj.Add(obj[i]);
        //    obj[i].SetActive(false);
        //}
    }

    //IEnumerator Distancion_obj()
    //{
    //    for(int i = 0; i < gameObj.Count; i++)
    //    {
    //        var dist = Vector3.Distance(player.transform.position, gameObj[i].transform.position);
    //        Debug.Log(gameObj[i].name + "  " + dist);
    //        if(dist < 15)
    //        {
    //            gameObj[i].SetActive(true);
    //        }
    //        else
    //        {
    //            gameObj[i].SetActive(false);
    //        }
    //    }

    //    yield return null;
    //}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //StartCoroutine(Distancion_obj());
        }

        //if(Input.GetKeyUp(KeyCode.Keypad1)) animator.SetFloat("Danser", 0);
        //if (Input.GetKeyUp(KeyCode.Keypad2)) animator.SetFloat("Danser", 0.5f);
        //if (Input.GetKeyUp(KeyCode.Keypad3)) animator.SetFloat("Danser", 1);
    }
}
