using System;

namespace Project.Data.Item
{
    [Serializable]
    public class Item_Hand_Weapon : IItemData
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

        /// <summary>
        /// Get Key
        /// </summary>
        public int Key => key;

    }
}
