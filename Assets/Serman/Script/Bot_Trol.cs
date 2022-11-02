using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;


public class Bot_Trol : MonoBehaviour
{
    private NavMeshAgent Bot_Agent;
    Animator anim;
    private static int ANIMATOR_PARAM_WALK = Animator.StringToHash("Go");
    private static int ANIMATOR_PARAM_Idle = Animator.StringToHash("Idle");
    private static int ANIMATOR_PARAM_Attack = Animator.StringToHash("Attack");

    bool Stop = false;
    Player_Attack Player_Attack;
    GameObject Player_Hero;
    
    bool GO = false;
    public Vector3 portal;
    public float Distance_Plaer = 25f;
    Outline Contur;
    float speed;
    private int count;
    bool Go_Portal = false;
    bool start = false;

    void Start()
    {
        Player_Hero = GameObject.Find("Hero Variant");
        Bot_Agent = gameObject.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Bot_Agent.enabled = true;
        Player_Attack = Player_Hero.GetComponent<Player_Attack>(); // скрипт атаки
        portal = transform.position;
        Contur = GetComponent<Outline>();
        Contur.enabled = false;
        //Debug.Log(portal);
    }
    private void OnMouseDown()
    {
        Player_Attack.Attack_Click(gameObject);// передаем игроку объект по которому был клик
        GO = true;
        start = true;
        Go_Portal = false;
    }
    void OnMouseEnter()
    {
        Contur.enabled = true;// включаем скрипт подсвети объекта
    }
    private void OnMouseExit()
    {
        Contur.enabled = false;// выключаем скрипт подсвети объекта
    }
    void Update()
    {
        if (!Go_Portal && Bot_Agent.enabled) transform.LookAt(Player_Hero.transform.position);// поворот в сторону игрока


        Go_in_Hero();
    }
    public void Death()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Death", true);        
    }
    void Go_in_Hero()
    {
        var dist = Vector3.Distance(transform.position, Player_Hero.transform.position); // дистанция до героя
        var dist_portal = Vector3.Distance(transform.position, portal); // дистанция до портала
        if (GO)
        {
            if (!Go_Portal)
            {
                Bot_Agent.SetDestination(Player_Hero.transform.position);// бежим за героем
            }
            else
            {
                Bot_Agent.SetDestination(portal);// бежим к порталу
            }
            Bot_Agent.isStopped = false;
            anim.SetBool("Run", true);
            Stop = true;
            //Debug.Log("побежал");

            if (Bot_Agent.remainingDistance <= Bot_Agent.stoppingDistance + 0.02f && GO)
            {
                count++;
                if (count > 10)
                {
                    //Debug.Log("прибежал, атакую");
                    anim.SetBool("Run", false);
                    anim.SetBool("Attack", true);
                    Bot_Agent.isStopped = true;
                    GO = false;
                    Stop = true;
                    //Go_Portal = false;
                    count = 0;

                }
            }
        }
        if (dist > 5 && Stop) GO = true; // если до героя большая дистанция, то бежим за ним

        if (dist > 2 && !GO)
        {
            //Debug.Log("потерял героя");
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Huck", false);
        }

        if (dist_portal > 20 && start) // если портал далеко, возврат к нему
        {
            //Debug.Log("далеко от портала");
            Go_Portal = true;
        }

        if (dist_portal < 3 && Go_Portal) // подошли к порталу
        {
            start = false;
            Bot_Agent.isStopped = true;
            GO = false;
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Huck", false);
            count = 0;
            Go_Portal = false;
            Stop = false;
            //Debug.Log("пребежал к порталу");            
        }
    }
    void Agressive_Attack()
    {
        transform.LookAt(Player_Hero.transform.position);// поворот в сторону игрока
        var dist = Vector3.Distance(transform.position, Player_Hero.transform.position); // дистанция до героя
        if (dist <= Distance_Plaer)
        {
            Bot_Agent.SetDestination(Player_Hero.transform.position);// бежим за героем            
        }
        else
        {
            Bot_Agent.SetDestination(portal);// возврвт к порталу
            GO = false;
        }
        if (Bot_Agent.remainingDistance <= Bot_Agent.stoppingDistance + 0.5f && Stop)//
        {

        }
    }
}
