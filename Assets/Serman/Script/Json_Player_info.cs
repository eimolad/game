using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using static Inventory_Backpack_json;
using static Json_Controller;

public class Json_Player_info : MonoBehaviour
{
    VALUE val;
    string charId;
    string Recept_ptogress = "";
    string aid_val;

    private void Awake()
    {
        val = new VALUE();
        val = GetComponent<VALUE>();

        //string test2 = File.ReadAllText(Application.streamingAssetsPath + "/JSON.json");// для теста
        string test2 = "{\r\n    \"equipment\": [\"6\",\"2\",\"3\",\"3\",\"3\",\"null\",\"null\"],\r\n    \"name\": \"TestMode\",\r\n    \"quest\": [\r\n        {\"questStep\":0,\"dialog_count\":0,\"recipe\":\"false\"},\r\n        {\"scroll\":0, \"vector\":[]}],    \r\n    \"charId\": \"yvfl5-aikor-uwiaa-aaaaa-dmaau-4aqca-aaaii-q\",\r\n    \"position\": [0,0,0]\r\n}";
        Load_json(test2);// для теста
    }
    void Start()
    {
        //val = new VALUE();
        //val = GetComponent<VALUE>();

        ////string test2 = File.ReadAllText(Application.streamingAssetsPath + "/JSON.json");// для теста
        //string test2 = "{\r\n    \"equipment\": [\"6\",\"2\",\"3\",\"3\",\"3\",\"null\",\"null\"],\r\n    \"name\": \"TestMode\",\r\n    \"quest\": [\r\n        {\"questStep\":0,\"dialog_count\":0,\"recipe\":\"false\"},\r\n        {\"scroll\":0, \"vector\":[]}],    \r\n    \"charId\": \"yvfl5-aikor-uwiaa-aaaaa-dmaau-4aqca-aaaii-q\",\r\n    \"position\": [0,0,0]\r\n}";
        //Load_json(test2);// для теста
    }

