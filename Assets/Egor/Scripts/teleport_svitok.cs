using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class teleport_svitok : MonoBehaviour
{
    GameObject[] telep;
    GameObject player;
    float min;
    public TextMeshProUGUI Text_count_scrolls;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        telep = GameObject.FindGameObjectsWithTag("Teleport");
    }
    public void HHHH()
    {
        for (int i = 0; i < telep.Length; i++)
        {
            var dist = Vector3.Distance(telep[i].transform.position, player.transform.position);
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
                Text_count_scrolls.text = (Convert.ToDouble(Text_count_scrolls.text) - 1).ToString();
                if (Convert.ToInt32(Text_count_scrolls.text) == 0) { Text_count_scrolls.transform.parent.gameObject.transform.parent.gameObject.SetActive(false); }
                player.GetComponent<NavMeshAgent>().enabled = false;
                player.transform.position = telep[i].transform.position;
                player.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
    }
}
