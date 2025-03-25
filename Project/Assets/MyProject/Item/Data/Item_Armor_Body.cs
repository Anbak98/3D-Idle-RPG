using System;

namespace Project.Data.Item
{
    [Serializable]
    public class Item_Armor_Body : IItemData
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

        /// <summary>
        /// Get Key
        /// </summary>
        public int Key => key;

    }
}
