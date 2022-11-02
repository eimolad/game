using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ваш скрипт должен иметь название "ClothAdder" 
public class ClothAdder : MonoBehaviour
{
    [SerializeField] private GameObject topPrefab;
    [SerializeField] private GameObject pantsPrefab;
    [SerializeField] private GameObject shoesPrefab;
    [SerializeField] private GameObject chestPlatePrefab;
    [SerializeField] private GameObject armorMaskPrefab;
    [SerializeField] private SkinnedMeshRenderer playerSkin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            addClothes(topPrefab);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            addClothes(pantsPrefab);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            addClothes(shoesPrefab);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            addClothes(chestPlatePrefab);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            addClothes(armorMaskPrefab);
        }
    }
    void addClothes(GameObject clothPrefab)
    {
        GameObject clothObj = Instantiate(clothPrefab, playerSkin.transform.parent);
        SkinnedMeshRenderer[] renderers = clothObj.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            renderer.bones = playerSkin.bones;
            renderer.rootBone = playerSkin.rootBone;
        }
    }
}
