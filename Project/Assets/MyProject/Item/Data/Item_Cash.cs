using System;

namespace Project.Data.Item
{
    [Serializable]
    public class Item_Cash : IItemData
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
        /// Get Key
        /// </summary>
        public int Key => key;

    }
}
