using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Add_Body_Kit : MonoBehaviour
{
    [SerializeField] private  GameObject body;
    [SerializeField] private  SkinnedMeshRenderer Hero_Skin;
    void Start()
    {
        
    }
    public IEnumerator Clothe(GameObject clothe)
    {
        GameObject obj = clothe;
        obj.transform.position = Hero_Skin.transform.position;
        obj.transform.SetParent(Hero_Skin.transform.parent);
        //Thread.Sleep(1000);
        SkinnedMeshRenderer[] renderers = obj.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            renderer.bones = Hero_Skin.bones;
            renderer.rootBone = Hero_Skin.rootBone;
        }
        yield return null;
    }

    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    GameObject obj = Instantiate<GameObject>(body);
        //    obj.transform.position = Hero_Skin.transform.position;
        //    obj.transform.SetParent(Hero_Skin.transform.parent);
        //    SkinnedMeshRenderer[] renderers = obj.GetComponentsInChildren<SkinnedMeshRenderer>();

        //    foreach (SkinnedMeshRenderer renderer in renderers)
        //    {
        //        renderer.bones = Hero_Skin.bones;
        //        renderer.rootBone = Hero_Skin.rootBone;
        //    }

        //}
    }
}
