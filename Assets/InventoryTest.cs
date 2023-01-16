using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class InventoryTest : MonoBehaviour
{
    
    public ItemTest[] item = new ItemTest[8];
    // Start is called before the first frame update
    void Awake()
    {
        
        Debug.Log("Started Inv Test");
    }

    // Update is called once per frame
    void Update()
    {
        AddWood(1);
        Debug.Log("Added Wood");
        for (int i = 0; i < 8; i++)
        {
            item[i].item = Inventory.inventoryList[i];
        }
        
        if(Inventory.inventoryList[0] != null)
        {
            Debug.Log(Inventory.inventoryList[0].GetAmount());
        }else
        {
            Debug.Log("No Item");
        }
        
    }

    public void AddWood(int amount)
    {
        WoodItem wood = new WoodItem(amount);
        Inventory.AddItem(wood);
    }
    
    public void RemoveWood(int amount)
    {
        
        Inventory.RemoveAmountOfItem(ItemType.Wood, amount);
    }
}
