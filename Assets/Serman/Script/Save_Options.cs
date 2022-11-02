using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Toggle))]
public class Save_Options : MonoBehaviour
{   
    CinemachineFreeLook PlayerCamera;
    bool Invers_X;
    bool Invers_Y;
    public Toggle Toggle_X;
    public Toggle Toggle_Y;
    public Slider slider_up;
    public Slider slider_left_right;
    public Slider Zoom;

    void Start()
    {
        PlayerCamera = GameObject.FindGameObjectWithTag("PlayerFramingCamera").GetComponent<CinemachineFreeLook>();
      
        if (PlayerPrefs.HasKey("InversX"))
        {
            Toggle_X.isOn = PlayerPrefs.GetInt("InversX") == 1 ? true : false;
            PlayerCamera.m_XAxis.m_InvertInput = PlayerPrefs.GetInt("InversX") == 1 ? true : false;
        }
        if (PlayerPrefs.HasKey("InversY"))
        {
            Toggle_Y.isOn = PlayerPrefs.GetInt("InversY") == 1 ? true : false;
            PlayerCamera.m_YAxis.m_InvertInput = PlayerPrefs.GetInt("InversY") == 1 ? true : false;
        }
        if (PlayerPrefs.HasKey("Slider_Speed_Up"))
        {
            slider_up.value = PlayerPrefs.GetFloat("Slider_Speed_Up");
            PlayerCamera.GetComponent<CameraController>().Speed_Up = slider_up.value;
        }
        if (PlayerPrefs.HasKey("Slider_Speed_left_right"))
        {
            slider_left_right.value = PlayerPrefs.GetFloat("Slider_Speed_left_right");
            PlayerCamera.GetComponent<CameraController>().Speed_left_right = slider_left_right.value;
        }
        if (PlayerPrefs.HasKey("Slider_Speed_Zoom"))
        {
            Zoom.value = PlayerPrefs.GetFloat("Slider_Speed_Zoom");
            PlayerCamera.GetComponent<CameraController>().Zoom_Speed = Zoom.value;
        }
    }
    public void Save()
    {
        PlayerCamera.m_XAxis.m_InvertInput = Toggle_X.isOn;
        PlayerCamera.m_YAxis.m_InvertInput = Toggle_Y.isOn;
        PlayerCamera.GetComponent<CameraController>().Speed_Up = slider_up.value;
        PlayerCamera.GetComponent<CameraController>().Speed_left_right = slider_left_right.value;
        PlayerCamera.GetComponent<CameraController>().Zoom_Speed = Zoom.value;
        PlayerPrefs.SetInt("InversX", Toggle_X.isOn ? 1 : 0);   
        PlayerPrefs.SetInt("InversY", Toggle_Y.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("Slider_Speed_Up", slider_up.value);
        PlayerPrefs.SetFloat("Slider_Speed_left_right", slider_left_right.value);
        PlayerPrefs.SetFloat("Slider_Speed_Zoom", Zoom.value);
    }
   
    void Update()
    {
        //PlayerCamera.GetComponent<CameraController>().Speed_Up = slider.value;
       
        //Debug.Log(slider.value);
    }
}
