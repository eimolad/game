using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_RotateAround : MonoBehaviour
{
   
    bool Click_Mouse = false;
    public float Rotation_offset = 0f;
    float old_Pow;
    private Vector3 row;
    public float speed_row = 0.5f;
  
    void Start()
    {
       
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) Click_Mouse = true;
        if (Input.GetMouseButtonUp(0)) Click_Mouse = false;
       
        if (Click_Mouse)
        {
            row = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            Vector3 newPow = Camera.main.ScreenToWorldPoint(row);
           
            if(newPow.x < old_Pow)
            {
                Rotation_offset = Rotation_offset + 5f;
            }
            if (newPow.x > old_Pow)
            {
                Rotation_offset = Rotation_offset - 5f;
            }
            transform.rotation = Quaternion.Euler(transform.rotation.x, Rotation_offset, transform.rotation.z);
            old_Pow = newPow.x;
            //Debug.Log(newPow.x);
        }
        else
        {
            Rotation_offset += speed_row;
            transform.rotation = Quaternion.Euler(transform.rotation.x, Rotation_offset, transform.rotation.z);
        }
    }
}