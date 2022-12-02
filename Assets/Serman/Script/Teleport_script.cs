using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_script : MonoBehaviour
{
    Outline Contur;
    GameObject Canvas;
    GameObject Player;
    void Start()
    {
        Contur = GetComponent<Outline>();
        Contur.enabled = false;
        Canvas = GameObject.Find("Canvas_Game");
        Canvas.GetComponent<VALUE>().Teleport_Dictionary.Add(gameObject.name, transform.position);
        Player = GameObject.Find("Hero Variant");
    }
    void OnMouseEnter()// включаем скрипт подсвети объекта
    {
        Contur.enabled = true;        
    }
    private void OnMouseExit()// выключаем скрипт подсвети объекта
    {
        Contur.enabled = false;
    }
    private void OnMouseDown()
    {
        Player.GetComponent<Player_move_controller>().Click_Go_to_obj(transform.position);
    }
    void Update()
    {
        
    }
}
