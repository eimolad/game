using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Teleport_list : MonoBehaviour
{
    GameObject player;
    public GameObject[] telep;
    public GameObject buttonPrefab, TextPrefab, teleport_choice, Confirmation_telep, Cancel_telep;
    public Transform buttonContainer;
    public List<GameObject> telep_list = new List<GameObject>();
    public TextMeshProUGUI Text_count_scrolls;
    public GameObject backpack;
    public string telep_name;
    public Color wantedcolor;
    public Color wantedcolor1;
    bool On_Btn_click = false;

    public void Start()
    {
        telep = GameObject.FindGameObjectsWithTag("Teleport");
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < telep.Length; i++)
        {
            var go = Instantiate(buttonPrefab) as GameObject;
            var count_scrolls = Instantiate(TextPrefab) as GameObject;
            go.transform.SetParent(buttonContainer, false);
            count_scrolls.transform.SetParent(go.transform.GetChild(1).transform, false);
            count_scrolls.transform.position = new Vector3(go.transform.GetChild(2).position.x - 70, go.transform.GetChild(2).position.y, go.transform.GetChild(2).position.z);
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
            if (tel_name == telep_list[i].GetComponentInChildren<Text>().text)
            {
                telep_list[i].transform.GetChild(3).gameObject.SetActive(true);
                telep_list[i].GetComponent<Image>().color = wantedcolor;
                telep_list[i].transform.GetChild(1).GetComponent<Image>().color = wantedcolor1;

            }
            else
            {
                telep_list[i].transform.GetChild(3).gameObject.SetActive(false);
                telep_list[i].GetComponent<Image>().color = Color.white;
                telep_list[i].transform.GetChild(1).GetComponent<Image>().color = new Color32(75,75,75,255);
            }
            }
    }

    public void OnExitButtonClick()
    {
        for (int i = 0; i < telep.Length; i++)
        {
            telep_list[i].transform.GetChild(3).gameObject.SetActive(false);
            telep_list[i].GetComponent<Image>().color = Color.white;
            telep_list[i].transform.GetChild(1).GetComponent<Image>().color = new Color32(75, 75, 75, 255);
        }
    }

    public void OnGoButtonClick()
    {       
        for (int i = 0; i < telep.Length; i++)
        {
            foreach (var key in teleport_choice.GetComponent<OnEnable1>().dist_to_telep)
            {
                if (telep_name == telep[i].name && telep_name == key.Key)
                {
                    if (Convert.ToInt32(Text_count_scrolls.text) - key.Value >= 0)
                    {
                        teleport_choice.gameObject.SetActive(false);
                        Confirmation_telep.SetActive(true);
                        if (key.Value == 1)
                            Confirmation_telep.transform.Find("Conf_text").gameObject.GetComponent<Text>().text = "You're going to teleport. Are you sure?";
                        else Confirmation_telep.transform.Find("Conf_text").gameObject.GetComponent<Text>().text = "You're going to teleport. Are you sure?";
                    }
                    else
                    {
                        teleport_choice.gameObject.SetActive(false);
                        Cancel_telep.SetActive(true);
                    }
                }
            }
            telep_list[i].transform.GetChild(3).gameObject.SetActive(false);
            telep_list[i].GetComponent<Image>().color = Color.white;
            telep_list[i].transform.GetChild(1).GetComponent<Image>().color = new Color32(75, 75, 75, 255);
        }
    }
    public void Push_Btn()
    {
        On_Btn_click = true;
    }
    public void OnYesButtonClick()
    {
        //Debug.Log("lol");
        Confirmation_telep.SetActive(false);   
        if(On_Btn_click)
        {
            for (int i = 0; i < telep.Length; i++)
            {
                foreach (var key in backpack.GetComponent<OnEnable1>().dist_to_telep)
                {
                    if (telep_name == telep[i].name && telep_name == key.Key)
                    {
                        GetComponent<VALUE>().Teleport_loss((int)(key.Value));
                        if (gameObject.GetComponent<VALUE>().Teleport == 0) { Text_count_scrolls.transform.parent.gameObject.transform.parent.gameObject.SetActive(false); }
                        player.GetComponent<NavMeshAgent>().enabled = false;
                        player.transform.position = new Vector3(telep[i].transform.position.x - 6f, telep[i].transform.position.y, telep[i].transform.position.z);
                        player.GetComponent<NavMeshAgent>().enabled = true;
                        telep[i].GetComponent<Teleport_list1>()._IsEnable = false;
                        telep[i].GetComponent<Teleport_list1>().telep_choise.SetActive(false);
                    }
                }
            }
            On_Btn_click = false;
        }
        else
        {
            for (int i = 0; i < telep.Length; i++)
            {
                foreach (var key in teleport_choice.GetComponent<OnEnable1>().dist_to_telep)
                {
                    if (telep_name == telep[i].name && telep_name == key.Key)
                    {
                        GetComponent<VALUE>().Teleport_loss((int)(key.Value));
                        if (gameObject.GetComponent<VALUE>().Teleport == 0) { Text_count_scrolls.transform.parent.gameObject.transform.parent.gameObject.SetActive(false); }
                        player.GetComponent<NavMeshAgent>().enabled = false;
                        player.transform.position = new Vector3(telep[i].transform.position.x - 6f, telep[i].transform.position.y, telep[i].transform.position.z);
                        player.GetComponent<NavMeshAgent>().enabled = true;
                        telep[i].GetComponent<Teleport_list1>()._IsEnable = false;
                        telep[i].GetComponent<Teleport_list1>().telep_choise.SetActive(false);
                    }
                }
            }
        }

    }
}
