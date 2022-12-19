using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.ParticleSystem;

public class Helt : MonoBehaviour
{
    Animator anim;
    bool attack = false;
    GameObject Canvas_obj, canvas;
    int count_helt = 0;
    public GameObject Player_Hero;
    Player_Attack player_Attack_skript;
    public List<ParticleSystem> blood = new List<ParticleSystem>();
    public GameObject Portal_Obj;
    public ParticleSystem[] Fx3;
    public AudioSource Sound_attack;
    public AudioSource Sound_Huck;
    public AudioSource Sound_Death;
     ParticleSystem generatedParticle;
     ParticleSystem generatedParticle2;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);

        if (other.CompareTag("Weapon1") && attack && !other.CompareTag("Enemy"))//
        {
            //Debug.Log("Касание");
            attack = false;
            Sound_attack.Stop();
            Sound_Huck.Play();
            anim.SetBool("Huck", true);// анимация повреждения
            generatedParticle.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            generatedParticle2.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            generatedParticle.Play();
            generatedParticle2.Play();
        }       
    }
    void Start()
    {
        generatedParticle = Instantiate(Fx3[0], new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
        generatedParticle2 = Instantiate(Fx3[1], new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);

        canvas = GameObject.Find("Canvas_Game");
        Portal_Obj = new GameObject();
        anim = GetComponent<Animator>();
        Canvas_obj = GameObject.Find("Canvas_Game");
        //Blood = GameObject.Find("Blood_Vector");
        Sound_attack = GameObject.Find("monster_3").GetComponent<AudioSource>();
        Sound_Huck = GameObject.Find("monster_1").GetComponent<AudioSource>();
        Sound_Death = GameObject.Find("monster_2").GetComponent<AudioSource>();
        Player_Hero = GameObject.Find("Hero Variant");
        player_Attack_skript = Player_Hero.GetComponent<Player_Attack>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("!!!");
            //anim.SetBool("Attack", true);
            //Canvas_obj.GetComponent<Base_React>().Go("teleportUsed");
        }
        //Debug.Log(anim);        
    }
    public void Sound_Play_Attack()
    {
        Sound_attack.Play();
        player_Attack_skript.Huck_attack = true;
    }
    public void Attack()
    {
        attack = true;
       
        //anim.Play("Huck_Head_event");
    }
    public void Huck()
    {
        gameObject.GetComponent<Bot_Trol>().GO = true;
        gameObject.GetComponent<Charachter_mob>().Cur_HP = gameObject.GetComponent<Charachter_mob>().Cur_HP - canvas.GetComponent<VALUE>().attack;

        if (gameObject.GetComponent<Charachter_mob>().Cur_HP <= 0)
        { 
           Sound_attack.Stop();
            Sound_Huck.Stop();
            Sound_Death.Play();
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Huck", false);
            GetComponent<Bot_Trol>().Death();
            player_Attack_skript.Stpo_Attack();
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            //Canvas_obj.GetComponent<Base_React>().Go("pickedUpTeleport");
            GetComponent<Bot_Trol>().enabled = false;
        }        
        anim.SetBool("Huck", false);       
    }
    public void Death()
    {
        //Debug.Log("Умер");
        //Sound_attack.Stop();
        Canvas_obj.GetComponent<VALUE>().Teleport_take(1);
        Canvas_obj.GetComponent<VALUE>().cur_experience += 10;
        //Canvas_obj.GetComponent<Base_React>().Go("teleportUsed");
        gameObject.GetComponent<Collider>().enabled = false;
        player_Attack_skript.Stpo_Attack();
        anim.SetBool("Death", false);
        Portal_Obj.GetComponent<Portal_Trol>().Reload_Trol();
    }
}
