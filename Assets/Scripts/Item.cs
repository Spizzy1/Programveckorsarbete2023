using UnityEngine;
    public class Item
    {
        public Item(ItemType type)
        {
            this.itemType = type;
            this.amount = amount;
        }

        ItemType itemType;
        int amount;
        private Sprite sprite;

        public Sprite GetSprite => sprite;



        public int GetAmount => amount;
        public void SetAmount(int amount) => this.amount = amount;
    }
    
    public enum ItemType
    {
        Scrap,
        Wood

    }
