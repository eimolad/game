using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROW_OBJ : MonoBehaviour
{
  
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, 100f * Time.deltaTime, 0, Space.World);
    }
}
