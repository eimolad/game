using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    private string bundleURL = "https://e-intellect.ru/ser.unity3d";
    private int version = 0;
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField] GameObject My_gameObject;

    [System.Obsolete]
    public  void On_Click_Dovnload()
    {
        StartCoroutine(DownLoad());
    }

    [System.Obsolete]
    IEnumerator DownLoad()
    {
        while(!Caching.ready)        
            yield return null;
       
        var www = WWW.LoadFromCacheOrDownload(bundleURL,version);
        yield return www;
        if(!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        Debug.Log("Done");
        var assetBundle = www.assetBundle;
        string scrin = "stoun.JPG";
      
        
        var SpriteReqest = assetBundle.LoadAssetAsync(scrin, typeof(Sprite));
        yield return SpriteReqest;
        Debug.Log("НОРМ");
        spriteRenderer.sprite = SpriteReqest.asset as Sprite;
        
       
    }

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(DownLoad());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
