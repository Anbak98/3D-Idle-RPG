using Project.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ViewPluginItem : UIViewPlugin, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private int Width;
    [SerializeField] private int Height;

    private bool selected = false;
    private Vector3 curPosition;

    private void Start()
    {
        curPosition = transform.position;
    }

    private void Update()
    {
        if (selected)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 90);
            }
        }
    }

    public void Set(int itemID, (int, int) direction)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        selected = false;

        // 현재 마우스 위치에서 Raycast 실행
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = eventData.position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        gameObject.transform.position = curPosition;

        foreach (RaycastResult result in results)
        {
            // 자기 자신은 무시
            if (result.gameObject == gameObject) continue;

            if (result.gameObject.TryGetComponent(out ViewPluginItemSlot targetSlot))
            {
                transform.position = targetSlot.transform.position;
                return;
            }
        }
    }
}
