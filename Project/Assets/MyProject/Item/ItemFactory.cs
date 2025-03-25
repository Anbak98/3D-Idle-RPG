using System;
using System.Collections.Generic;
using UnityEngine;
using Project.Data.Item;

namespace Project.Factory
{
    public class ItemFactory
    {
        public ItemFactory() 
        {  
            foreach(var map in factoryMap)
            {
                try
                {
                    map.Value(loaders[map.Key].Load(1));
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }
        }

        public T Create<T>(int index) where T : IItemInstance
        {
            if (factoryMap.TryGetValue(typeof(T), out var instance) && loaders.TryGetValue(typeof(T), out var loader))
                if(instance(loader.Load(index)) is T result)
                    return result;

            throw new ArgumentException($"[ItemFactory] {typeof(T).Name}은(는) 등록되지 않은 아이템 타입입니다.");
        }

        #region PRIVATE
        private readonly Dictionary<Type, IItemLoader> loaders = new()
        {
            {typeof(ResourceInstance), new ItemLoader<Item_Resource>() },
            {typeof(ConsumeInstance), new ItemLoader<Item_Consume>() },
            {typeof(HandWeaponInstance), new ItemLoader<Item_Hand_Weapon>() },
            {typeof(ArmorBodyInstance), new ItemLoader<Item_Armor_Body>() },
            {typeof(ArmorBootsInstance), new ItemLoader<Item_Armor_Boots>() },
            {typeof(ArmorGlovesInstance), new ItemLoader<Item_Armor_Gloves>() },
            {typeof(ArmorHelmetInstance), new ItemLoader<Item_Armor_Helmet>() },
            {typeof(ArmorPantsInstance), new ItemLoader<Item_Armor_Pants>() },
        };
        private readonly Dictionary<Type, Func<IItemData, IItemInstance>> factoryMap = new()
        {
            {typeof(ResourceInstance), (IItemData data) => new ResourceInstance(data as Item_Resource)},
            {typeof(ConsumeInstance), (IItemData data) => new ConsumeInstance(data as Item_Consume) },
            {typeof(HandWeaponInstance), (IItemData data) => new HandWeaponInstance(data as Item_Hand_Weapon) },
            {typeof(ArmorBodyInstance), (IItemData data) => new ArmorBodyInstance(data as Item_Armor_Body) },
            {typeof(ArmorBootsInstance), (IItemData data) => new ArmorBootsInstance(data as Item_Armor_Boots) },
            {typeof(ArmorGlovesInstance), (IItemData data) => new ArmorGlovesInstance(data as Item_Armor_Gloves) },
            {typeof(ArmorHelmetInstance), (IItemData data) => new ArmorHelmetInstance(data as Item_Armor_Helmet) },
            {typeof(ArmorPantsInstance), (IItemData data) => new ArmorPantsInstance(data as Item_Armor_Pants) },
        };

        private interface IItemLoader 
        {
            public IItemData Load(int key);
        }

        private class ItemLoader<T> : IItemLoader where T : IItemData
        {
            public ItemLoader()
            {
                string path = $"JSON/{typeof(T).Name}";
                string jsonData;
                jsonData = Resources.Load<TextAsset>(path).text;
                ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
                ItemsDict = new Dictionary<int, T>();
                foreach (var item in ItemsList)
                {
                    ItemsDict.Add(item.Key, item);
                }
            }

            public IItemData Load(int key)
            {
                return GetByKey(key);
            }
            #region PRIVATE
            public List<T> ItemsList { get; private set; }
            public Dictionary<int, T> ItemsDict { get; private set; }
            private T GetByKey(int key)
            {
                if (ItemsDict.ContainsKey(key))
                {
                    return ItemsDict[key];
                }
                else
                {
                    throw new ArgumentException($"[ItemFactory] {typeof(T)}({key})은(는) 등록되지 않은 아이템 넘버입니다.");
                }
            }

            [Serializable]
            private class Wrapper
            {
                public List<T> Items;
            }
            #endregion
        }
        #endregion
    }
}