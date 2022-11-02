using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_LookAt : MonoBehaviour
{
    public float MouseSens = 100f;
    public Transform PlayerBody;
    float X_Rotation = 0f;
    float Y_Rotation = 0f;
    bool Click_Mouse = false;

    [SerializeField] private GameObject _object; //An object camera will follow
    [SerializeField] private Vector3 _distanceFromObject; // Camera's distance from the object
    //Event function
    private void LateUpdate() //Works after all update functions called
    {
        Vector3 positionToGo = _object.transform.position + _distanceFromObject; //Target position of the camera
        Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: positionToGo, t: 0.025F); //Smooth position of the camera
        transform.position = smoothPosition;
        if (!Click_Mouse) transform.LookAt(_object.transform.position); //Camera will look(returns) to the object
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) Click_Mouse = true;
        if (Input.GetMouseButtonUp(1)) Click_Mouse = false;

        if (Click_Mouse)
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;
            X_Rotation -= mouseY;
            X_Rotation = Mathf.Clamp(X_Rotation, -90f, 90f);
            Y_Rotation -= mouseX;
            Y_Rotation = Mathf.Clamp(-90f,Y_Rotation , 90f);

            transform.localRotation = Quaternion.Euler(X_Rotation, Y_Rotation, 0f);
            PlayerBody.Rotate(Vector3.up * mouseX);
            PlayerBody.Rotate(Vector3.left * mouseY);
        }

    }
}
