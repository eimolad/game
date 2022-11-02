using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_SET : MonoBehaviour
{
     List<string> Name_materials = new List<string>();
     List<Material> list_materials = new List<Material>();
    void Start()
    {
        var mat = gameObject.GetComponent<Json_Controller>();
        mat.Load_Material();
        Name_materials = mat.mat_root.list;
        list_materials = mat.mat_root.materials;
    }

    public void Set_obj(GameObject obj)
    {
        for(int i = 0; i < Name_materials.Count; i++)
        {
            if (obj.name.Replace("(Clone)", "") == Name_materials[i])
            {
                var mat = obj.GetComponent<MeshRenderer>().sharedMaterials;
                for(int f = 0; f < mat.Length; f++)
                {
                    mat[f] = list_materials[i+f];
                }
                obj.GetComponent<MeshRenderer>().sharedMaterials = mat;
                break;
            }
        }
    }


    void Update()
    {

    }
}
