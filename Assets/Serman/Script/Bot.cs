using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    private NavMeshAgent Bot_Agent;
    Animator anim;
    public Transform target;
    public GameObject Pirimetr;
    public string Blend_Tree_Parametr_name = "Brother_anim";
    private static int ANIMATOR_PARAM_WALK= Animator.StringToHash("");
    float Welk_speed;
    bool Stop = true;
    bool Stop_point = true;
    bool DoOnce = true;
    bool Start_Time = false;
    float X_point, X_min, X_max, X_Scale;
    float Z_point, Z_min, Z_max, Z_Scale;
    float Time_Go = 5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        ANIMATOR_PARAM_WALK = Animator.StringToHash(Blend_Tree_Parametr_name);
        Bot_Agent = GetComponent<NavMeshAgent>();
        X_Scale = Pirimetr.GetComponent<Transform>().localScale.x * 10 / 2;
        X_min = Pirimetr.transform.position.x - X_Scale;
        X_max = Pirimetr.transform.position.x + X_Scale;
        X_point = Random.Range(X_min, X_max);
        Z_Scale = Pirimetr.GetComponent<Transform>().localScale.z * 10 / 2;
        Z_min = Pirimetr.transform.position.z - Z_Scale;
        Z_max = Pirimetr.transform.position.z + Z_Scale;
        Z_point = Random.Range(Z_min, Z_max);
        target.position = new Vector3(X_point, 0f, Z_point);
     
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            Bot_Agent.Stop();
            Start_Time = false;
            Stop_point = false;
        }
        catch { }
  
    }

    [System.Obsolete]
    void OnTriggerExit(Collider other)
    {
        try
        {
            Bot_Agent.Resume();
            Start_Time = true;
            Stop_point = true;
        }
        catch { }

    }
    private void LateUpdate()
    {
        if (Stop)
        {
            Welk_speed = Bot_Agent.velocity.magnitude;
            anim.SetFloat(ANIMATOR_PARAM_WALK, Welk_speed);
        }

    }

    void Update()
    {
        if(Start_Time)
        {
            if (Time_Go <= 0 && Start_Time)
            {
                Time_Go = 5f;
                Start_Time = false;
                DoOnce = true;
            }
            Time_Go -= Time.deltaTime;
        }
        if (DoOnce)
        {
            NavMeshPath path = new NavMeshPath();
            Bot_Agent.CalculatePath(target.position, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                Bot_Agent.SetPath(path);
            }
            DoOnce = false;
            Stop_point = true;
        }
        if(Bot_Agent.remainingDistance <= Bot_Agent.stoppingDistance + 0.01f && Stop_point)
        {
            X_point = Random.Range(X_min, X_max);
            Z_point = Random.Range(Z_min, Z_max);
            target.position = new Vector3(X_point, Pirimetr.transform.position.y, Z_point);
            Stop_point = false;
            Start_Time = true;
        }
    }
}
