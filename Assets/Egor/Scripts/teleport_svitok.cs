using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class teleport_svitok : MonoBehaviour
{
    GameObject[] telep;
    GameObject player;
    float min;
    public TextMeshProUGUI Text_count_scrolls;
    public GameObject Confirmation_telep, Cancel_telep, backpack;
    float dist;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        telep = GameObject.FindGameObjectsWithTag("Teleport");
    }
    public void From_point()
    {
        for (int i = 0; i < telep.Length; i++)
        {
            dist = Vector3.Distance(telep[i].transform.position, player.transform.position);
            if (i == 0)
            {
                min = dist;
            }
            if (min > dist)
            {
                min = dist;
            }
        }
        for (int i = 0; i < telep.Length; i++)
        {
            if (min == Vector3.Distance(telep[i].transform.position, player.transform.position))
            {
                GetComponent<Teleport_list>().telep_name = telep[i].name;
            }
        }
        if (gameObject.GetComponent<VALUE>().Teleport - 1 >= 0)
        {
            Confirmation_telep.SetActive(true);
            Confirmation_telep.transform.Find("Conf_text").gameObject.GetComponent<Text>().text = "You're going to teleport. Are you sure?";
        }
       
        backpack.GetComponent<OnEnable1>().dist_to_telep[GetComponent<Teleport_list>().telep_name] = 1;

    }
    public void Conf_from_point()
    {

    }
}