using UnityEngine;
    public abstract class Item
    {
        public Item(ItemType type)
        {
            this.itemType = type;
            this.amount = amount;
        }

        protected ItemType itemType;
        int amount;
        
        public int GetAmount => amount;
        public void SetAmount(int amount) => this.amount = amount;
    }
    
    public enum ItemType
    {
        Scrap,
        Wood

    }
