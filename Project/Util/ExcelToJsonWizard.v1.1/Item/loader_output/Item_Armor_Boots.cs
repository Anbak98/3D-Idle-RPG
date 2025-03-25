using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Item_Armor_Boots
{
    /// <summary>
    /// ID
    /// </summary>
    public int key;

    /// <summary>
    /// Name
    /// </summary>
    public string name;

    /// <summary>
    /// Description
    /// </summary>
    public string description;

    /// <summary>
    /// MeleeResistance
    /// </summary>
    public int armor;

    /// <summary>
    /// MagicResistance
    /// </summary>
    public int magic_resistance;

}
public class Item_Armor_BootsLoader
{
    public List<Item_Armor_Boots> ItemsList { get; private set; }
    public Dictionary<int, Item_Armor_Boots> ItemsDict { get; private set; }

    public Item_Armor_BootsLoader(string path)
    {
        string jsonData;
        jsonData = File.ReadAllText(path);
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, Item_Armor_Boots>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<Item_Armor_Boots> Items;
    }

    public Item_Armor_Boots GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public Item_Armor_Boots GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
