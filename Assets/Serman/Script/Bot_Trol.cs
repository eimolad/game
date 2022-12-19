
using UnityEngine;
using UnityEngine.AI;


public class Bot_Trol : MonoBehaviour
{
    private NavMeshAgent Bot_Agent;
    NavMeshObstacle Obstacle;
    ObstacleAgent Obstacle_skript;

    Animator anim;
    private static int ANIMATOR_PARAM_WALK = Animator.StringToHash("Go");
    private static int ANIMATOR_PARAM_Idle = Animator.StringToHash("Idle");
    private static int ANIMATOR_PARAM_Attack = Animator.StringToHash("Attack");

    bool Stop = false;
    Player_Attack Player_Attack;
    GameObject Player_Hero;

    public GameObject Tach_Bodey;
    public bool GO = false;
    public Vector3 portal;
    public float Distance_Plaer = 25f;
    Outline Contur;
    float speed;
    private int count;
    bool Go_Portal = false;
    bool start = false;
    public bool Agreses = false;
    bool patrlol = true;

    private void Awake()
    {

    }
    void Start()
    {
        Player_Hero = GameObject.Find("Hero Variant");
        Bot_Agent = gameObject.GetComponent<NavMeshAgent>();
        Obstacle = GetComponent<NavMeshObstacle>();
        Obstacle_skript = GetComponent<ObstacleAgent>();
        Obstacle_skript.enabled = false;
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
        //Stop = true;
        //GO = true;
        //start = true;
        //Go_Portal = false;
    }
    void OnMouseEnter()
    {
        Contur.enabled = true;// включаем скрипт подсвети объекта
    }
    private void OnMouseExit()
    {
        Contur.enabled = false;// выключаем скрипт подсвети объекта
    }

    public void Help_Brathers()
    {
        GO = true;
        start = true;
        Go_Portal = false;
        //Debug.Log("помогаем");
        Obstacle_skript.enabled = true;
        Bot_Agent.SetDestination(Player_Hero.transform.position);// бежим за героем
        Obstacle_skript.SetDestination(Player_Hero.transform.position);
        Agreses = true;
    }
    void FixedUpdate()
    {
        if (!Go_Portal && Bot_Agent.enabled && Agreses) transform.LookAt(Player_Hero.transform.position);// поворот в сторону игрока
        Go_in_Hero();
        Welk_Patrol();
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

        if (dist < 3 && !Agreses)
        {
           if(Player_Hero.GetComponent<Player_Attack>().Agresiya)// если герой агресивный и рядом
            {
                Help_Brathers();
            }
        }

        if (GO)
        {
            if (!Go_Portal)
            {
                Bot_Agent.speed = 2f;
                Bot_Agent.SetDestination(Player_Hero.transform.position);// бежим за героем
                Obstacle_skript.SetDestination(Player_Hero.transform.position);
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
                    count = 0;

                }
            }
        }
        if (dist > 2.5f && Stop) GO = true; // если до героя большая дистанция, то бежим за ним

        if (dist > 2 && !GO)
        {
            //Debug.Log("потерял героя");
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Huck", false);
        }

        if (dist_portal > 40 && start) // если портал далеко, возврат к нему
        {
            //Debug.Log("далеко от портала");
            Bot_Agent.speed = 2f;
            Obstacle_skript.enabled = false;
            Obstacle.enabled = false;
            Bot_Agent.enabled = true;
            Go_Portal = true;
        }

        if (dist_portal < 3 && Go_Portal) // подошли к порталу
        {
            Agreses = false;
            start = false;
            Bot_Agent.isStopped = true;
            GO = false;
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Huck", false);
            anim.SetBool("Welk", false);
            count = 0;
            Go_Portal = false;
            Stop = false;
            //Debug.Log("пребежал к порталу");            
        }
    }

    public void Welk_Patrol()
    {
        if(patrlol && !Agreses)
        {            
            var point = new Vector3(portal.x + Random.Range(portal.x + -350f, portal.x + 350f), portal.y, portal.z + Random.Range(portal.z + -250f, portal.z + 250f));
            //Debug.Log("portal " + portal);
            //Debug.Log("point " + point);
            //Agreses = true;
            Bot_Agent.SetDestination(point);
            Bot_Agent.speed = 0.5f;
            anim.SetBool("Welk", true);
            patrlol = false;
        }
      
        if (Bot_Agent.remainingDistance <= Bot_Agent.stoppingDistance + 0.5f && !patrlol)//
        {
            patrlol = true;
            anim.SetBool("Welk", false);
        }
    }


}
