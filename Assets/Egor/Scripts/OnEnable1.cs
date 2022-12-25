using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnEnable1 : MonoBehaviour
{
    GameObject player, canvas;
    GameObject[] telep;
    public Dictionary<string, double> dist_to_telep = new Dictionary<string, double>();
    float dist1;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        telep = GameObject.FindGameObjectsWithTag("Teleport");
        canvas = GameObject.Find("Canvas_Game");
    }
    public void OnEnable()
    {
        for (int i = 0; i < telep.Length; i++)
        {
            dist1 = Vector3.Distance(telep[i].transform.position, player.transform.position);
            dist_to_telep[telep[i].name] = 1;//Math.Ceiling(dist1 / 100)

            foreach (var key in dist_to_telep)
            {
                var C = canvas.GetComponent<Teleport_list>().telep_list;
                foreach (GameObject G in C)
                {
                    if (G.GetComponentInChildren<Text>().text == telep[i].name && key.Key == telep[i].name)
                        G.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = key.Value.ToString() + " x";
                }
            }
        }
    }
}
