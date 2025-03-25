using Unity.VisualScripting;

namespace Project.Data.Item
{
    public interface IItemData
    {
        public int Key { get; }
    }

    public interface IItemInstance
    {
    }

    public abstract class ItemInstance<T> : IItemInstance where T : IItemData
    {
        public T Data { get; private set; }

        protected ItemInstance(T data)
        {
            Data = data;
        }
    }

    public class ArmorBodyInstance : ItemInstance<Item_Armor_Body>
    {
        public ArmorBodyInstance(Item_Armor_Body data) : base(data) { }
    }

    public class ArmorBootsInstance : ItemInstance<Item_Armor_Boots>
    {
        public ArmorBootsInstance(Item_Armor_Boots data) : base(data) { }
    }

    public class ArmorGlovesInstance : ItemInstance<Item_Armor_Gloves>
    {
        public ArmorGlovesInstance(Item_Armor_Gloves data) : base(data) { }
    }

    public class ArmorHelmetInstance : ItemInstance<Item_Armor_Helmet>
    {
        public ArmorHelmetInstance(Item_Armor_Helmet data) : base(data) { }
    }

    public class ArmorPantsInstance : ItemInstance<Item_Armor_Pants>
    {
        public ArmorPantsInstance(Item_Armor_Pants data) : base(data) { }
    }

    public class ConsumeInstance : ItemInstance<Item_Consume>
    {
        public ConsumeInstance(Item_Consume data) : base(data) { }
    }

    public class HandWeaponInstance : ItemInstance<Item_Hand_Weapon>
    {
        public HandWeaponInstance(Item_Hand_Weapon data) : base(data) { }
    }

    public class ResourceInstance : ItemInstance<Item_Resource>
    {
        public ResourceInstance(Item_Resource data) : base(data) { }
    }
}
