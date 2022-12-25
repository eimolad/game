using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory_Backpack_json : MonoBehaviour
{
    Root root = new Root();
    VALUE val;
    List<string> Weapons = new List<string>();
    void Start()
    {
        val = new VALUE();
        val = GetComponent<VALUE>();
        //string test2 = File.ReadAllText(Application.streamingAssetsPath + "/Inventory_Player.json");//для теста
        string test2 = "{\r\n\"tokens\": {\r\n\"icp\": 5.12345678,\r\n\"gold\": 55,\r\n\"coal\": 0,\r\n\"ore\": 0,\r\n\"adit\": 0,\r\n\"lgs\": 0,\r\n\"leather\": 0,\r\n\"bronze\": 16,\r\n\"tp\": 5\r\n},\r\n\"items\": [\r\n{\r\n\"type\": \"equipment\",\r\n\"index\": 1227,\r\n\"collection\": \"weapons\",\r\n\"rare\": \"standart\",\r\n\"metadata\": {\r\n\"weaponType\": \"one-handed\",\r\n\"ledgerCanister\": \"n6bj5-ryaaa-aaaan-qaaqq-cai\",\r\n\"state\": \"none\",\r\n\"modelCanister\": \"n6bj5-ryaaa-aaaan-qaaqq-cai\"\r\n}\r\n},\r\n{\r\n\"type\": \"equipment\",\r\n\"index\": 120,\r\n\"collection\": \"weapons\",\r\n\"rare\": \"superrare\",\r\n\"metadata\": {\r\n\"weaponType\": \"one-handed\",\r\n\"ledgerCanister\": \"n6bj5-ryaaa-aaaan-qaaqq-cai\",\r\n\"state\": \"no\",\r\n\"modelCanister\": \"n6bj5-ryaaa-aaaan-qaaqq-cai\"\r\n}\r\n},\r\n{\r\n\"name\": \"Grenlyn’s Shield\",\r\n\"index\": 0,\r\n\"ledgerCanister\": \"6spgj-fiaaa-aaaan-qa4sa-cai\",\r\n\"id\": [\r\n\"0\"\r\n]\r\n}\r\n]\r\n}";

        Load(test2);//для теста
    }


    void Update()
    {

    }
    public void Load(string json)
    {
        root = JsonUtility.FromJson<Root>(json);

        val.Icp = root.tokens.icp;
        val.Gold = root.tokens.gold;
        val.Coal = root.tokens.coal;
        val.Ore = root.tokens.ore;
        val.Adit = root.tokens.adit;
        val.Lgs = root.tokens.lgs;
        val.Leather = root.tokens.leather;
        val.Bronze = root.tokens.bronze;
        //Debug.Log(root.items.Count);
        Object_Read_Items();
    }
    void Object_Read_Items()
    {
        for (int i = 0; i < root.items.Count; i++)
        {
            //Debug.Log(root.items[i].name);
            if (root.items[i].collection == "weapons")// если это оружие
            {
               
                Weapons.Add(Name_weapon(root.items[i].index));// добавляем имя оружия в список
                if (root.items[i].metadata.state != "none")
                {
                    val.Weapon_List_Count_num = i.ToString();// обозначаем оружие, которое в руках
                }
            }
            if (root.items[i].name == "Grenlyn’s Shield")
            {
                val.Shild_inventory.Add("Grenlyn_Shield");
            }
        }
        val.Weapon_inventory = Weapons;

    }

    string Name_weapon( int index)
    {
        if (index <= 139) return "ancient_axe";
        if (index <= 339 && index > 139) return "doom_hammer";
        if (index <= 589 && index > 339) return "mace_of_rage";
        if (index <= 614 && index > 589) return "мace_of_a_wandering_magician";
        if (index <= 764 && index > 614) return "legionnaires_sword";
        if (index <= 1064 && index > 764) return "knights_sword";
        if (index <= 1124 && index > 1064) return "assassins_sword";
        if (index <= 1224 && index > 1124) return "viking_axe";
        if (index <= 1524 && index > 1224) return "guardsmans_axe";
        if (index <= 1674 && index > 1524) return "axe_of_valor";
        if (index <= 1699 && index > 1674) return "mystic_hammer";
        if (index <= 1949 && index > 1699) return "armor_piercing_pickax";
        if (index <= 2299 && index > 1949) return "holy_halberd";
        if (index <= 2499 && index > 2299) return "mercenarys_sword";
        if (index <= 2819 && index > 2499) return "dukes_sword";
        if (index <= 2879 && index > 2819) return "the_punisher_sword";
        return "null";
    }

    public void save()
    {
        Item item = new Item();
        Root root = new Root();
        root.tokens.bronze = 800;
        root.items.Add(item);
        root.items[0].index = 100;
        root.items[0].metadata.state = "ARMOR";

        string json = JsonUtility.ToJson(root);
        //string json = JsonConvert.SerializeObject(root);
        File.WriteAllText(Application.streamingAssetsPath + "/Inventory_Player.json", json);
    }

    [Serializable]
    public class Item
    {
        public string type;
        public int index;
        public string collection;
        public string rare;
        public Metadata metadata = new Metadata();
        public string name;
        public string ledgerCanister;
        public List<string> id;
    }
    [Serializable]
    public class Metadata
    {
        public string weaponType;
        public string ledgerCanister;
        public string state;
        public string modelCanister;
    }
    [Serializable]
    public class Root
    {
        public Tokens tokens = new Tokens();
        public List<Item> items = new List<Item>();
    }
    [Serializable]
    public class Tokens
    {
        public float icp;
        public int gold;
        public int coal;
        public int ore;
        public int adit;
        public int lgs;
        public int leather;
        public int bronze;
        public int tp;
    }
}
