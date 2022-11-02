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
        Player_Attack = Player_Hero.GetComponent<Player_Attack>(); // ������ �����
        portal = transform.position;
        Contur = GetComponent<Outline>();
        Contur.enabled = false;
        //Debug.Log(portal);
    }
    private void OnMouseDown()
    {
        Player_Attack.Attack_Click(gameObject);// �������� ������ ������ �� �������� ��� ����
        GO = true;
        start = true;
        Go_Portal = false;
    }
    void OnMouseEnter()
    {
        Contur.enabled = true;// �������� ������ �������� �������
    }
    private void OnMouseExit()
    {
        Contur.enabled = false;// ��������� ������ �������� �������
    }
    void Update()
    {
        if (!Go_Portal && Bot_Agent.enabled) transform.LookAt(Player_Hero.transform.position);// ������� � ������� ������


        Go_in_Hero();
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
        if (GO)
        {
            if (!Go_Portal)
            {
                Bot_Agent.SetDestination(Player_Hero.transform.position);// ����� �� ������
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
                    //Go_Portal = false;
                    count = 0;

                }
            }
        }
        if (dist > 5 && Stop) GO = true; // ���� �� ����� ������� ���������, �� ����� �� ���

        if (dist > 2 && !GO)
        {
            //Debug.Log("������� �����");
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Huck", false);
        }

        if (dist_portal > 20 && start) // ���� ������ ������, ������� � ����
        {
            //Debug.Log("������ �� �������");
            Go_Portal = true;
        }

        if (dist_portal < 3 && Go_Portal) // ������� � �������
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
            //Debug.Log("�������� � �������");            
        }
    }
    void Agressive_Attack()
    {
        transform.LookAt(Player_Hero.transform.position);// ������� � ������� ������
        var dist = Vector3.Distance(transform.position, Player_Hero.transform.position); // ��������� �� �����
        if (dist <= Distance_Plaer)
        {
            Bot_Agent.SetDestination(Player_Hero.transform.position);// ����� �� ������            
        }
        else
        {
            Bot_Agent.SetDestination(portal);// ������� � �������
            GO = false;
        }
        if (Bot_Agent.remainingDistance <= Bot_Agent.stoppingDistance + 0.5f && Stop)//
        {

        }
    }
}
