using UnityEngine;
using System.Collections;
using UnityEditor;

public class Cursor_Mouse : MonoBehaviour
{
    //[CustomEditor(typeof(ScriptName))]

    private float range = 0.0f;

    void OnGUI()
    {
        range = range + Time.deltaTime;

        if (range > 0.1f)
        {
            Event e = Event.current;
            //Debug.Log(e.mousePosition);
            range = 0.0f;
        }
    }
    public void Mouse_Cursor_Block()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Screen.fullScreen = !Screen.fullScreen;
    }
    void Start()
    {
        //OnGUI();
        //Cursor.visible = false;
        Mouse_Cursor_Block();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
