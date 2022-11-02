using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animation : MonoBehaviour
{
    private Animator animator;
    float Time_Play_Anim = 5f;
    RectTransform MyRectTransform;
    void Start()
    {
        MyRectTransform = GetComponent<RectTransform>();
        animator = GetComponentInChildren<Animator>();
    }

    public void End_Anim()
    {
        Time_Play_Anim = 5f;
        gameObject.GetComponent<Animator>().enabled = false;
        MyRectTransform.localPosition = Vector3.zero;       
        MyRectTransform.sizeDelta = new Vector2(780f,960f);
        gameObject.SetActive(false);
        //Debug.Log("!!!!!");
    }

    void Update()
    {
       
        if (Time_Play_Anim <= 0)
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }
        Time_Play_Anim -= Time.deltaTime;

    }
}
