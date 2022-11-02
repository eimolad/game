using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Test_json : MonoBehaviour
{
    public Root root;
    Dictionary<string, string> dict = new Dictionary<string, string>();
    void Start()
    {
        Vector3[] V = new Vector3[0];
        Vector3[] V2 = new Vector3[5];
        root.aid = "123";
        root.equipment = new List<int> { 1,2,2,5,3 };
        root.name = "name";
        root.experience = "0";
        root.charId = "0";
        root.quest = new List<string>();
        //root.quest.Add(new Quest(1, 1, "false", 0, V));
        //root.quest.Add(new Quest(0, 0, "", 3, V2));
        //object[] obj = new object[2];
        //obj[0] = new Quest(1, 1, "false");
        //obj[1] = new Quest2(2, V2);
        //string q = JsonUtility.ToJson(new Quest(1, 1, "false"));
        //string qq = JsonUtility.ToJson(new Quest2(2, V2));
        //root.quest.Add(JsonUtility.ToJson(new Quest(1, 1, "false")));
        //root.quest.Add(JsonUtility.ToJson(new Quest2(2, V2)));
        Debug.Log(root.quest.Count);

        string json = JsonUtility.ToJson(root);

        string Out_mess = "{\"aid\":\"" + root.aid + "\","+ "\"equipment\":[" + root.equipment[0] +"," + root.equipment[1] + "," + root.equipment[2] + "," + root.equipment[3] + "," + root.equipment[4] + "]," +
            "\"name\":\"" + root.name+ "\","+"\"quest\":[{\"" +"questStep\":"+ 0+","+"\"dialog_count\":"+ 0+","+ "\"recipe\":\""+ root.name+"\"},{\"scroll\":"+3+",\"vector\":[{\"x\":"+ V2[0].x +",\"y\":"+ V2[0].y +",\"z\":" + V2[0].z + "},{\"x\":"+ V2[1].x +",\"y\":"+ V2[1].y +",\"z\":" + V2[1].z + "}," +
            "{\"x\":"+ V2[2].x +",\"y\":"+ V2[2].y +",\"z\":" + V2[2].z + "},{\"x\":"+ V2[3].x +",\"y\":"+ V2[3].y +",\"z\":" + V2[3].z + "},{\"x\":"+ V2[4].x +",\"y\":"+ V2[4].y +",\"z\":" + V2[4].z + "}]}],\"experience\":\""+ root.experience+ "\",\"charId\":\""+root.charId+"\"}";
        
        Debug.Log(json);
        File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", Out_mess);// JsonUtility.ToJson(root)
       
    }
    [Serializable]
    public class Root
    {
        public string aid;
        public List<int> equipment;
        public string name;
        public List<string> quest;
        //public Dictionary<Quest,Quest2> quest;
        public string experience;
        public string charId;
    }
    [Serializable]
    public class Quest
    {
        public int questStep;
        public int dialog_count;
        public string recipe;
        //public int scroll;
        //public Vector3[] vector;

        public Quest (int questStep, int dialog_count, string recipe)
        {
            this.questStep = questStep;
            this.dialog_count = dialog_count;
            this.recipe = recipe;
            //this.scroll = scroll;
            //this.vector = vector;
        }
    }
    public class Quest2
    {  
        public int scroll;
        public Vector3[] vector;

        public Quest2( int scroll, Vector3[] vector)
        {            
            this.scroll = scroll;
            this.vector = vector;
        }
    }
}
