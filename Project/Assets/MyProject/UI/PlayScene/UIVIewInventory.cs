using Project.UI;
using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class UIVIewInventory : UIView
{
    [SerializeField]
    private GameObject OneByOneSlot;
    [SerializeField]
    private GameObject TwoByOneSlot;
    [SerializeField]
    private GameObject TwoByTwoSlot;

    [SerializeField]
    private List<ViewPluginItemSlot> viewPluginItemSlots;

    protected override void Start()
    {
        base.Start();

        foreach(Slot slot in Global.Instance.Player.inventory.SlotsInfo)
        {
            GameObject obj;

            if (slot.item.SlotWidth * slot.item.SlotHeight == 1)
                obj = Instantiate(OneByOneSlot);
            else if (slot.item.SlotWidth * slot.item.SlotHeight == 2)
                obj = Instantiate(TwoByOneSlot);
            else if (slot.item.SlotWidth * slot.item.SlotHeight == 4)
                obj = Instantiate(TwoByTwoSlot);
            else
                throw new ArgumentException();

            obj.transform.SetParent(transform, false);
            obj.transform.position += new Vector3(100 * slot.index.Item2, -100 * slot.index.Item1);
            obj.transform.rotation = Quaternion.Euler(0, 0, slot.DirToDegree());
            obj.GetComponent<Image>().sprite = slot.item.GetSprite();
            obj.GetComponent<ViewPluginItem>().slot = slot;

            ViewPluginItemSlot viewPluginItemSlot = viewPluginItemSlots[slot.index.Item1 * 5 + slot.index.Item2];
            viewPluginItemSlot.Set(slot);
        }
    }
}
