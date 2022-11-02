using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Svitok_point : MonoBehaviour
{
    public LayerMask Click_On;
    Vector3 Scale;
    Transform ABC;
    public float Min_X;
    public float Max_X;
    public float Min_Z;
    public float Max_Z;
    public GameObject Perimeter;
    GameObject Canvas_Game;
    public NavMeshAgent myAgent;
    public Transform Row_obj;
    bool search_vector = false;
    bool Stop = false;
    bool doonce = true;

    void Start()
    {
        Scale = Perimeter.transform.lossyScale;
        Scale = Scale / 2;
        ABC = Perimeter.transform;
        Min_X = ABC.position.x - Scale.x;
        Max_X = ABC.position.x + Scale.x;
        Min_Z = ABC.position.z - Scale.z;
        Max_Z = ABC.position.z + Scale.z;
        myAgent = GetComponent<NavMeshAgent>();
        Canvas_Game = GameObject.Find("Canvas_Game");
    }


    void Update()
    {
        Row_obj.Rotate(0, 100f * Time.deltaTime, 0, Space.World);

        if (Stop)
        {
            if (myAgent.remainingDistance <= myAgent.stoppingDistance + 0.01f && Stop)
            {
                Canvas_Game.GetComponent<VALUE>().scroll_vector[Convert.ToInt32(name.Substring(13))] = transform.position;
                Canvas_Game.GetComponent<VALUE>().Distance_check();
                //Debug.Log("свиток "+ name + " на месте");
                Stop = false;
            }
        }
        if (doonce)
        {
            Take_obj();
        }

    }
    public void point_location(Vector3 vector)
    {
        Stop = false;
        transform.position = vector;
    }
    public void random_location()
    {
        //myAgent.enabled = true;
        Scale = Perimeter.transform.lossyScale;
        Scale = Scale / 2;
        ABC = Perimeter.transform;
        Min_X = ABC.position.x - Scale.x;
        Max_X = ABC.position.x + Scale.x;
        Min_Z = ABC.position.z - Scale.z;
        Max_Z = ABC.position.z + Scale.z;
        Stop = true;
        transform.position = new Vector3(Random.Range(Min_X, Max_X), 0, Random.Range(Min_Z, Max_Z));// генерируем свиток внутри куба     
    }

    void Take_obj()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, Click_On))// задаем вектор куда идти
        {
           
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "NFT")// нажата левая кнопка мыши и это NFT
            {
                //Canvas_Game.GetComponent<VALUE>().Take_Svitok(Convert.ToInt32(name.Substring(13)), Convert.ToInt32(hit.collider.gameObject.name.Substring(13)));
                //Destroy(hit.collider.gameObject);

                //Debug.Log("klick " + Convert.ToInt32(hit.collider.gameObject.name.Substring(13)));
                //Debug.Log("name " + Convert.ToInt32(Convert.ToInt32(name.Substring(13))));
                //Canvas_Game.GetComponent<VALUE>().check = true;
                //Debug.Log(name == hit.collider.gameObject.name);
                if(name == hit.collider.gameObject.name)
                {                 
                    Debug.Log(Convert.ToInt32(name.Substring(13)));
                    Canvas_Game.GetComponent<VALUE>().Take_Svitok(Convert.ToInt32(name.Substring(13)), hit.collider.gameObject);
                    gameObject.GetComponent<Base_React>().Go("pickedUpLeather");
                }

                //doonce = false;
                //Debug.Log(hit.collider.gameObject.name);
                //if (Canvas_Game.GetComponent<VALUE>().scroll_caunt < 5)
                //{
                //    Canvas_Game.GetComponent<VALUE>().scroll_caunt += 1;
                //    Canvas_Game.GetComponent<VALUE>().scroll_vector[Convert.ToInt32(name.Substring(13))] = new Vector3(0, 0, 0);

                //    Debug.Log(Canvas_Game.GetComponent<VALUE>().scroll_caunt);
                //    Debug.Log(Canvas_Game.GetComponent<VALUE>().scroll_vector[Convert.ToInt32(name.Substring(13))]);

                //    Canvas_Game.GetComponent<VALUE>().Save_Svitok_Vector();

                //    Destroy(hit.collider.gameObject);
                //}

            }
        }
    }
}
