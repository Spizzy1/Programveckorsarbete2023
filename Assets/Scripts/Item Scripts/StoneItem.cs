using UnityEngine;
//Pontus
public class StoneItem:Item
{
    protected override void SetupItem()
    {
        itemName = "Stone";
        itemType = ItemType.Stone;
        SetSpriteFromName("Stone");
        
    }
}