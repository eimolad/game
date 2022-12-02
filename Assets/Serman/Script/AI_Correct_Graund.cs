using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AI_Correct_Graund : MonoBehaviour
{
    private NavMeshAgent Player_Agent;
    public Transform Player_Botinki;
    public LayerMask Click_On;
    public float up_obj = 0.5f;
    public float speed_down = 0.001f;
    public float set_up = -0.02f;
  
    void Start()
    {
        Player_Agent = GetComponent<NavMeshAgent>();
    }
        
    void FixedUpdate()
    {
        Ray ray = new Ray(Player_Botinki.position, -transform.up);       
        RaycastHit hit; 
        RaycastHit[] hits = Physics.RaycastAll(ray, 1f);

        foreach (RaycastHit itm in hits)
        {
            if (itm.collider.gameObject.layer == 3)
            {
                hit = itm;
             
                if (itm.distance - up_obj > set_up)
                {
                    Player_Agent.baseOffset -= speed_down;
                }
                
                if (itm.distance - up_obj < set_up)
                {
                    Player_Agent.baseOffset += speed_down;
                }
            }
        }
    }
}
