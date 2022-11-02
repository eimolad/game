using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class Player_move_controller : MonoBehaviour
{
    private static int ANIMATOR_PARAM_Idle = Animator.StringToHash("Idle");
    private static int ANIMATOR_PARAM_WALK_SPEED = Animator.StringToHash("WalkSpeed");

    public LayerMask Click_On;
    private Animator _animator;
    private NavMeshAgent myAgent;
    GameObject Search_Canvas;
    public GameObject Point_Decal_Obj;
    GameObject Del_Obj;
    bool Go = false;
    int count = 0;
    float speed;
    bool Go_to_obj = false;
    GameObject obj_transform;

    void Start()
    {
        Search_Canvas = GameObject.Find("Canvas_Game");// найти объект
        this.myAgent = this.GetComponent<NavMeshAgent>();
        //myAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, 0);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))// нажата правая кнопка мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("Засекаю" + Click_Mouse);
            Destroy(GameObject.FindWithTag("Point"));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, Click_On))// задаем вектор куда идти
            {
                myAgent.SetDestination(hit.point);
                //Debug.Log("Засекаю " + hit.point);
                myAgent.stoppingDistance = 0.1f;
                //StartCoroutine(Search_Canvas.GetComponent<Json_Controller>().Dinamic_Load_OBJ(hit.point));
                Go = true;
                Go_to_obj = false;
                count = 0;
                Destroy(Del_Obj);
                _animator.SetFloat(ANIMATOR_PARAM_Idle, 1);
                gameObject.GetComponent<Player_Attack>().Stop_attack = false;
            }
            Del_Obj = Instantiate(Point_Decal_Obj, hit.point, Quaternion.identity);
        }
        if (Go) GO();
        else GO2();
    }
    void GO()
    {
        if (Del_Obj == null)//если декали нет. то никудв не идем
        {
            myAgent.isStopped = true;
        }
        else
        {
            myAgent.isStopped = false;
            speed = myAgent.velocity.magnitude;
            _animator.SetBool("Huck", false);
            _animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, speed);
        }

        if (myAgent.remainingDistance <= myAgent.stoppingDistance + 0.02f && Go)
        {
            count++;
            if (count > 10)
            {
                Destroy(Del_Obj);
                _animator.SetBool("Huck", false);
                _animator.SetFloat(ANIMATOR_PARAM_Idle, 0);
                _animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, 0);
                myAgent.isStopped = true;
                Go = false;
            }
        }

    }
    void GO2()
    {
        if (Go_to_obj)
        {
            myAgent.SetDestination(obj_transform.transform.position);
            speed = myAgent.velocity.magnitude;
            _animator.SetBool("Huck", false);
            _animator.SetFloat(ANIMATOR_PARAM_Idle, 1);
            _animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, speed);

            if (myAgent.remainingDistance <= myAgent.stoppingDistance + 0.02f && Go_to_obj)
            {
                count++;
                if (count > 10)
                {                    
                    _animator.SetFloat(ANIMATOR_PARAM_Idle, 0);
                    _animator.SetFloat(ANIMATOR_PARAM_WALK_SPEED, 0);
                    _animator.SetBool("Huck", false);
                    myAgent.isStopped = true;
                    Go_to_obj = false;
                }
            }
        }
    }
    public void Go_in_Obj(GameObject obj)
    {
        gameObject.GetComponent<Player_Attack>().Stop_attack = true;
        _animator.SetFloat(ANIMATOR_PARAM_Idle, 0);
        _animator.SetBool("Huck", false);
        obj_transform = obj;
        myAgent.isStopped = false;
        myAgent.stoppingDistance = 1.5f;
        Go_to_obj = true;
        Go = false;
        count = 0;
        Destroy(Del_Obj);
    }
 

}
