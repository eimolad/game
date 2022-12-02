using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_SET : MonoBehaviour
{
    List<string> Name_materials = new List<string>();
    public List<Material> list_materials = new List<Material>();
    Dictionary<string, string> materials_obj_name;

    void Start()
    {
        list_materials = new List<Material>(Resources.LoadAll<Material>("Materials_eimolad"));
        
        //var renderer = GetComponent<Renderer>();
        //var materials = renderer.sharedMaterials;
        //list_materials = Resources.Load<Material>("Test");
        //renderer.sharedMaterials = materials;

        //materials_obj_name = new Dictionary<string, string>();
        //var mat = gameObject.GetComponent<Json_Controller>();
        //mat.Load_Material();

        //for (int i = 0; i < mat.mat_root.list.Count; i++)
        //{
        //    materials_obj_name.Add(mat.mat_root.list[i], mat.mat_root.materials[i]);
        //    //Debug.Log(mat.mat_root.list[i] + " - " + mat.mat_root.materials[i]);
        //}        
    }

    public void Set_obj(GameObject obj, List<string> material)//
    {
        //Debug.Log("здравствуй " + obj.name.Replace("(Clone)", ""));

        //var mat = materials_obj_name[obj.name.Replace("(Clone)", "")];//obj.name.Replace("(Clone)", "")

        foreach (var m in list_materials)
        {
            //Debug.Log(m.name);
            //Debug.Log(Name_materials[i]);
            for(int i = 0; i < material.Count; i++)
            {
                if (material[i] == m.name)
                {
                    obj.GetComponent<MeshRenderer>().sharedMaterial = m;
                    //Debug.Log(m.name);
                }
            }
        }

        //obj.GetComponent<MeshRenderer>().sharedMaterial = m;
        //Debug.Log(mat);

        //for (int i = 0; i < Name_materials.Count; i++)
        //{
        //    if (obj.name.Replace("(Clone)", "") == Name_materials[i])
        //    {
        //        //Debug.Log(Name_materials[i] + " И " + obj.name.Replace("(Clone)", ""));
        //        //var mat = obj.GetComponent<MeshRenderer>().sharedMaterials;
        //        foreach (var m in list_materials)
        //        {
        //            Debug.Log(m.name);
        //            Debug.Log(Name_materials[i]);

        //            if (Name_materials[i] == m.name)
        //            {
        //                obj.GetComponent<MeshRenderer>().sharedMaterial = m;
        //                Debug.Log(m.name);
        //            }
        //        }
        //        //for (int f = 0; f < mat.Length; f++)
        //        //{
        //        //    mat[f] = list_materials[i + f];
        //        //}
        //        //obj.GetComponent<MeshRenderer>().sharedMaterials = mat;
        //        break;
        //    }
        //}
    }


    void Update()
    {

    }
}
