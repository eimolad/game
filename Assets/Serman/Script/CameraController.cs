using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook playerFramingCamera;
    [SerializeField] GameObject freeLookCamera;
    CinemachineFreeLook freeLookComponent;
    float zoom = 60f;
    bool zoom_row_pluse = true;
    bool zoom_row_minus = true;
    public float Speed_Up = 2f;
    public float Speed_left_right = 130f;
    public float Zoom_Speed = 3f;

    private void Awake()
    {
        freeLookComponent = freeLookCamera.GetComponent<CinemachineFreeLook>();
        //playerControllerScript = GetComponent<PlayerController>();
       
    }
    private void Start()
    {
        playerFramingCamera = GameObject.FindGameObjectWithTag("PlayerFramingCamera").GetComponent<CinemachineFreeLook>();
    }
    public void X_Row(bool x)
    {
        freeLookComponent.m_XAxis.m_InvertInput = x;
    }
    public void Y_Row(bool y)
    {
        freeLookComponent.m_YAxis.m_InvertInput = y;
    }
    private void Update()
    {
        //transform.LookAt(2 * transform.position - playerFramingCamera.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            freeLookComponent.m_YAxis.m_MaxSpeed = Speed_Up;
            freeLookComponent.m_XAxis.m_MaxSpeed = Speed_left_right;
        }
        if (Input.GetMouseButtonUp(0))
        {
            freeLookComponent.m_YAxis.m_MaxSpeed = 0;
            freeLookComponent.m_XAxis.m_MaxSpeed = 0;
        }
        //if (Input.mouseScrollDelta.y != 0)
        //{
        //    //freeLookComponent.m_YAxis.m_MaxSpeed = 10;
        //}
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom_row_pluse) zoom += Zoom_Speed;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom_row_minus) zoom -= Zoom_Speed;

        if (zoom < 70)
        {
            zoom_row_pluse = true;
        }
        else zoom_row_pluse = false;

        if (zoom > 25)
        {
            zoom_row_minus = true;
        }
        else zoom_row_minus = false;

        freeLookComponent.m_Lens.FieldOfView = zoom;
    }
}
