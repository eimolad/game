using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public KeyCode ������_������;
    public GameObject container;


    void Update()
    {
        if (Input.GetKey(������_������) && container.transform.Find("UIitem") != null)
        {
            container.transform.Find("UIitem").GetComponent<Button>().onClick.Invoke();
        }

    }
}
