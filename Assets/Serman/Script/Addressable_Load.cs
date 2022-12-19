using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public delegate void Result_Count(int i);
public class Addressable_Load : MonoBehaviour
{
    private GameObject _mMyGameObject;
    public List<string> Start_List = new List<string>();
    public List<string> First_List = new List<string>();
    public List<string> _mList = new List<string>();

    public static event Result_Count Count_Change;

    int count = 0;
    int count2 = 0;
    bool first = true;
    bool action_zero = true;
    bool action = false;
    bool action2 = false;
    bool DoOnce1 = true;
    bool DoOnce2 = true;

    private void Start()
    {
        //Addressables.InstantiateAsync("Start_Game_OBJ").Completed += Start_Game_OBJ;       
        Count_Change += Counted;
    }

    void Start_Game_OBJ(AsyncOperationHandle<GameObject> obj)
    {
        _mMyGameObject = obj.Result;
        if (_mMyGameObject.name == "Start_Game_OBJ(Clone)") action_zero = true;        
    }

    private async Task Start_Load_Adress_Async(List<string> bandl)
    {
        Addressable_Load foo = new Addressable_Load();
        var task = new List<Task>();

        for (int i = 0; i < bandl.Count; i++)
        {
            //Debug.Log("в цикле - " + bandl[i]);
            task.Add(foo.run(bandl[i]));
        }
        await Task.WhenAll(task);
        //Debug.Log("Запустил в задание - ");
    }
    public Task run(string key)
    {
        //Debug.Log("Запустил в задание - " + key);
        if (first) Addressables.InstantiateAsync(key).Completed += First_Load;
        if (!first) Addressables.InstantiateAsync(key).Completed += OnLoadDone;
        return Task.CompletedTask;
    }
    
    private void StartLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        _mMyGameObject = obj.Result;
        //Debug.Log("Первая ступень - " + _mMyGameObject.name);
        Count_Change(1);
        

    }
    private void First_Load(AsyncOperationHandle<GameObject> obj)
    {
        _mMyGameObject = obj.Result;
        //Debug.Log("Вторая ступень - " + _mMyGameObject.name);
        Count_Change(2);
        
    }
    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        _mMyGameObject = obj.Result;
        //Debug.Log("Третья ступень - " + _mMyGameObject.name);
    }

    private void Update()
    {
        if(action_zero)
        {

            action_zero = false;
            for (int i = 0; i < Start_List.Count; i++)
            {
                Addressables.InstantiateAsync(Start_List[i]).Completed += StartLoadDone;
                //Debug.Log("Запустил в задание - ");
            }
        }
        if (action && DoOnce1)
        {
            //count = 0;
            DoOnce1 = false;
            action = false;
            Start_Load_Adress_Async(First_List);
        }
        if (action2 && DoOnce2)
        {
            //Debug.Log("второй готов - ");
            //count2 = 0;
            DoOnce2 = false;
            first = false;
            action2 = false;
            Start_Load_Adress_Async(_mList);
        }
    }
    public void Counted(int choice)
    {
        if (choice == 1) count += 1;
        if (choice == 2) count2 += 1;
        if (count == Start_List.Count) action = true;
        if (count2 == First_List.Count) action2 = true;
    }
    //public void ReleaseAssetReference()
    //{
    //    Addressables.Release(_mMyGameObject);
    //}
}
