using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROW_OBJ : MonoBehaviour
{
    public float speed = 100f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
    }
}
