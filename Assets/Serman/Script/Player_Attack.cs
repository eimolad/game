using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    private static int ANIMATOR_PARAM_Idle= Animator.StringToHash("Idle");    
    private static int ANIMATOR_PARAM_WALK = Animator.StringToHash("WalkSpeed");
    private static int ANIMATOR_PARAM_Attack = Animator.StringToHash("Attack");
    private Animator anim;
    GameObject Enemy;
    public bool Stop_attack = true;
    public bool Huck_attack = false;
    float dist;
    public ParticleSystem Particle_Sword;
    AudioSource Fite_Aux;
    AudioSource Huck_Aux;
    VALUE VAL;

    void Start()
    {
        anim = GetComponent<Animator>();
        Fite_Aux = GameObject.Find("fight").GetComponent<AudioSource>();
        Huck_Aux = GameObject.Find("Huck_hero").GetComponent<AudioSource>();
        VAL = GameObject.Find("Canvas_Game").GetComponent<VALUE>();
        //var particleObject = GetComponent<ParticleSystem>();
        //Debug.Log(Particle_Sword.name);
        //Particle_Sword.Play();
        Huck_Aux.Stop();
        Particle_Sword.Stop();

    }
    public void Attack_Click(GameObject obj)
    {
        //Debug.Log(obj.name);
        Enemy = obj;
        //obj.GetComponent<Helt>().Player_Hero = gameObject;
        gameObject.GetComponent<Player_move_controller>().Go_in_Obj(obj); // передаем объект в контроллер игрока
        transform.LookAt(Enemy.transform.position);// поворот в сторону врвга
    }
    
    void Update()
    {
        //transform.LookAt(Enemy.transform.position);// поворот в сторону врвга
        if(Enemy != null)
        {
            dist = Vector3.Distance(transform.position, Enemy.transform.position); // дистанция до врага
            if (dist < 1.5 && Stop_attack)
            {
                //Debug.Log(dist);
                anim.SetFloat(ANIMATOR_PARAM_Idle, 2);
                anim.SetFloat(ANIMATOR_PARAM_Attack, 0);
                anim.SetBool("Huck", false);
                //Enemy.GetComponent<Helt>().Attack();
                //Stop_attack = false;

            }
        }  
    }
    public void Attack_Hero()// атакуем врага (вызов из анимации)
    {
        Enemy.GetComponent<Helt>().Attack();
        //GetComponent<AudioSource>().Play();
        //Debug.Log("атакую");
    }
    public void End_Anim_Attack()// конец анимации атаки (вызов из анимации)
    {
        //Particle_Sword.Stop();
        //Debug.Log("stop");
    }
    public void Run_Hero()// герой побежал
    {
        Particle_Sword.Stop();
    }
    public void Sound_play()// (вызов из анимации)
    {
        Particle_Sword.Play();
        Fite_Aux.Stop();
        Fite_Aux.Play();
    }
    private void OnTriggerEnter(Collider other) // пересекло коллайдер
    {
        if (other.CompareTag("Weapon1") && Huck_attack)// попали мечем по герою
        {
            //Debug.Log(other.gameObject.name);
            if(VAL.HP > 0) VAL.HP -= 10;
            Particle_Sword.Stop();
            Fite_Aux.Stop();
            Huck_Aux.Play();
            Huck_attack = false;
            anim.SetBool("Huck", true);// анимация повреждения
        }
           
    }
    //public void Huck()//
    //{
    //    Particle_Sword.Stop();
    //    anim.SetBool("Huck", false);
    //    Fite_Aux.Stop();       
    //}
    public void Stpo_Attack()
    {
        //Debug.Log("STOP");
        Stop_attack = false;    
        anim.SetBool("Huck", false);
        anim.SetFloat(ANIMATOR_PARAM_Idle, 0);
        anim.SetFloat(ANIMATOR_PARAM_WALK, 0);
        Particle_Sword.Stop();
        Fite_Aux.Stop();
        //Stop_attack = false;
    }
}
