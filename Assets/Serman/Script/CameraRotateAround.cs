using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limit = 80; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	private float X, Y;
	bool Click_Mouse = false;

	void Start () 
	{
		//var hero = GameObject.FindWithTag("Hero");
		//target = hero.transform;
		//limit = Mathf.Abs(limit);
		//if(limit > 90) limit = 90;
		//offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax)/2);
		//transform.position = target.position + offset;
		//transform.localEulerAngles = new Vector3(-30f, 0, 0);
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(1)) Click_Mouse = true;
		if (Input.GetMouseButtonUp(1)) Click_Mouse = false;

		if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		else if(Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		if (Click_Mouse)
        {
			X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
			Y += Input.GetAxis("Mouse Y") * sensitivity;
			Y = Mathf.Clamp(Y, -45, -5);		
		}

		transform.localEulerAngles = new Vector3(-Y, X, 0);
		transform.position = transform.localRotation * offset + target.position;
	}
}