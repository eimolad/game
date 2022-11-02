using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect_Clothe : MonoBehaviour
{
    
    void Start()
    {
      var obj = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in obj)
        {
           var take = player.GetComponent<Add_Body_Kit>();
            take.StartCoroutine(take.Clothe(gameObject));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
