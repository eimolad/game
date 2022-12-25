using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charachter_mob : MonoBehaviour
{
    public float Cur_HP;
    public float HP;
    public float Cur_MP;
    public float MP;

    public int experience;// опыт
    public int level; // уровень
    public int strength;// сила
    public int attack;// атака
    public int st_resist;
    public float hp_regen;// регенерация
    public int dexterity;// ловкость
    public int attack_speed;// скорость атаки
    public int evasion;
    public int accuracy;
    public int intelligence;
    public int m_attack;
    public int mp_regen;
    public int move_speed;
    public int initial_attack_speed;
    public int initial_evasion;
    public int initial_accuracy;
    public int critical_chance;
    public int spell_speed;
    public int cooldown;
    public int defence;
    public int m_resist;
    public int set_bonus;
    float TimeDelay = 1;
    float TimeDelayHp;
    float TimeDelayMp;
    public int cur_experience;
    void Start()
    {
        Cur_HP = 500f;
        Cur_MP = 500f;
        cur_experience = 0;
        experience = 100;
        strength = 50;
        dexterity = 30;
        intelligence = 40;
    }


    void Update()
    {
        //Debug.Log(Cur_HP);

        if (cur_experience >= experience)
        {
            level++;
            cur_experience = 0;
            strength += Convert.ToInt32(Math.Ceiling(strength * 0.04f));
            dexterity += Convert.ToInt32(Math.Ceiling(dexterity * 0.02f));
            intelligence += Convert.ToInt32(Math.Ceiling(intelligence * 0.03f));
            experience = experience * 2;
        }
        HP = 10 * strength;
        MP = 10 * intelligence;
        attack = strength;
        m_attack = intelligence;
        attack_speed = dexterity;
        hp_regen = 0.05f * strength;
        mp_regen = (int)(0.05 * intelligence);
        if (Cur_HP < HP)
        {
            TimeDelayHp += Time.deltaTime;
            if (TimeDelayHp >= TimeDelay)
            {
                Cur_HP += hp_regen;
                TimeDelayHp = 0;
                if (Cur_HP >= HP) Cur_HP = HP;
            }
        }
        if (Cur_MP < MP)
        {
            TimeDelayMp += Time.deltaTime;
            if (TimeDelayMp >= TimeDelay)
            {
                Cur_MP += mp_regen;
                //cur_experience += 10;
                TimeDelayMp = 0;
                if (Cur_MP >= MP) Cur_MP = MP;
            }
        }

        if (strength / 10 > 50) st_resist = 50;
        else st_resist = strength / 10;
        if (dexterity / 10 > 50) evasion = 50;
        else evasion = dexterity / 10;
        if (dexterity / 10 > 100) accuracy = 100;
        else accuracy = dexterity / 10;
    }
}
