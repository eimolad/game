using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjects_OFF_Action : MonoBehaviour
{


    public static class GameObjectExtension
    {
        public static Object Find(string name, System.Type type)
        {
            Object[] objects = Resources.FindObjectsOfTypeAll(type);
            foreach (var obj in objects)
            {
                if (obj.name == name)
                {
                    return obj;
                }
            }
            return null;
        }

        public static GameObject Find(string name)
        {
            return Find(name, typeof(GameObject)) as GameObject;
        }
    }

   public GameObject Seatch_not_action_obj(string name_obj)
    {
        GameObject obj = GameObjectExtension.Find(name_obj);
        if (obj)
        {
            //obj.SetActive(true);
           
        }
        return obj;
    }

}
