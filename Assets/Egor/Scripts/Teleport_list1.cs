using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport_list1 : MonoBehaviour
{
    public GameObject telep_choise;
    public string telep_type;
    public bool _IsEnable;
    GameObject Teleport, player, canvas;
    GameObject[] telep;
    float dist;
    public void Start()
    {
        _IsEnable = false;
        canvas = GameObject.Find("Canvas_Game");
        player = GameObject.FindGameObjectWithTag("Player");
        telep = GameObject.FindGameObjectsWithTag("Teleport");

    }

    void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (dist < 4 && Teleport == null && _IsEnable == true)
        {
            _IsEnable = false;
            Teleport = gameObject;
            telep_choise.SetActive(true);
            var C = canvas.GetComponent<Teleport_list>().telep_list;
            foreach (GameObject G in C)
            {
                if (G.GetComponentInChildren<Text>().text == Teleport.name) G.SetActive(false);
                if (G.GetComponentInChildren<Text>().text != Teleport.name) G.SetActive(true);
                for (int i = 0; i < telep.Length; i++)
                {
                    if (Teleport.GetComponent<Teleport_list1>().telep_type == "village")
                    {
                        if (G.GetComponentInChildren<Text>().text == telep[i].name && telep[i].GetComponent<Teleport_list1>().telep_type == "city")
                            G.SetActive(false);
                    }
                }
            }
        }
        else
        {
            if (Teleport != null)
            {
                Teleport = null;
            }
        }
        if (dist > 4)
        {
            _IsEnable = true;
        }
    }
}

