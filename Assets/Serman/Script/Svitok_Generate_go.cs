using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Svitok_Generate_go : MonoBehaviour
{
    Vector3 Scale;
    Transform ABC;
    public float Min_X;
    public float Max_X;
    public float Min_Z;
    public float Max_Z;
    private GameObject[] Scroll;
    public GameObject Perimeter;
    public int count_name = 0;
    private bool Stop = true;
    //GameObject Canvas_Game;

    void Start()
    {
        Scale = Perimeter.transform.lossyScale;
        Scale = Scale / 2;
        ABC = Perimeter.transform;
        Min_X = ABC.position.x - Scale.x;
        Max_X = ABC.position.x + Scale.x;
        Min_Z = ABC.position.z - Scale.z;
        Max_Z = ABC.position.z + Scale.z;
        Scroll = GameObject.FindGameObjectsWithTag("NFT");
        //Debug.Log(Scroll[0].name);
        Debug.Log("запускаю генерацию свитков");
    }


    void Update()
    {
        if (count_name < 4)
        {
            if (Scroll[0].GetComponent<Svitok_point>().myAgent.remainingDistance <= Scroll[0].GetComponent<Svitok_point>().myAgent.stoppingDistance + 0.01f && Stop)//
            {
                //Debug.Log(Vector3.Distance(scroll_vector[i], scroll_vector[obj_count]));
                for (int i = 0; i < Scroll.Length; i++)
                {
                    if (Vector3.Distance(Scroll[count_name].transform.position, Scroll[i].transform.position) < 1900)
                    {
                        Scroll[count_name].transform.position = new Vector3(Random.Range(Min_X, Max_X), 0, Random.Range(Min_Z, Max_Z));
                    }
                    else
                    {
                        //Thread.Sleep(200);
                        if (count_name < 4) count_name += 1;
                        //Debug.Log(count_name);
                        //Stop = false;
                    }
                }
            }
        }
        else
        {
            Stop = false;
            for(int i = 0; i < Scroll.Length; i++)
            {
                gameObject.GetComponent<VALUE>().scroll_vector[i] = Scroll[i].transform.position;
            }
            GetComponent<VALUE>().Save_Svitok_Vector();
            GetComponent<Svitok_Generate_go>().enabled = false;
        }      
    }
}
