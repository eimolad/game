using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class Player_move_mouse_2 : MonoBehaviour
{

    public LayerMask Click_On;
    public GameObject Point_Decal_Obj;
    GameObject Del_Obj;
    GameObject Search_Canvas;
    private NavMeshAgent myAgent;
    Vector3 point_hero;
    Vector3 point_Set;
    Vector3 Set_Vector;
    Animator anim;
    bool Click_Mouse = false;
    bool stop_time = false;
    bool Stop = true;
    bool GO = false;

    int time = 0;
    int time_set = 0;
    int time_set2 = 0;
    float Time_Start = 0.6f;
    float speed;

    private static int ANIMATOR_PARAM_WALK_SPEED = Animator.StringToHash("WalkSpeed");

    private Animator _animator;
    private NavMeshAgent _agent;

    private void Awake()
    {
        //this._animator = this.GetComponent<Animator>();
        //this._agent = this.GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        if (Stop)
        {
            speed = this._agent.velocity.magnitude;
            this._animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, speed);
        }

    }
    void Start()
    {
        Search_Canvas = GameObject.Find("Canvas_Game");// найти объект
        myAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        this._animator = this.GetComponent<Animator>();
        this._agent = this.GetComponent<NavMeshAgent>();
    }

    void Timer_Back()
    {
        Time_Start -= Time.deltaTime;
        //Debug.Log(Time_Start);
        if (Time_Start <= 0)
        {
            Set_Vector = transform.position;// засекаем положение объекта
            //Debug.Log("Засекаю");
            Time_Start = 0.6f;
        }
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Timer_Back();

        time += 1;
        if (Input.GetMouseButtonUp(1))// отжата правая кнопка мыши
        {
            //Debug.Log("Засекаю" + Click_Mouse);
            Destroy(GameObject.FindWithTag("Point"));
            if (Click_Mouse)
            {
                Stop = true;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.Log("Pos_Mouse " + Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, Click_On))// задаем вектор куда идти
                {
                    myAgent.SetDestination(hit.point);
                    point_hero = hit.point;
                    //Del_Obj = Instantiate(Point_Decal_Obj, point_hero, Quaternion.identity);
                    Click_Mouse = false;
                    GO = true;
                    point_Set = point_hero;
                   StartCoroutine(Search_Canvas.GetComponent<Json_Controller>().Dinamic_Load_OBJ(point_Set));
                    //Debug.Log(point_Set);
                }
                Del_Obj = Instantiate(Point_Decal_Obj, point_hero, Quaternion.identity);
                //Debug.Log(point_hero);
            }
            stop_time = false;
            Click_Mouse = false;
        }
        if (Input.GetMouseButtonDown(1))// нажата правая кнопка мыши
        {
            Click_Mouse = true;
            time_set = time;
            //Debug.Log("Засекаю");
            stop_time = true;
            Destroy(GameObject.FindWithTag("Point"));
            Destroy(Del_Obj);
        }

        if (point_Set == point_hero && GO == true && Del_Obj == null)
        {
            GO = false;
            Del_Obj = Instantiate(Point_Decal_Obj, point_hero, Quaternion.identity);
            Stop = true;
            //Debug.Log("Просрал");
        }
        if (Del_Obj == null)//если декали нет. то никудв не идем
        {
            myAgent.isStopped = true;
        }
        else
        {
            myAgent.isStopped = false;
        }

        if (time > time_set + 25 && stop_time)// таймер для нажатия
        {
            Click_Mouse = false;
            stop_time = false;
        }
        if (myAgent.remainingDistance <= myAgent.stoppingDistance + 0.01f && Stop)//
        {
            Destroy(Del_Obj);
            Destroy(GameObject.FindWithTag("Point"));
            _animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, 0);           
            Stop = false;
        }
        //Debug.Log(Del_Obj);
        //Debug.Log("Stop = " + Stop);
        //Debug.Log("Дистанция = " + myAgent.remainingDistance);
        //Debug.Log("Stop = " + myAgent.stoppingDistance);
    }
}
