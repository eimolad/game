using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Load_Bundle : MonoBehaviour
{
    public List<int> Obj_List;
    Dictionary<int, int> Obj_Dictionary;

    void Start()
    {
        Obj_Dictionary = new Dictionary<int, int>();

    }
    public IEnumerator Load_Bundle_func()
    {
        //Count_Load_Server = Random.Range(1, 10000);
        // Thread.Sleep(1000);
        // ссылка для теста  "https://e-intellect.ru/Bundle/" + Obj_List[count] + ".unity3d", Count_Load_Server
        // ссылка на канистру  "https://yzqe4-zyaaa-aaaan-qadaq-cai.raw.ic0.app/?asset={Obj_List[count]}", Count_Load_Server
        //int Count_Load_Server = Random.Range(1, 10000);
        // var request = UnityWebRequestAssetBundle.GetAssetBundle(uri: $"https://yzqe4-zyaaa-aaaan-qadaq-cai.raw.ic0.app/?asset={Obj_List[count]}");



        for (int i = 0; i < Obj_List.Count; i++)
        {
            if (!Obj_Dictionary.ContainsKey(Obj_List[i]))
            {
                var request = UnityWebRequestAssetBundle.GetAssetBundle(uri: $"http://test.e-intellect.ru/Bundle/{Obj_List[i]}" + ".unity3d");
                //Debug.Log($"http://test.e-intellect.ru/Bundle/{Obj_List[i]}" + ".unity3d");
                yield return request;
                yield return request.SendWebRequest();
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                yield return Instantiate(bundle.mainAsset);
                yield return bundle.UnloadAsync(false);
                request.Dispose();
                Obj_Dictionary.Add(Obj_List[i], i);
            }
        }
    }

    void Update()
    {

    }
}
