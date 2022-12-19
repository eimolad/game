
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
        Player_Attack = Player_Hero.GetComponent<Player_Attack>(); // ������ �����
        portal = transform.position;
        Contur = GetComponent<Outline>();
        Contur.enabled = false;
        //Debug.Log(portal);
    }
    private void OnMouseDown()
    {
        Player_Attack.Attack_Click(gameObject);// �������� ������ ������ �� �������� ��� ����
        //Stop = true;
        //GO = true;
        //start = true;
        //Go_Portal = false;
    }
    void OnMouseEnter()
    {
        Contur.enabled = true;// �������� ������ �������� �������
    }
    private void OnMouseExit()
    {
        Contur.enabled = false;// ��������� ������ �������� �������
    }

    public void Help_Brathers()
    {
        GO = true;
        start = true;
        Go_Portal = false;
        //Debug.Log("��������");
        Obstacle_skript.enabled = true;
        Bot_Agent.SetDestination(Player_Hero.transform.position);// ����� �� ������
        Obstacle_skript.SetDestination(Player_Hero.transform.position);
        Agreses = true;
    }
    void FixedUpdate()
    {
        if (!Go_Portal && Bot_Agent.enabled && Agreses) transform.LookAt(Player_Hero.transform.position);// ������� � ������� ������
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
        var dist = Vector3.Distance(transform.position, Player_Hero.transform.position); // ��������� �� �����
        var dist_portal = Vector3.Distance(transform.position, portal); // ��������� �� �������

        if (dist < 3 && !Agreses)
        {
           if(Player_Hero.GetComponent<Player_Attack>().Agresiya)// ���� ����� ���������� � �����
            {
                Help_Brathers();
            }
        }

        if (GO)
        {
            if (!Go_Portal)
            {
                Bot_Agent.speed = 2f;
                Bot_Agent.SetDestination(Player_Hero.transform.position);// ����� �� ������
                Obstacle_skript.SetDestination(Player_Hero.transform.position);
            }
            else
            {
                Bot_Agent.SetDestination(portal);// ����� � �������
            }
            Bot_Agent.isStopped = false;
            anim.SetBool("Run", true);
            Stop = true;
            //Debug.Log("�������");

            if (Bot_Agent.remainingDistance <= Bot_Agent.stoppingDistance + 0.02f && GO)
            {
                count++;
                if (count > 10)
                {
                    //Debug.Log("��������, ������");
                    anim.SetBool("Run", false);
                    anim.SetBool("Attack", true);
                    Bot_Agent.isStopped = true;
                    GO = false;
                    Stop = true;
                    count = 0;

                }
            }
        }
        if (dist > 2.5f && Stop) GO = true; // ���� �� ����� ������� ���������, �� ����� �� ���

        if (dist > 2 && !GO)
        {
            //Debug.Log("������� �����");
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Huck", false);
        }

        if (dist_portal > 40 && start) // ���� ������ ������, ������� � ����
        {
            //Debug.Log("������ �� �������");
            Bot_Agent.speed = 2f;
            Obstacle_skript.enabled = false;
            Obstacle.enabled = false;
            Bot_Agent.enabled = true;
            Go_Portal = true;
        }

        if (dist_portal < 3 && Go_Portal) // ������� � �������
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
            //Debug.Log("�������� � �������");            
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
