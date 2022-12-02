using System.Collections;

using UnityEngine;
using UnityEngine.AI;


public class Portal_Trol : MonoBehaviour
{
    public GameObject Trol_OBJ;
    GameObject Player_Hero;
    GameObject obj;    
    bool Do_Once = true;
    public float Distance_Player = 15f;
    float Timer = 0;
    void Start()
    {
        Player_Hero = GameObject.Find("Hero Variant");
    }
    public void Reload_Trol()
    {
        //Debug.Log("рестарт троль");
        Do_Once = true;
        var blood = GameObject.FindGameObjectsWithTag("Blood");
        for(int i = 0; i < blood.Length; i++) Destroy(blood[i]);
        Destroy(obj);
        Timer = 60;
    }
    void FixedUpdate()
    {
        var dist = Vector3.Distance(transform.position, Player_Hero.transform.position);
        if(dist <= Distance_Player && Do_Once)
        {
            if(Timer <= 0 && Do_Once)
            {
                Do_Once = false;
                //Debug.Log("сработало расиояние");
                obj = Instantiate(Trol_OBJ, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                obj.GetComponent<Helt>().Portal_Obj = gameObject;               
            }
            Timer = Timer - Time.deltaTime;

        }
       
    }
}
