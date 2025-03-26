using UnityEngine;
using UnityEngine.EventSystems;

public class UIViewPluginHeader : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Transform UIView;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        UIView.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
