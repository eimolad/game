using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attach_Socket : MonoBehaviour
{
    GameObject Socket;
    public string Name_Socket_Search;
    public Vector3 Position;
    public Vector3 Rotation;
    void Start()
    {
        Socket = GameObject.FindWithTag(Name_Socket_Search);
        gameObject.transform.SetPositionAndRotation(Socket.transform.position, Socket.transform.rotation);
        gameObject.transform.SetParent(Socket.transform);
        //Debug.Log(Socket.name);
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.SetPositionAndRotation(Socket.transform.position, Socket.transform.rotation);
    }
}
