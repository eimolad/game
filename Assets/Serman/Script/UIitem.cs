using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//public delegate void Weapon_choice(string weapon_name);

[RequireComponent(typeof(Image))]
public class UIitem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    RectTransform m_RectTransform;
    Canvas m_Canvas;
    CanvasGroup m_CanvasGroup;
    //public UnityEvent @event;
    string name_ch;
    //public event Weapon_choice choice;
    UISlot m_UISlot;

    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GetComponentInParent<Canvas>();
        m_CanvasGroup = GetComponent<CanvasGroup>();
        //Drop_in_slot += new Weapon_choice(drop_down_weapon);
        //choice?.Invoke("!!!");
        //m_UISlot.Weapon_drop += drop_down_weapon;
        //choice += drop_down_weapon;



    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slot_transform = m_RectTransform.parent;
        slot_transform.SetAsLastSibling();// обект сверху всех слоев
        m_CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        m_CanvasGroup.blocksRaycasts = true;
        //Debug.Log(eventData.selectedObject.name);
        name_ch = eventData.selectedObject.transform.GetChild(0).gameObject.GetComponent<Image>().mainTexture.name;
        //@event.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_RectTransform.SetAsLastSibling();
    }

    public void drop_down_weapon()//string name_weapon
    {
        Debug.Log(name_ch);
        //choice?.Invoke("!!!");
        //Drop_in_slot("!!!!");
    }
}
