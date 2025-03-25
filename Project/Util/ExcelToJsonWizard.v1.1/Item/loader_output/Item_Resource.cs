using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Item_Resource
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

}
public class Item_ResourceLoader
{
    public List<Item_Resource> ItemsList { get; private set; }
    public Dictionary<int, Item_Resource> ItemsDict { get; private set; }

    public Item_ResourceLoader(string path)
    {
        string jsonData;
        jsonData = File.ReadAllText(path);
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, Item_Resource>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<Item_Resource> Items;
    }

    public Item_Resource GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public Item_Resource GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
