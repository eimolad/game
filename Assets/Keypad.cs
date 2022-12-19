using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public KeyCode Назнач_кнопку;
    public GameObject container;


    void Update()
    {
        if (Input.GetKey(Назнач_кнопку) && container.transform.Find("UIitem") != null)
        {
            container.transform.Find("UIitem").GetComponent<Button>().onClick.Invoke();
        }

    }
}
