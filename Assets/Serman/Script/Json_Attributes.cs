using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Json_Controller;

public class Json_Attributes : MonoBehaviour
{
    VALUE val;
    void Start()
    {
        val = new VALUE();
        val = GetComponent<VALUE>();

        string read_file = "{\"experience\": 100,\r\n\"level\": 1,\r\n\"strength\": 50,\r\n\"attack\" : 50,\r\n\"st_resist\" : 5,\r\n\"hp_regen\" : 2.5,\r\n\"dexterity\" : 30,\r\n\"attack_speed\" : 30,\r\n\"evasion\" : 3,\r\n\"accuracy\" : 3,\r\n\"intelligence\" : 40,\r\n\"m_attack\" : 40,\r\n\"mp_regen\" : 2,\r\n\"move_speed\" : 80,\r\n\"initial_attack_speed\" : 600,\r\n\"initial_evasion\" : 0,\r\n\"initial_accuracy\" : 70,\r\n\"critical_chance\" : 0,\r\n\"spell_speed\" : 0,\r\n\"cooldown\" : 0,\r\n\"defence\" : 0,\r\n\"m_resist\" : 0,\r\n\"set_bonus\" : 0}";


        Load_json_Attributes(read_file);// для теста
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save_atribute()
    {
        Attributes attributes = new Attributes();
        attributes.experience = val.experience;
        attributes.level = val.level;
        attributes.strength = val.strength;
        attributes.attack = val.attack;
        attributes.st_resist = val.st_resist;
        attributes.hp_regen = val.hp_regen;
        attributes.dexterity = val.dexterity;
        attributes.attack_speed = val.attack_speed;
        attributes.evasion = val.evasion;
        attributes.accuracy = val.accuracy;
        attributes.intelligence = val.intelligence;
        attributes.m_attack = val.m_attack;
        attributes.mp_regen = val.mp_regen;
        attributes.move_speed = val.move_speed;
        attributes.initial_attack_speed = val.initial_attack_speed;
        attributes.initial_evasion = val.initial_evasion;
        attributes.initialaccuracy = val.initial_accuracy;
        attributes.critical_chance = val.critical_chance;
        attributes.spell_speed = val.spell_speed;
        attributes.cooldown = val.cooldown;
        attributes.defence = val.defence;
        attributes.m_resist = val.m_resist;
        attributes.set_bonus = val.set_bonus;
        string json = JsonUtility.ToJson(attributes);
        //File.WriteAllText(Application.streamingAssetsPath + "/JSON3.json", json);
        //GetComponent<Base_React>().Attributes(json);
    }
    public void Load_json_Attributes(string jsonString)
    {
        Attributes attributes = new Attributes();
        attributes = JsonUtility.FromJson<Attributes>(jsonString);
        val.level = attributes.level;
        val.strength = attributes.strength;
        val.strength = attributes.strength;

        val.experience = attributes.experience;// опыт
        val.level = attributes.level; // уровень
        val.strength = attributes.strength;// сила
        val.attack = attributes.attack;// атака
        val.st_resist = attributes.st_resist;
        val.hp_regen = attributes.hp_regen;// регенерация
        val.dexterity = attributes.dexterity;// ловкость
        val.attack_speed = attributes.attack_speed;// скорость атаки
        val.evasion = attributes.evasion;
        val.accuracy = attributes.accuracy;
        val.intelligence = attributes.intelligence;
        val.m_attack = attributes.m_attack;
        val.mp_regen = attributes.mp_regen;
        val.move_speed = attributes.move_speed;
        val.initial_attack_speed = attributes.initial_attack_speed;
        val.initial_evasion = attributes.initial_evasion;
        val.initial_accuracy = attributes.initialaccuracy;
        val.critical_chance = attributes.critical_chance;
        val.spell_speed = attributes.spell_speed;
        val.cooldown = attributes.cooldown;
        val.defence = attributes.defence;
        val.m_resist = attributes.m_resist;
        val.set_bonus = attributes.set_bonus;
    }

    [Serializable]
    public class Attributes
    {
        public int experience;
        public int level;
        public int strength;
        public int attack;
        public int st_resist;
        public float hp_regen;
        public int dexterity;
        public int attack_speed;
        public int evasion;
        public int accuracy;
        public int intelligence;
        public int m_attack;
        public int mp_regen;
        public int move_speed;
        public int initial_attack_speed;
        public int initial_evasion;
        public int initialaccuracy;
        public int critical_chance;
        public int spell_speed;
        public int cooldown;
        public int defence;
        public int m_resist;
        public int set_bonus;
    }
}
