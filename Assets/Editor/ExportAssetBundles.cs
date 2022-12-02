using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Unity.VisualScripting;

public class ExportAssetBundles : MonoBehaviour
{

    static List<string> Name_Bandls = new List<string>();
    static List<int> Name_num_obj = new List<int>();
    static List<Vector3> xz_obj = new List<Vector3>();
    //static Dictionary<string, Material> List_materials = new Dictionary<string, Material>();

    [MenuItem("Assets/Создать бандлы вручную")]
    [System.Obsolete]
    static void ExportResurce()
    {
        // Bring up save panel
        string basename = Selection.activeObject ? Selection.activeObject.name : "New Resource";
        string path = EditorUtility.SaveFilePanel("Save Resources", "", basename, "");

        if (path.Length != 0)
        {
            // Build the resource file from the active selection.
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

            //// for Android
            //BuildPipeline.BuildAssetBundle(Selection.activeObject,
            //                               selection, path + ".android.unity3d",
            //                               BuildAssetBundleOptions.CollectDependencies |
            //                               BuildAssetBundleOptions.CompleteAssets,
            //                               BuildTarget.Android);

            //// for iPhone
            //BuildPipeline.BuildAssetBundle(Selection.activeObject,
            //                               selection, path + ".iphone.unity3d",
            //                               BuildAssetBundleOptions.CollectDependencies |
            //                               BuildAssetBundleOptions.CompleteAssets,
            //                               BuildTarget.iPhone);

            // for WebPlayer
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path + ".unity3d",
                                           BuildAssetBundleOptions.CollectDependencies |
                                           BuildAssetBundleOptions.CompleteAssets,
                                           BuildTarget.WebGL);

            Selection.objects = selection;
        }
        //GameObject Search_Canvas = GameObject.Find("Canvas_Game");// найти объект
        //Search_Canvas.GetComponent<Json_Controller>().Save_obj_xz(Name_num_obj, xz_obj);
    }
    [MenuItem("Assets/Добавить в первый саисок загрузки")]
    static void Add_Obj_List()
    {
        List<string> names = new List<string>();
        //List <Material> list_materials = new List<Material>();
        //List<string> list_materials_name = new List<string>();

        var Prefabs = LoadAllPrefabsAt("Assets/Resources/");// список прифабов в указанной папке
        Debug.Log("Найдено прифабов " + Prefabs.Count);

        for (int i = 0; i < Prefabs.Count; i++)// перебераем полученый массив
        {
            Object prefab = new Object();// создаем новый объект
            prefab = Prefabs[i];
            names.Add(prefab.name);// добавляем в список имя объекта     
        }
        GameObject Address_load = GameObject.Find("Address_load");// найти объект

        for (int i = 0; i < names.Count; i++) // перебираем список имен полученых объектов
        {
            bool find = false;

            for (int j = 0; j < Address_load.GetComponent<Addressable_Load>().First_List.Count; j++)// проверка общего списка, на наличие совподений
            {
                if (names[i] == Address_load.GetComponent<Addressable_Load>().First_List[j])// если нашли совподения
                {
                    find = true;
                }
            }
            for (int j = 0; j < Address_load.GetComponent<Addressable_Load>()._mList.Count; j++)// проверка общего списка, на наличие совподений
            {
                if (names[i] == Address_load.GetComponent<Addressable_Load>()._mList[j])// если нашли совподения
                {
                    Address_load.GetComponent<Addressable_Load>()._mList.RemoveAt(j);
                }
            }
            if (!find)
            {
                Address_load.GetComponent<Addressable_Load>().First_List.Add(names[i]);// если совподения не найдены, добавляем к общему списку
            }
        }

        Debug.Log("Готово!");
    }
    [MenuItem("Assets/Добавить во второй саисок загрузки")]
    static void Add_Obj_List2()
    {
        List<string> names = new List<string>();
        //List <Material> list_materials = new List<Material>();
        //List<string> list_materials_name = new List<string>();

        var Prefabs = LoadAllPrefabsAt("Assets/Resources/");// список прифабов в указанной папке
        Debug.Log("Найдено прифабов " + Prefabs.Count);

        for (int i = 0; i < Prefabs.Count; i++)// перебераем полученый массив
        {
            Object prefab = new Object();// создаем новый объект
            prefab = Prefabs[i];
            names.Add(prefab.name);// добавляем в список имя объекта     
        }
        GameObject Address_load = GameObject.Find("Address_load");// найти объект

        for (int i = 0; i < names.Count; i++) // перебираем список имен полученых объектов
        {
            bool find = false;

            for (int j = 0; j < Address_load.GetComponent<Addressable_Load>().First_List.Count; j++)// проверка общего списка, на наличие совподений
            {
                if (names[i] == Address_load.GetComponent<Addressable_Load>().First_List[j])// если нашли совподения
                {
                    find = true;
                }
            }
            for (int j = 0; j < Address_load.GetComponent<Addressable_Load>()._mList.Count; j++)// проверка общего списка, на наличие совподений
            {
                if (names[i] == Address_load.GetComponent<Addressable_Load>()._mList[j])// если нашли совподения
                {
                    find = true;
                }
            }
            if (!find)
            {
                Address_load.GetComponent<Addressable_Load>()._mList.Add(names[i]);// если совподения не найдены, добавляем к общему списку
            }
        }

        Debug.Log("Готово!");
    }

    [MenuItem("Assets/удалить материалы")]
    static void Del_material()
    {
        List<string> names = new List<string>();
        //List <Material> list_materials = new List<Material>();
        //List<string> list_materials_name = new List<string>();

        var Prefabs = LoadAllPrefabsAt("Assets/Resources/");// список прифабов в указанной папке
        Debug.Log("Найдено прифабов " + Prefabs.Count);

        for (int i = 0; i < Prefabs.Count; i++)// перебераем полученый массив
        {
            Object prefab = new Object();// создаем новый объект
            prefab = Prefabs[i];
            var chld = prefab.GetComponentsInChildren<MeshRenderer>();// получаем кол-во материалов на объекте
            Debug.Log("длинна подобъектов" + chld.Length);

            for (int f = 0; f < chld.Length; f++)// перебераем все марериалыв объекте
            {
                var mat = chld[f].sharedMaterials; // переменная массива материалов объекта

                if (!chld[f].GetComponent<New_Material>())// проверяем наличие нового скрипта
                {
                    chld[f].AddComponent<New_Material>(); // добавляем скрипт если его нету
                }

                for (int j = 0; j < mat.Length; j++)// перебираем марериалы объекта
                {
                    names.Add(chld[f].name);// добавляем в список имя объекта
                    
                    if(mat[j] != null)
                    {
                        chld[f].GetComponent<New_Material>().new_mat.Add(mat[j].name);// добавляем в скрипт имя материала
                        mat[j] = null; // удаляем материал 
                    }
                                     
                }
                chld[f].sharedMaterials = mat;// меняем существующие материалы на пустые
                            
            }
        }
        GameObject Address_load = GameObject.Find("Address_load");// найти объект

        for(int i = 0; i < names.Count; i++) // перебираем список имен полученых объектов
        {
            bool find = false;

            for (int j = 0; j < Address_load.GetComponent<Addressable_Load>()._mList.Count; j++)// проверка общего списка, на наличие совподений
            {
               if(names[i] == Address_load.GetComponent<Addressable_Load>()._mList[j])// если нашли совподения
                {
                    find = true;
                }
            }
            if (!find)
            {
                Address_load.GetComponent<Addressable_Load>()._mList.Add(names[i]);// если совподения не найдены, добавляем к общему списку
            }
        }


        //Address_load.GetComponent<Addressable_Load>()._mList = names;
        // //Debug.Log("длинна списка " + list_materials.Count);
        //Search_Canvas.GetComponent<Json_Controller>().Save_Material(names, list_materials_name);
        //Debug.Log("длинна списка " + list_materials.Count);
        Debug.Log("Готово!");
    }
    [MenuItem("Assets/Создать бандлы автоматически")]
    [System.Obsolete]
    static async void Get_Prefabs()
    {
        Name_Bandls.Clear();
        Name_Bandls.Add("Имя ассета -> Присвоенный номер");
        string dir = Path.Combine(@"C:\Bundles\");// путь к бандлам  C:\Bundles\

        if (Directory.Exists(dir) == false) // Определяем, существует ли каталог
        {
            Directory.CreateDirectory(dir); // Создаем каталог AssetBundles в проекте
        }

        var Prefabs = LoadAllPrefabsAt("Assets/Resources/");// список прифабов в указанной папке

        Debug.Log(Prefabs.Count + " Assets");
        int new_name = 0;
        ExportAssetBundles foo = new ExportAssetBundles();
        Dictionary<int, Vector3> bandles_vector = new Dictionary<int, Vector3>();        

        var task = new List<Task>();
        for (int i = 0; i < Prefabs.Count; i++)//Prefabs.Count
        {
            Object prefab = new Object();
            prefab = Prefabs[i];
            bandles_vector.Add(new_name, prefab.GetComponent<Transform>().position);

            Name_Bandls.Add(prefab.name + " = " + new_name.ToString());
            task.Add(foo.run(prefab, dir + new_name.ToString()));
            new_name += 1;
            // Name_num_obj.Add(new_name);
            //await Task.Delay(500);
        }
        await Task.WhenAll(task);

        using (StreamWriter sw = File.CreateText(dir + "list.txt"))
        {

            foreach (string txt in Name_Bandls)
            {
                sw.WriteLine(txt);
            }
            sw.Close();
        }
        GameObject Search_Canvas = GameObject.Find("Canvas_Game");// найти объект
        Search_Canvas.GetComponent<Json_Controller>().Save_obj_xz(bandles_vector);
        //Search_Canvas.GetComponent<Json_Controller>().Save_Material(List_materials);
        //Debug.Log("длинна списка"+List_materials.Count);
    }

    [System.Obsolete]
    public Task run(Object s, string path)
    {

        //Debug.Log(s.GetType());
        var obj = (GameObject)Resources.Load(s.name);
        //Debug.Log(obj.GetComponent<Transform>().position);
        //int numname;
        //int.TryParse(obj.name, out numname);
        //Name_num_obj.Add(numname);
        //Debug.Log(s.name);

        Object[] selection = obj.GetComponentsInChildren<Transform>();//Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        BuildPipeline.BuildAssetBundle(s, selection, path + ".unity3d", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.WebGL);
        //Selection.objects = selection;
        return Task.CompletedTask;
    }

    public static List<GameObject> LoadAllPrefabsAt(string path)
    {
        if (path != "")
        {
            if (path.EndsWith("/"))
            {
                path = path.TrimEnd('/');
            }
        }

        DirectoryInfo dirInfo = new DirectoryInfo(path);
        FileInfo[] fileInf = dirInfo.GetFiles("*.prefab");

        //loop through directory loading the game object and checking if it has the component you want
        List<GameObject> prefabs = new List<GameObject>();
        foreach (FileInfo fileInfo in fileInf)
        {
            string fullPath = fileInfo.FullName.Replace(@"\", "/");
            string assetPath = "Assets" + fullPath.Replace(Application.dataPath, "");
            GameObject prefab = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;

            if (prefab != null)
            {              
                prefabs.Add(prefab);
            }
        }
        return prefabs;
    }


}