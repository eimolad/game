using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IDropHandler
{
    public bool drop = false;
    public string Slot_for_name;
    public GameObject text;

    private void Start()
    {
       
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name.Substring(0, 7));
        //Debug.Log(gameObject.name);

        if (eventData.selectedObject.name == Slot_for_name) drop = true;
        if (gameObject.name.Substring(0,7) == "Ui_Slot") drop = true;

        if (drop)
        {
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
            drop = false;
        }

    }
    void Update()
    {
        if (gameObject.transform.childCount > 1)
        {
           if (text != null) text.SetActive(false);   
        }
        else
        {
            if (text != null) text.SetActive(true);
        }
    }
}
