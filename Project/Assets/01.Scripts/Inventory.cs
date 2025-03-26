using Project.Data.Item;
using Project.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;
public struct Slot
{
    public (int, int) index;
    public (int, int) dir;
    public IItemInstance item;

    public int DirToDegree()
    {
        if (dir == (1, 1))
            return 180;
        if (dir == (-1, 1))
            return 0;
        if (dir == (-1, -1))
            return 270;
        if (dir == (1, -1))
            return 90;

        Debug.LogError("[Slot(struct)] Unvalid direction");
        return -1;
    }
}

public class Inventory : MonoBehaviour
{
    public Action OnItemAdded;

    public List<Slot> SlotsInfo { get; private set; }
    public void Add(IItemInstance item, (int, int) direction)
    {
        if (direction.Item1 * direction.Item1 != 1 || direction.Item2 * direction.Item2 != 1)
            Debug.LogError($"[Inventory] Unvalid slot direction ({direction.Item1},{direction.Item2})");
        if(direction.Item1 * direction.Item2 != 1)
        {
            (item.SlotWidth, item.SlotHeight) = (item.SlotHeight, item.SlotWidth);
        }

        var index = CurIndex(item.SlotWidth, item.SlotHeight, direction);

        if(index != (-1, -1))
        {
            for (int y = 0; y * direction.Item1 < item.SlotHeight; y += direction.Item1)
                for (int x = 0; x * direction.Item2 < item.SlotWidth; x += direction.Item2)
                    _backpack[index.Item1 + y, index.Item2 + x] = item;

            SlotsInfo.Add(new Slot() { index = index, item = item, dir = direction });
            OnItemAdded?.Invoke();
        }
    }

    #region PRIVATE
    private IItemInstance[, ] _backpack;

    private void Awake()
    {
        _backpack = new IItemInstance[6, 5];
        SlotsInfo = new List<Slot>();
        ItemFactory itemFactory = new ItemFactory();
        Add(itemFactory.Create<HandWeaponInstance>(1), (1, -1));
        Add(itemFactory.Create<HandWeaponInstance>(1), (1, 1));
        Add(itemFactory.Create<HandWeaponInstance>(1), (1, -1));
        Add(itemFactory.Create<HandWeaponInstance>(1), (1, 1));
        Add(itemFactory.Create<HandWeaponInstance>(1), (-1, -1));
    }

    private void Start()
    {
    }

    private (int, int) CurIndex(int width, int height, (int, int) direction)
    {

        for (int y = 0; y < 6; ++y)
            for (int x = 0; x < 5; ++x)
                if(CheckSlotSize(x, y, width, height, direction))
                    return (y, x);

        return (-1, -1);
    }

    private bool CheckSlotSize(int x, int y, int width, int height, (int, int) direction)
    {
        for(int i = 0; i * direction.Item1 < height; i += direction.Item1)
            for(int j = 0; j * direction.Item2 < width; j += direction.Item2)
                if (y + i > 5 || y + i < 0 || x + j > 4 || x + j < 0 || _backpack[y + i, x + j] != null)
                    return false;

        return true;
    }
    #endregion
}
