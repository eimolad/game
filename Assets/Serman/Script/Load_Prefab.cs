using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Load_Prefab : MonoBehaviour
{
    //public GameObject Hero;
    //public string[] Obj_List = new string[] { "Terrain", "Rocks", "Props", "Structures", "Hero" };
    void Start()
    {

        
        string dir = Path.Combine(@"C:\Bundles\");// путь к бандлам  C:\Bundles\

        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "0"));
        //var myLoadedAssetBundle = AssetBundle.LoadFromFile(dir);

        //AssetBundleCreateRequest myLoadedAssetBundle = AssetBundle.LoadFromFileAsync(dir);
        //yield return myLoadedAssetBundle;

        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        Object[] obj = myLoadedAssetBundle.LoadAllAssets<GameObject>(); // Загружаем и помещаем в массив
        //Создано
        foreach (Object o in obj)
        {
            Instantiate(o);
        }

        //var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("0.unity3d");
        //Instantiate(prefab);

        //myLoadedAssetBundle.Unload(false);

        //for (int i = 0; i < Obj_List.Length; i++)
        //{
        //    GameObject instance = Instantiate(Resources.Load(Obj_List[i], typeof(GameObject))) as GameObject;
        //}
        ////Hero = GameObject.Find("Hero");
        ////Debug.Log(Hero);
        ////Hero.SetActive(true);
        //GameObject instance2 = Instantiate(Resources.Load("Hero", typeof(GameObject))) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
