using Project.Data.Item;
using UnityEngine;
using UnityEngine.UI;

public class ViewPluginEquipSlot : MonoBehaviour
{
    public int y, x;
    public IItemInstance item = null;

    public void Set(Slot slot)
    {
        y = slot.index.Item1;
        x = slot.index.Item2;
        item = slot.item;
    }
}
