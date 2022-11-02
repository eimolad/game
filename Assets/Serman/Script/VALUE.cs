using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Json_Controller;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine.AI;
using Unity.Burst.CompilerServices;

public class VALUE : MonoBehaviour
{
    public string Player_Name;// имя игрока
    public float HP;
    public bool Quest_done;// степень выполнения квеста
    public int Dialog_count;// на какой стадии разговора закончили
    public int Step_quest;// храним шаги квеста
    public bool processing;
    public bool recipe;// наличие рецепта
    public bool Shild; // наличие щита
    public int obj_name_bundle;
    public float obj_medium;
    public Vector3[] scroll_vector = new Vector3[5];// координаты кожанного свитка
    public int scroll_caunt; // колличество добытых свитков
    public TMP_Text scroll_text;
    GameObject Canvas_Game;
    List<GameObject> Scroll_All = new List<GameObject>();
    public Image Slider_HP_bar;
    public int Teleport;

    public int experience;// опыт
    public int level; // уровень
    public int strength;// сила
    public int attack;// атака
    public int st_resist;
    public float hp_regen;// регенерация
    public int dexterity;// ловкость
    public int attack_speed;// скорость атаки
    public int evasion;
    public int accuracy;
    public int intelligence;
    public int m_attack;
    public int mp_regen;
    public int move_speed;
    public int initial_attack_speed;
    public int initial_evasion;
    public int initial_accuracy;
    public int critical_chance;
    public int spell_speed;
    public int cooldown;
    public int defence;
    public int m_resist;
    public int set_bonus;

    public Text Player_Name_Text;
    public TMP_Text Level_txt;
    public TMP_Text Rang_txt_for_bar;
    public TMP_Text HP_txt;
    public TMP_Text Teleport_txt;
    //public GameObject Shild_obj, Inventory_Shild, Shild_obj_Veapon_bar;//объекты щита
    public GameObject Svitok_obj;
    public GameObject Svitok_obj2;
    public GameObject Big_Svitok_obj;
    public GameObject Teleport_mess_obj;
   GameObject Scroll;
    Transform First_Scroll;
    int Count_scrol_transform;
    //public GameObject Empty_shild;
    int obj_count = 0;
    public bool DoOnce_Save = true;


    void Start()
    {
        Player_Name_Text.text = Player_Name;
        Level_txt.text = level.ToString();
        Canvas_Game = GameObject.Find("Canvas_Game");
        HP = 500f;

        //Shild_obj = GameObject.Find("shild");
        //Svitok();
        //for (int i = 0; i < scroll_vector.Length; i++)
        //{
        //    for (int s = 0; s < scroll_vector[i].Length; s++)
        //    {
        //        Debug.Log(scroll_vector[i][s]); 
        //    }
        //}
        //Scroll = GameObject.Find("Svitok");
        //Instantiate(Scroll, Scroll.transform.position, Scroll.transform.rotation);
        //Rang_txt = gameObject.AddComponent<TMP_Text>();
    }

    public void Active_OBJ(bool DoOnce)
    {
        if (DoOnce)
        {
            Big_Svitok_obj.SetActive(true);
            DoOnce = false;
        }
    }

    void Update()
    {
        Teleport_txt.text = Teleport.ToString();
        float X = 10 * strength;
        Slider_HP_bar.fillAmount = HP / X;
        Player_Name_Text.text = Player_Name;// присваиваем имя игрока (берется из json)
        Level_txt.text = level.ToString();// присваиваем опыт игрока (берется из json)
        Rang_txt_for_bar.text = experience.ToString() + "/100";// присваиваем опыт игрока (берется из json)
        HP_txt.text = HP.ToString() + "/" + 10 * strength;
        Svitok_obj.SetActive(recipe);// показываем или нет свиток в инвентаре
        //Shild_obj.SetActive(Shild);// показываем или нет щит
        //Inventory_Shild.SetActive(Shild);// показываем или нет щит
        //Shild_obj_Veapon_bar.SetActive(Shild);// показываем или нет щит
        //Empty_shild.SetActive(!Shild);
        if (scroll_caunt > 0)
        {
            Svitok_obj2.SetActive(true);
            scroll_text.text = scroll_caunt.ToString();
        }
        else
        {
            Svitok_obj2.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    HP -= 10;
        //    //gameObject.GetComponent<Svitok_Generate_go>().enabled = true;
        //    //gameObject.GetComponent<Svitok_Generate_go>().count_name = 0;
        //}
    }
    public void Teleport_take(int count)
    {
        Teleport += 1;
        Teleport_mess_obj.SetActive(true);
        //GetComponent<Base_React>().Go("pickedUpTeleport=" + count.ToString());
    }
    public void Teleport_loss(int count)
    {
        //Debug.Log(count);
        Teleport = Teleport - count;
        //GetComponent<Base_React>().Go("teleportUsed=" + count.ToString());
    }
    public void Svitok()
    {
        Scroll = GameObject.Find("Svitok");
        First_Scroll = Scroll.GetComponent<Transform>();
        Count_scrol_transform = 0;
        bool empty_vecktor = false;
        int count = 0;
        for (int x = 0; x < scroll_vector.Length; x++)
        {
            if (0 == scroll_vector[x].x && 0 == scroll_vector[x].z) count += 1;
            if (count == 5) empty_vecktor = true;
        }
        //Debug.Log(count);
        //Debug.Log("запускаю генерацию свитков");
        if (scroll_caunt < 5)
        {
            for (int i = 0; i < scroll_vector.Length; i++)
            {
                GameObject instance = Instantiate(Scroll);

                if (empty_vecktor)
                {
                    instance.name = instance.name + i.ToString();
                    Scroll_All.Add(instance);
                    instance.GetComponent<NavMeshAgent>().enabled = true;
                    instance.GetComponent<Svitok_point>().random_location();// рандом свитка                 
                }
                else
                {
                    if (0 == scroll_vector[i].x && 0 == scroll_vector[i].z && !empty_vecktor)
                    {
                        Destroy(instance);
                    }
                    else
                    {
                        instance.name = instance.name + i.ToString();
                        instance.GetComponent<Svitok_point>().point_location(scroll_vector[i]);// статические координаты свитка
                    }
    
                }
            }
            Destroy(Scroll);
        }
        else
        {
            Destroy(Scroll);
        }
    }

    public void Take_Svitok(int name_svitok, GameObject svitok)
    {
        //Debug.Log("пришло " + name_svitok);
        Destroy(svitok);
        scroll_vector[name_svitok] = new Vector3(0, 0, 0);
        scroll_caunt += 1;
        DoOnce_Save = true;
        Save_Svitok_Vector();


    }
    public void Distance_check()
    {
        Count_scrol_transform += 1;

        if (Count_scrol_transform == 5) gameObject.GetComponent<Svitok_Generate_go>().enabled = true;
    }
    public void Save_Svitok_Vector()
    {
        if(DoOnce_Save)
        {
            Canvas_Game.GetComponent<Json_Controller>().Save_json();
            DoOnce_Save = false;
        }
       
    }
}
