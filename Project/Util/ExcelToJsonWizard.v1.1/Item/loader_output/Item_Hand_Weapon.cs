using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Item_Hand_Weapon
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
    /// AttackDamage
    /// </summary>
    public int attackDamage;

    /// <summary>
    /// AbilityPower
    /// </summary>
    public int abilityPower;

}
public class Item_Hand_WeaponLoader
{
    public List<Item_Hand_Weapon> ItemsList { get; private set; }
    public Dictionary<int, Item_Hand_Weapon> ItemsDict { get; private set; }

    public Item_Hand_WeaponLoader(string path)
    {
        string jsonData;
        jsonData = File.ReadAllText(path);
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, Item_Hand_Weapon>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<Item_Hand_Weapon> Items;
    }

    public Item_Hand_Weapon GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public Item_Hand_Weapon GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