    void Update()
    {
        
    }
    public void Load_json(string jsonString)
    {
        //Debug.Log(root.quest.Count);
       Root root = JsonUtility.FromJson<Root>(jsonString);

        aid_val = root.aid;
        val.equipment = root.equipment;// присвоить список одежды

        charId = root.charId;
        val.Player_Name = root.name;

        if (root.quest.Count > 0)
        {
            val.Dialog_count = root.quest[0].dialog_count;
            val.Step_quest = root.quest[0].questStep;
            val.scroll_caunt = root.quest[1].scroll;

            if (root.quest[1].vector.Length == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    val.scroll_vector[i] = new Vector3(0, 0, 0);
                }
            }
            else
            {
                val.scroll_vector = root.quest[1].vector;
            }

            if (root.quest[0].recipe == "true")
            {
                val.recipe = true;
                val.All_inventory.Add("Recipe");
                val.Quest_done = true;
            }
            if (root.quest[0].recipe == "false")
            {
                val.recipe = false;
                val.Quest_done = false;
            }
            if (root.quest[0].recipe.Substring(0, 4) == "http")
            {
                val.Shild = true;
                val.Quest_done = true;
            }
        }
        if (Convert.ToInt32(root.equipment[0]) == 0 || Convert.ToInt32(root.equipment[0]) == 6)
        {
            val.defence += 80;
            val.weight += 140;
        }
        if (Convert.ToInt32(root.equipment[3]) == 0)
        {
            val.defence += 15;
            val.weight += 30;
        }
        if (Convert.ToInt32(root.equipment[4]) == 0)
        {
            val.defence += 9;
            val.weight += 15;
        }
        if (Convert.ToInt32(root.equipment[0]) == 1)
        {
            val.defence += 68;
            val.weight += 100;
        }
        if (Convert.ToInt32(root.equipment[3]) == 1)
        {
            val.defence += 10;
            val.weight += 18;
        }
        if (Convert.ToInt32(root.equipment[4]) == 1)
        {
            val.defence += 5;
            val.weight += 10;
        }
        if (Convert.ToInt32(root.equipment[0]) == 2)
        {
            val.defence += 34;
            val.weight += 60;
        }
        if (Convert.ToInt32(root.equipment[3]) == 2)
        {
            val.defence += 7;
            val.weight += 10;
        }
        if (Convert.ToInt32(root.equipment[4]) == 2)
        {
            val.defence += 5;
            val.weight += 5;
        }
        if (Convert.ToInt32(root.equipment[0]) == 3)
        {
            val.defence += 40;
            val.weight += 70;
        }
        if (Convert.ToInt32(root.equipment[3]) == 3)
        {
            val.defence += 7;
            val.weight += 12;
        }
        if (Convert.ToInt32(root.equipment[4]) == 3)
        {
            val.defence += 5;
            val.weight += 6;
        }
        if (Convert.ToInt32(root.equipment[0]) == 4)
        {
            val.defence += 72;
            val.m_resist += 2;
            val.weight += 125;
        }
        if (Convert.ToInt32(root.equipment[3]) == 4)
        {
            val.defence += 12;
            val.weight += 25;
        }
        if (Convert.ToInt32(root.equipment[4]) == 4)
        {
            val.defence += 7;
            val.weight += 13;
        }
        if (Convert.ToInt32(root.equipment[0]) == 5)
        {
            val.defence += 19;
            val.m_resist += 4;
            val.weight += 40;
        }
        if (Convert.ToInt32(root.equipment[3]) == 5)
        {
            val.defence += 3;
            val.weight += 6;
        }
        if (Convert.ToInt32(root.equipment[4]) == 5)
        {
            val.defence += 3;
            val.weight += 3;
        }
        if (Convert.ToInt32(root.equipment[0]) == 0 && Convert.ToInt32(root.equipment[3]) == 0 && Convert.ToInt32(root.equipment[4]) == 0 || Convert.ToInt32(root.equipment[4]) == 6)
        {
            val.defence += 20;
            val.loot_bonus += 2;
            val.move_speed += 7 * (val.move_speed / 100);
        }
        if (Convert.ToInt32(root.equipment[0]) == 1 && Convert.ToInt32(root.equipment[3]) == 1 && Convert.ToInt32(root.equipment[4]) == 1)
        {
            val.strength += 5 * (val.strength / 100);
            val.move_speed += 5 * (val.move_speed / 100);
        }
        if (Convert.ToInt32(root.equipment[0]) == 2 && Convert.ToInt32(root.equipment[3]) == 2 && Convert.ToInt32(root.equipment[4]) == 2)
        {
            val.dexterity += 4 * (val.dexterity / 100);
            val.m_resist += 5;
            val.move_speed += 9 * (val.move_speed / 100);
        }
        if (Convert.ToInt32(root.equipment[0]) == 3 && Convert.ToInt32(root.equipment[3]) == 3 && Convert.ToInt32(root.equipment[4]) == 3)
        {
            val.dexterity += 4 * (val.dexterity / 100);
            val.attack_speed += 4 * (val.attack_speed / 100);
            val.move_speed += 9 * (val.move_speed / 100);
        }
        if (Convert.ToInt32(root.equipment[0]) == 4 && Convert.ToInt32(root.equipment[3]) == 4 && Convert.ToInt32(root.equipment[4]) == 4)
        {
            val.defence += 7;
            val.HP += 70;
            val.move_speed += 3 * (val.move_speed / 100);
        }
        if (Convert.ToInt32(root.equipment[0]) == 5 && Convert.ToInt32(root.equipment[3]) == 5 && Convert.ToInt32(root.equipment[4]) == 5)
        {
            val.MP += 40;
            val.intelligence += 4 * (val.intelligence / 100);
            val.move_speed += 13 * (val.move_speed / 100);
        }
        //if (root.equipment[0] == 6 && root.equipment[3] == 6 && root.equipment[4] == 6) Debug.Log("Set Bonus = 7");
        //val.Svitok();
        val.started_game();
    }
    public void Save_json()
    {
        Root root = new Root();
        var F = CultureInfo.InvariantCulture;
        Vector3[] V2 = new Vector3[5];
        V2 = val.scroll_vector;

        root.name = val.Player_Name;
        //root.equipment = equipment_val;
        root.charId = charId;
        //root2.experience = val.experience;
        if (val.processing) Recept_ptogress = "processing";

        root.quest.Add(new Quest(val.Step_quest, val.Dialog_count, Recept_ptogress, val.scroll_caunt, val.scroll_vector));

        string Out_mess = "{\"aid\":\"" + root.aid + "\"," + "\"equipment\":[" + root.equipment[0] + "," + root.equipment[1] + "," + root.equipment[2] + "," + root.equipment[3] + "," + root.equipment[4] + "]," +
           "\"name\":\"" + root.name + "\"," + "\"quest\":[{\"" + "questStep\":" + val.Step_quest + "," + "\"dialog_count\":" + val.Dialog_count + "," + "\"recipe\":\"" + Recept_ptogress + "\"},{\"scroll\":" + val.scroll_caunt + ",\"vector\":[{\"x\":" + V2[0].x.ToString(F) + ",\"y\":" + V2[0].y.ToString(F) + ",\"z\":" + V2[0].z.ToString(F) + "},{\"x\":" + V2[1].x.ToString(F) + ",\"y\":" + V2[1].y.ToString(F) + ",\"z\":" + V2[1].z.ToString(F) + "}," +
           "{\"x\":" + V2[2].x.ToString(F) + ",\"y\":" + V2[2].y.ToString(F) + ",\"z\":" + V2[2].z.ToString(F) + "},{\"x\":" + V2[3].x.ToString(F) + ",\"y\":" + V2[3].y.ToString(F) + ",\"z\":" + V2[3].z.ToString(F) + "},{\"x\":" + V2[4].x.ToString(F) + ",\"y\":" + V2[4].y.ToString(F) + ",\"z\":" + V2[4].z.ToString(F) + "}]}],\"position\":\"" + root.position + "\",\"charId\":\"" + root.charId + "\"}";


        //gameObject.GetComponent<Base_React>().Go(Out_mess);

        //Debug.Log(Out_mess);
        ////Debug.Log(root.quest.Count);

        //File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", Out_mess);// для тестаJsonUtility.ToJson(root)

        //Debug.Log(Out_mess2);
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //public class Quest
    //{
    //    public int questStep { get; set; }
    //    public int dialog_count { get; set; }
    //    public string recipe { get; set; }
    //    public int? scroll { get; set; }
    //    public List<object> vector { get; set; }
    //}

    //public class Root
    //{
    //    public List<string> equipment { get; set; }
    //    public string name { get; set; }
    //    public List<Quest> quest { get; set; }
    //    public string charId { get; set; }
    //    public List<int> position { get; set; }
    //}

    [Serializable]
    public class Quest
    {
        public int questStep;
        public int dialog_count;
        public string recipe;
        public int scroll;
        public Vector3[] vector;

        public Quest(int questStep, int dialog_count, string recipe, int scroll, Vector3[] vector)//, int scroll, Vector3[] vector
        {
            this.questStep = questStep;
            this.dialog_count = dialog_count;
            this.recipe = recipe;
            this.scroll = scroll;
            this.vector = vector;
        }
    }

    [Serializable]
    public class Root
    {
        public string aid;
        public List<string> equipment;
        public string name;
        public List<Quest> quest;
        public Vector3[] position;
        public string charId;

    }
}
