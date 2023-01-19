using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static int dayCount = 0;

   
    public static int highscore;

    public static Item scrap; //= new Item(ItemType.Scrap);
    public static Item wood; //= new Item(ItemType.Wood);

    public static GameObject player;
}

public static class Register
{
    private static Dictionary<ItemType, Item> itemDictionary = new Dictionary<ItemType, Item>();
    public static void RegisterItem(Item item)
    {
            itemDictionary.Add(item.GetItemType(), item);
    }
    
    public static Item GetItemFromType(ItemType type)
    {
        Item output;
        itemDictionary.TryGetValue(type, out output);
        return output;
    }
}


public static class Inventory
{
   public static ItemStack[] inventoryList = new ItemStack[8];

    //What slot is selected in hand
    public static int selectedSlot = 0;
    
    //Input a itemType get how many of that itemtype exist in inventory
    public static int CheckAmountOfItem(ItemType itemType)
    {
        
        int itemAmount = 0;
        foreach (ItemStack item in inventoryList)
        {
            if(item != null)
            if(item.GetItem().GetItemType() == itemType)
            {
                itemAmount =+ item.GetAmount();
            }
        }
        return itemAmount;
        
    }
    
    //Input a itemType and amount and return a boolean (true or false) if a certain amount of a specific itemtype exists in inventory
    public static bool DoesInventoryContain(ItemType itemType, int amount)
    {
        foreach (ItemStack item in inventoryList)
        {
            if(item != null)
            if(item.GetItem().GetItemType() == itemType)
            {
                amount -= item.GetAmount();
            }
        }
        
        if(amount <= 0)
        {
            return true;
        }
        return false;
    }
    
    //Simple add item to inventory, returns amount of items that could not be added or got left over
    public static int AddItem(ItemStack item)
    {
        int amount = item.GetAmount();
        int index = 0;
        foreach (ItemStack invItem in inventoryList)
        {

            
            if (invItem == null && amount > 0)
            {
                inventoryList[index] = item;
                
                
                
                if (amount > item.GetItem().GetStackSize())
                {
                    inventoryList[index].SetAmount(item.GetItem().GetStackSize());
                    amount -= item.GetItem().GetStackSize();
                }
                else
                {
                    amount = 0;
                }
               
            }
            else if (invItem != null && amount > 0)
                if (invItem.GetItem().GetItemType() == item.GetItem().GetItemType())
                {
                    invItem.SetAmount(invItem.GetAmount() + amount);
                    if (invItem.GetAmount() > invItem.GetItem().GetStackSize())
                    {
                        amount = invItem.GetAmount() - invItem.GetItem().GetStackSize();
                        invItem.SetAmount(invItem.GetItem().GetStackSize());
                    }
                    else
                    {
                        amount = 0;
                    }

                }
            
    
            if (invItem != null)
                if (invItem.GetAmount() <= 0)
                {
                    Debug.Log("Set " + index + " to null");
                    inventoryList[index] = null;
                }
            
            

            
            if(amount <= 0)
            {
                break;
            }
            index++;
            
        }

        return amount;
    }
    

    //Simple remove item from inventory, return if it was successful, can be unsuccessful if inventory is empty for example
    public static bool RemoveAmountOfItem(ItemType itemType, int amount)
    {
        int index = 0;
        foreach (ItemStack item in inventoryList)
        {
            if(item != null)
            if (item.GetItem().GetItemType() == itemType)
            {
                if (amount >= item.GetItem().GetStackSize())
                {
                    item.SetAmount(0);
                    amount -= item.GetItem().GetStackSize();
                }
                else
                {
                    item.SetAmount(item.GetAmount() - amount);
                    amount = 0;
                }
            }
            if(item != null)
                if (item.GetAmount() <= 0)
                {
                    inventoryList[index] = null;   
                }

            index++;
        }

        return true;
    }

    
    //Check if item fits in inventory
    public static bool DoesItemFit(ItemStack item)
    {
        int amount = item.GetAmount();
        foreach (ItemStack invItem in inventoryList)
        {
            if(item.GetItem().GetItemType() == invItem.GetItem().GetItemType())
            {
               amount -= invItem.GetItem().GetStackSize() - invItem.GetAmount();
            }
        }
        
        if(amount <= 0)
        {
            return true;
        }
        return false;
    }

    public static ItemStack GetSelectedItemStack()
    {
        return inventoryList[selectedSlot];
    }
}