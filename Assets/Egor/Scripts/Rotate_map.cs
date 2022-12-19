using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_map : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector3 rotate_map = transform.eulerAngles;
        Vector3 rotation_player = player.transform.eulerAngles;
        rotate_map.z = rotation_player.y + 90;
        transform.rotation = Quaternion.Euler(rotate_map);
    }
}
