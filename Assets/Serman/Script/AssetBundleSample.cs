using System;
using UnityEngine;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;

public class AssetBundleSample : MonoBehaviour
{
    public GameObject Point_Start;
    GameObject Progress_Bar;
    public GameObject Progress_Bar2;
    public GameObject Button_Menu;
    public GameObject Text1, Text2, Text3;
    public int Count_Bundle = 0;


    public int[] Obj_List;
    public List<int> Obj_List2;
    public int Count_Load_Server = 1;
    int Cout_Reqvest = 0;
    int Count_Bar = 0;
    bool Reload = true;
    bool button = true;
    float Interval_Bar = 0;
    float Bar = 0;
    public List<string> All_obj = new List<string>();

    [Obsolete]
    void Start()
    {
        Obj_List = new int[Count_Bundle];

        //Obj_List2 = Search_Point_start.GetComponent<Json_Controller>().

        for (int i = 0; i < Count_Bundle; i++)
        {
            Obj_List[i] = i;
        }
        //Dinamic_Load_Bundle();
        Interval_Bar = 1f / Obj_List.Length;
        //Debug.Log("интервал " + Bar);
        Progress_Bar = GameObject.FindWithTag("progress");
        //Progress_Bar.GetComponent<Image>().fillAmount = 0;
        Count_Load_Server = UnityEngine.Random.Range(1, 10000);
        reload_bandle(0);
    }

    [Obsolete]
    public void Dinamic_Load_Bundle()
    {
        Obj_List = new int[Obj_List2.Count]; 
        for (int i = 0; i < Obj_List2.Count; i++)
        {
            Obj_List[i] = Obj_List2[i];
        }
        reload_bandle(0);

        //Caching.CleanCache();
        //WWW www = WWW.LoadFromCacheOrDownload(url: $"https://e-intellect.ru/Bundle/" + name + ".unity3d", Count_Load_Server);//.unity3d
        //yield return www;

        //AssetBundle assetBundle = www.assetBundle;
        //Point_Start = assetBundle.LoadAsset(name.ToString(), typeof(GameObject)) as GameObject;
        //Instantiate(assetBundle.mainAsset);
        //Count_Load_Server++;


    }



    [Obsolete]
    private IEnumerator Load_Bundle2(int count)
    {
        if (Reload)
        {
            if (Obj_List.Length > count)
            {
                //Debug.Log("Запрашиваю файл - " + $"https://yzqe4-zyaaa-aaaan-qadaq-cai.raw.ic0.app/?asset={Convert.ToString(Obj_List[count])}");
                Debug.Log("Запрашиваю файл - " + $"https://yzqe4-zyaaa-aaaan-qadaq-cai.raw.ic0.app/?asset={Convert.ToString(Obj_List[count])}");

                // ссылка для теста  "https://e-intellect.ru/Bundle/" + Obj_List[count] + ".unity3d", Count_Load_Server
                // ссылка на канистру  "https://yzqe4-zyaaa-aaaan-qadaq-cai.raw.ic0.app/?asset={Obj_List[count]}", Count_Load_Server

                WWW www = WWW.LoadFromCacheOrDownload(url: $"http://test.e-intellect.ru/Bundle/{Obj_List[count]}"+ ".unity3d", Count_Load_Server);//.unity3d
                yield return www;

                AssetBundle assetBundle = www.assetBundle;

                Debug.Log(assetBundle);
                if (assetBundle == null)
                {
                    Debug.Log("пришло null");
                    //yield return new WaitForSeconds(1);
                    reload_bandle(count);
                    Count_Load_Server++;
                }
                if (!GameObject.Find(assetBundle.mainAsset.name + "(Clone)"))
                {
                    All_obj.Add(assetBundle.mainAsset.name);
                    Point_Start = assetBundle.LoadAsset(Obj_List[count].ToString(), typeof(GameObject)) as GameObject;
                    Instantiate(assetBundle.mainAsset);
                }
                Debug.Log("Загрузка " + assetBundle.mainAsset.name);
                if (assetBundle.Contains(assetBundle.mainAsset.name))
                {
                    Debug.Log("файл получен ++ " + count);
                    count++;
                    Count_Load_Server++;
                    assetBundle.Unload(false);
                    www.Dispose();
                    //yield return new WaitForSeconds(1);
                    reload_bandle(count);
                    //    yield break;
                    //}

                }
            }

        }

    }

    [Obsolete]
    void reload_bandle(int now_count_bandle)
    {
        if (Reload)
        {
            Caching.CleanCache();
            StartCoroutine(Load_Bundle2(now_count_bandle));
        }
    }

    [Obsolete]
    void Update()
    {
        Progress_Bar_Load();
        //if(Input.GetButtonDown("Fire1") && button)
        //{
        //    Caching.CleanCache();
        //    StopAllCoroutines();
        //    StartCoroutine(Load_Bundle2(Cout_Reqvest));
        //    Cout_Reqvest++;
        //    //Count_Load_Server++;
        //    button = false;
        //}
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    button = true;
        //}
    }

    [Obsolete]
    void Progress_Bar_Load()
    {
        if (Count_Bar < All_obj.Count)
        {
            Count_Bar += 1;
            Bar += Interval_Bar;
            Progress_Bar.GetComponent<Image>().fillAmount = Bar;
        }
        if (All_obj.Count == Obj_List.Length - 1)
        {
            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Progress_Bar2.SetActive(false);
            Progress_Bar.SetActive(false);
            Button_Menu.SetActive(true);
            Reload = false;
        }

    }

}