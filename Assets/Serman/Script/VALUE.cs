using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine.AI;


public class VALUE : MonoBehaviour
{
    public string Player_Name;// имя игрока
    public List<string> equipment;
    public float Cur_HP;
    public float HP;
    public float Cur_MP;
    public float MP;
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
    //GameObject Canvas_Game;
    List<GameObject> Scroll_All = new List<GameObject>();
    public Image Slider_HP_bar;
    public Image Slider_MP_bar;
    public Image Slider_exp_bar;
    public TMP_Text Icp_Text;
    public TMP_Text Gold_Text;
    public TMP_Text Adit_Text;
    public TMP_Text Bronze_Text;
    public TMP_Text Coal_Text;
    public TMP_Text Ore_Text;

    public float Icp;
    public int Gold;
    public int Coal;//уголь
    public int Ore;//Руда
    public int Adit;
    public int Lgs;//
    public int Leather;//Кожа
    public int Bronze;
    public int Tp;// телепорт

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
    float TimeDelay = 1;
    float TimeDelayHp;
    float TimeDelayMp;
    public int cur_experience;
    public int weight;
    public int loot_bonus;

    public TMP_Text HP_regen;
    public TMP_Text MP_regen;
    public Text Player_Name_Text;
    public TMP_Text Level_txt;
    public TMP_Text Rang_txt_for_bar;
    public TMP_Text HP_txt;
    public TMP_Text MP_txt;
    public TMP_Text Teleport_txt;
    public TMP_Text Gold_txt;
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
    public Dictionary<string, Vector3> Teleport_Dictionary = new Dictionary<string, Vector3>();
    public List<GameObject> Enemy_List = new List<GameObject>();
    public List<string> Weapon_inventory = new List<string>();
    public string Weapon_List_Count_num = "null";
    public List<string> Shild_inventory = new List<string>();
    public string Shild_List_Count_num = "null";
    public List<string> All_inventory = new List<string>();
    //public string Left_Hаnd;

