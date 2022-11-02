using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject obj;
    private void Start()
    {
        GetDefaultDirectory();
        CreateCustomDirectory();
    }

    // It returns "idbfs/" following with a random hash, such as "66ae5aa9b53f4a794ca331d30d2cb976".
    public void GetDefaultDirectory()
    {
        Debug.Log(Application.persistentDataPath);
    }

    // Manually create a directory
    // This can be created but will be flushed away after the page is reloaded.
    public void CreateCustomDirectory()
    {
#if UNITY_WEBGL
        string dir = "idbfs/ser";
        Directory.CreateDirectory(dir);
       
        //ExportAssetBundles foo = new ExportAssetBundles();
        //Task.Add(obj, "idbfs/ser");
#endif
    }
}
