using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Teleport_list : MonoBehaviour
{
    GameObject player;
    public GameObject[] telep;
    public GameObject buttonPrefab;
    public GameObject TextPrefab;
    public Transform buttonContainer;
    public GameObject teleport_choice;
    public List<GameObject> telep_list = new List<GameObject>();
    public TextMeshProUGUI Text_count_scrolls;
    public GameObject Confirmation_telep;
    public GameObject Cancel_telep;
    string telep_name;

    public void Start()
    {
        telep = GameObject.FindGameObjectsWithTag("Teleport");
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < telep.Length; i++)
        {
            var go = Instantiate(buttonPrefab) as GameObject;
            var count_scrolls = Instantiate(TextPrefab) as GameObject;
            go.transform.SetParent(buttonContainer, false);
            count_scrolls.transform.SetParent(go.transform, false);
            var telep_name = telep[i].name;
            go.GetComponentInChildren<Text>().font = count_scrolls.GetComponent<Text>().font;
            go.GetComponentInChildren<Text>().text = telep_name;
            telep_list.Add(go);
            go.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(telep_name));
        }
    }
    public void OnButtonClick(string tel_name)
    {
        telep_name = tel_name;
        for (int i = 0; i < telep.Length; i++)
        {
            foreach (var key in teleport_choice.GetComponent<OnEnable1>().dist_to_telep)
            {
                if (tel_name == telep[i].name && tel_name == key.Key)
                {
                    if (Convert.ToInt32(Text_count_scrolls.text) - key.Value >= 0)
                    {
                        teleport_choice.gameObject.SetActive(false);
                        Confirmation_telep.SetActive(true);
                        if (key.Value == 1)
                            Confirmation_telep.transform.Find("Conf_text").gameObject.GetComponent<Text>().text = "Are you sure you want to move to this point and spend " + key.Value + " scroll?";
                        else Confirmation_telep.transform.Find("Conf_text").gameObject.GetComponent<Text>().text = "Are you sure you want to move to this point and spend " + key.Value + " scrolls?";     
                    }
                    else
                    {
                        teleport_choice.gameObject.SetActive(false);
                        Cancel_telep.SetActive(true);
                    }
                }
            }
        }
    }
    public void OnYesButtonClick()
    {
        Confirmation_telep.SetActive(false);
        for (int i = 0; i < telep.Length; i++)
        {
            foreach (var key in teleport_choice.GetComponent<OnEnable1>().dist_to_telep)
            {
                if (telep_name == telep[i].name && telep_name == key.Key)
                {
                    //Text_count_scrolls.text = (Convert.ToDouble(Text_count_scrolls.text) - key.Value).ToString();
                    GetComponent<VALUE>().Teleport_loss((int)(key.Value));

                    if (Convert.ToInt32(Text_count_scrolls.text) == 0) Text_count_scrolls.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = telep[i].transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    telep[i].GetComponent<Teleport_list1>()._IsEnable = false;
                    telep[i].GetComponent<Teleport_list1>().telep_choise.SetActive(false);
                }
            }
        }
    }
}
