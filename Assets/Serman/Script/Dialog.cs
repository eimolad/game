using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject Button_obj;
    public GameObject CanvasGame;
    public Text text_npc;
    public Text text_hero_yes;
    public Text text_hero_no;
    public string[] Dialog_all_NPC;
    public string[] Hero_response_yes;
    public string[] Hero_response_no;
    float Time_Count = 5f;
    bool start_timer = false;
    public string NPC;
    GameObject Diller_obj;
    GameObject Brother_obj;
    bool start_time_anim = false;
    float Time_anim = 1f;
    float count_anim = 0.3f;
    bool Duonce = true;
     

    private static int ANIMATOR_PARAM = Animator.StringToHash("Blend_anim");

    private Animator Diller_anim;

    [System.Obsolete]
    void Start()
    {

        //count_dialog = CanvasGame.GetComponent<VALUE>().Dialog_count;
        //process = CanvasGame.GetComponent<VALUE>().processing;
        //quest_done = CanvasGame.GetComponent<VALUE>().Quest_done;
        //step = CanvasGame.GetComponent<VALUE>().Step_quest;



        Diller_obj = GameObject.Find("Dealer");// найти объект торговец
        Diller_anim = Diller_obj.GetComponent<Animator>();// назначить аниматор торговца
        Brother_obj = GameObject.Find("Brother_Dealer");// найти объект брат торговца
        //Brother_anim = Brother_obj.GetComponent<Animator>();// назначить аниматор брата торговца

        Dialog_npc_func();
        Diller_anim.SetFloat(ANIMATOR_PARAM, 0);
        start_time_anim = true;


    }

    [System.Obsolete]
    public void Dialog_npc_func()
    {
        if (CanvasGame.GetComponent<VALUE>().Dialog_count >= Dialog_all_NPC.Length)
        {
            gameObject.SetActive(false);
        }
        else
        {
            text_npc.text = Dialog_all_NPC[CanvasGame.GetComponent<VALUE>().Dialog_count];
        }


        if (CanvasGame.GetComponent<VALUE>().Dialog_count == 3 || CanvasGame.GetComponent<VALUE>().Dialog_count == 5 || CanvasGame.GetComponent<VALUE>().Dialog_count > 5)// 
        {
            if (Button_obj.active) Button_obj.SetActive(false);
            start_timer = true;
        }
        else
        {
            if (!Button_obj.active) Button_obj.SetActive(true);
            text_hero_yes.text = Hero_response_yes[CanvasGame.GetComponent<VALUE>().Dialog_count];
            text_hero_no.text = Hero_response_no[CanvasGame.GetComponent<VALUE>().Dialog_count];
        }

    }

    [System.Obsolete]
    public void Responce_hero_Button_yes()
    {
        if (CanvasGame.GetComponent<VALUE>().Dialog_count < Dialog_all_NPC.Length) CanvasGame.GetComponent<VALUE>().Dialog_count += 1;
        CanvasGame.GetComponent<Json_Controller>().Save_json();// сохраняем json
        //Debug.Log("кнопка нажата Dialog_count " + CanvasGame.GetComponent<VALUE>().Dialog_count.ToString());
        Dialog_npc_func();
        if (CanvasGame.GetComponent<VALUE>().Dialog_count == 3 || CanvasGame.GetComponent<VALUE>().Dialog_count == 6)//
        {
            gameObject.SetActive(false);
            Diller_anim.SetFloat(ANIMATOR_PARAM, 1.3f);
        }
    }
    [System.Obsolete]
    public void Stop_dialog()
    {
        if (CanvasGame.GetComponent<VALUE>().Dialog_count <= 3)
        {
            CanvasGame.GetComponent<VALUE>().Dialog_count = 0;
            CanvasGame.GetComponent<Json_Controller>().Save_json();// сохраняем json
        }
        if (CanvasGame.GetComponent<VALUE>().Dialog_count >= 3 && CanvasGame.GetComponent<VALUE>().Dialog_count <= 5) CanvasGame.GetComponent<VALUE>().Dialog_count = 4;
        Dialog_npc_func();
        Diller_anim.SetFloat(ANIMATOR_PARAM, 1.3f);
        Duonce = true;
        gameObject.SetActive(false);
    }
   
    public void Disconect_Obj()
    {
        count_anim = 1.3f;
        Diller_anim.SetFloat(ANIMATOR_PARAM, count_anim);
        Duonce = true;
    }
    void Play_anim()
    {
        if (start_time_anim)
        {
            Time_anim -= Time.deltaTime;
        }
        if (Time_anim <= 0)
        {
            if (count_anim >= 3.8) count_anim = 1.3f;
            else count_anim += 0.002f;
            Diller_anim.SetFloat(ANIMATOR_PARAM, count_anim);
            Time_anim = 0.01f;
            //Debug.Log("Время");
        }

    }

    [System.Obsolete]
    void Update()
    {
        Play_anim();
        //var animatorStateInfo = Diller_anim.GetCurrentAnimatorStateInfo(0);
        //Debug.Log(animatorStateInfo.IsName("Blend_idle"));

        if (Time_Count <= 0)
        {
            start_timer = false;
            Time_Count = 5f;
            if (CanvasGame.GetComponent<VALUE>().Dialog_count < Dialog_all_NPC.Length) CanvasGame.GetComponent<VALUE>().Dialog_count += 1;
            CanvasGame.GetComponent<Json_Controller>().Save_json();// сохраняем json
            Dialog_npc_func();
            //Debug.Log("Вркмя");
        }
        if (start_timer)
        {
            Time_Count -= Time.deltaTime;
        }
        Steps_func();

        //count_dialog = CanvasGame.GetComponent<VALUE>().Dialog_count;
        //process = CanvasGame.GetComponent<VALUE>().processing;
        //quest_done = CanvasGame.GetComponent<VALUE>().Quest_done;
        //step = CanvasGame.GetComponent<VALUE>().Step_quest;

        //CanvasGame.GetComponent<VALUE>().Dialog_count = count_dialog;
        //CanvasGame.GetComponent<VALUE>().processing = process;
        //CanvasGame.GetComponent<VALUE>().Quest_done = quest_done;
        //CanvasGame.GetComponent<VALUE>().Step_quest = step;
    }

    void Steps_func()
    {
        if (CanvasGame.GetComponent<VALUE>().Dialog_count <= 3) CanvasGame.GetComponent<VALUE>().Step_quest = 1;
        if (CanvasGame.GetComponent<VALUE>().Dialog_count >= 3 && CanvasGame.GetComponent<VALUE>().Dialog_count <= 4) CanvasGame.GetComponent<VALUE>().Step_quest = 2;
        if (CanvasGame.GetComponent<VALUE>().Dialog_count >= 6 && CanvasGame.GetComponent<VALUE>().Dialog_count <= 8) CanvasGame.GetComponent<VALUE>().Step_quest = 3;
        if (CanvasGame.GetComponent<VALUE>().Dialog_count >= Dialog_all_NPC.Length)
        {
            if (!CanvasGame.GetComponent<VALUE>().Quest_done)
            {
                //VALUE.Rang += 1;
                CanvasGame.GetComponent<VALUE>().Active_OBJ(true);// активируем большой свиток
                CanvasGame.GetComponent<VALUE>().processing = true;
                CanvasGame.GetComponent<VALUE>().Quest_done = true;
                gameObject.GetComponent<Base_React>().Go("pickedUpLgs");
                CanvasGame.GetComponent<Json_Controller>().Save_json();// сохраняем json
                gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
        //Debug.Log(NPC);
        if (NPC == "Dealer" && CanvasGame.GetComponent<VALUE>().Dialog_count <= 3)
        {
            if (Duonce)
            {
                Time_anim = 1f;
                count_anim = 0f;
                Diller_anim.SetFloat(ANIMATOR_PARAM, 0);
                Duonce = false;
            }

        }

        //if (VALUE.Dialog_count >= Dialog_all_NPC.Length) gameObject.SetActive(false);

        switch (CanvasGame.GetComponent<VALUE>().Step_quest)
        {
            case 0:
                if (NPC == "Dealer") gameObject.SetActive(true);
                if (NPC == "Brother_Dealer") gameObject.SetActive(false);
                break;
            case 1:
                if (NPC == "Dealer") gameObject.SetActive(true);
                if (NPC == "Brother_Dealer") gameObject.SetActive(false);
                //count_anim = 1.3f;
                break;
            case 2:
                if (NPC == "Dealer") gameObject.SetActive(false);
                if (NPC == "Brother_Dealer") gameObject.SetActive(true);
                break;
            case 3:
                if (NPC == "Dealer" && !CanvasGame.GetComponent<VALUE>().Quest_done) gameObject.SetActive(true);
                if (NPC == "Brother_Dealer") gameObject.SetActive(false);
                break;
        }


    }
}
