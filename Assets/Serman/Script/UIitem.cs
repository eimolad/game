using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIitem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    RectTransform m_RectTransform;
    Canvas m_Canvas;
    CanvasGroup m_CanvasGroup;

    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GetComponentInParent<Canvas>();
        m_CanvasGroup = GetComponent<CanvasGroup>();
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_RectTransform.SetAsLastSibling();
    }
}
