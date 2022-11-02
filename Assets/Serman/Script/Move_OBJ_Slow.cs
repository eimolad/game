using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_OBJ_Slow : MonoBehaviour
{
    public float speed = 0.02f;
    public float StartPos = 4000f;
    public Vector3 EndPosition;
    bool once = true;
    public int Delay = 0;
    //public int Count_Obj = 5;
    void Start()
    {
        transform.position = new Vector3(StartPos, 0f, 0f);

    }


    void Update()
    {
        if(Delay < 0)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, EndPosition, speed);
            float imprecision = 0.01f;//допустимая погрешность 

            if (transform.position.x + imprecision > EndPosition.x & transform.position.x - imprecision < EndPosition.x)
            {
                transform.position = new Vector3(EndPosition.x, EndPosition.y, EndPosition.z);
                if (once)
                {
                    var camera = GameObject.Find("Camera_Start");
                    if (camera != null && camera.activeSelf) camera.GetComponent<Swich_Camera>().Do_Once = true;
                }
            }
        }
        Delay -= 1;

        //time_delta = time_delta + Time.deltaTime;
        //Offset = Amp * Mathf.Sin(time_delta * speed);
        //transform.position = StartPos + new Vector3(Offset, 0f,0f);
    }
}