    void Start()
    {
        Player_Name_Text.text = Player_Name;
        Level_txt.text = level.ToString();
        //Canvas_Game = GameObject.Find("Canvas_Game");
        Cur_HP = 471f;
        Cur_MP = 371f;
        cur_experience = 0;
        experience = 100;


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

    public void started_game()
    {
        //Debug.Log(equipment.Count);
        gameObject.GetComponent<Load_Hero_Inventory>().enabled = true;
        //StartCoroutine(gameObject.GetComponent<Load_Hero_Inventory>().load_hero_complekt());
    }
    void Attributes()
    {
        if (Icp >= 1000f)
        {
            int rounded = (int)Math.Round(Icp, 0);
            Icp_Text.text = (rounded / 1000f).ToString() + "K";
        }             
        else
        {
            int rounded = (int)Math.Round(Icp, 0);
            Icp_Text.text = rounded.ToString();
        }

        if (Gold >= 1000) Gold_Text.text = (Gold / 1000).ToString() + "K";
        else Gold_Text.text = Gold.ToString();

        if (Coal >= 1000) Coal_Text.text = (Coal / 1000).ToString() + "K";
        else Coal_Text.text = Coal.ToString();

        if (Ore >= 1000) Ore_Text.text = (Ore / 1000).ToString() + "K";
        else Ore_Text.text = Ore.ToString();

        if (Adit >= 1000) Adit_Text.text = (Adit / 1000).ToString() + "K";
        else Adit_Text.text = Adit.ToString();

        if (Bronze >= 1000) Bronze_Text.text = (Bronze / 1000).ToString() + "K";
        else Bronze_Text.text = Bronze.ToString();
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
        Attributes();

        if (cur_experience >= experience)
        {
            level++;
            cur_experience = 0;
            strength += Convert.ToInt32(Math.Ceiling(strength * 0.04f));
            dexterity += Convert.ToInt32(Math.Ceiling(dexterity * 0.02f));
            intelligence += Convert.ToInt32(Math.Ceiling(intelligence * 0.03f));
            experience = experience * 2;
        }
        HP = 10 * strength;
        MP = 10 * intelligence;
        attack = strength;
        m_attack = intelligence;
        attack_speed = dexterity;
        Teleport_txt.text = Tp.ToString();
        hp_regen = 0.05f * strength;
        mp_regen = (int)(0.05 * intelligence);
        HP_regen.text = "+" + hp_regen.ToString();
        MP_regen.text = "+" + mp_regen.ToString();
        if (Cur_HP < HP)
        {
            TimeDelayHp += Time.deltaTime;
            if (TimeDelayHp >= TimeDelay)
            {
                Cur_HP += hp_regen;
                TimeDelayHp = 0;
                if (Cur_HP >= HP) Cur_HP = HP;
            }
        }
        if (Cur_MP < MP)
        {
            TimeDelayMp += Time.deltaTime;
            if (TimeDelayMp >= TimeDelay)
            {
                Cur_MP += mp_regen;
                //cur_experience += 10;
                TimeDelayMp = 0;
                if (Cur_MP >= MP) Cur_MP = MP;
            }
        }

        if (strength / 10 > 50) st_resist = 50;
        else st_resist = strength / 10;
        if (dexterity / 10 > 50) evasion = 50;
        else evasion = dexterity / 10;
        if (dexterity / 10 > 100) accuracy = 100;
        else accuracy = dexterity / 10;
        Slider_HP_bar.fillAmount = Cur_HP / HP;
        HP_txt.text = ((int)Cur_HP).ToString() + "/" + HP;
        Player_Name_Text.text = Player_Name;// присваиваем имя игрока (берется из json)
        Level_txt.text = level.ToString();// присваиваем уровень игрока (берется из json)
        Slider_exp_bar.fillAmount = cur_experience * 1f / experience * 1f;
        Rang_txt_for_bar.text = (Math.Ceiling((cur_experience * 1f / experience * 1f) * 100)).ToString() + " %";// присваиваем опыт игрока (берется из json)
        Slider_MP_bar.fillAmount = Cur_MP / MP;
        MP_txt.text = ((int)Cur_MP).ToString() + "/" + MP;

        //Svitok_obj.SetActive(recipe);// показываем или нет свиток в инвентаре
        //Shild_obj.SetActive(Shild);// показываем или нет щит
        //Inventory_Shild.SetActive(Shild);// показываем или нет щит
        //Shild_obj_Veapon_bar.SetActive(Shild);// показываем или нет щит
        //Empty_shild.SetActive(!Shild);
        //if (scroll_caunt > 0)
        //{
        //    Svitok_obj2.SetActive(true);
        //    scroll_text.text = scroll_caunt.ToString();
        //}
        //else
        //{
        //    Svitok_obj2.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    HP -= 10;
        //    //gameObject.GetComponent<Svitok_Generate_go>().enabled = true;
        //    //gameObject.GetComponent<Svitok_Generate_go>().count_name = 0;
        //}
    }
    public void Gold_take()
    {
        if (level <= 5)
        {
            Gold += 3;
            cur_experience += 30;
        }
        if (level > 5 && level < 8)
        {
            Gold += 2;
            cur_experience += 20;
        }
        if (level > 7 && level < 10)
        {
            Gold += 1;
            cur_experience += 10;
        }
        Gold_txt.text = Gold.ToString();
        //GetComponent<Base_React>().Go("pickedUpTeleport=" + count.ToString());
    }
    public void Teleport_take(int count)
    {
        Tp += 1;
        Teleport_mess_obj.SetActive(true);
        //GetComponent<Base_React>().Go("pickedUpTeleport=" + count.ToString());
    }
    public void Teleport_loss(int count)
    {
        //Debug.Log(count);
        Tp = Tp - count;
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
        if (DoOnce_Save)
        {
            gameObject.GetComponent<Json_Player_info>().Save_json();
            DoOnce_Save = false;
        }

    }
}
