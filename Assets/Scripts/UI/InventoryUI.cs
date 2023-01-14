using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform slotParent;
    [SerializeField] private Button close;
    private List<InventorySlot> slots;


    private void Awake()
    {
        base.Awake();
        slots = slotParent.GetComponentsInChildren<InventorySlot>(true).ToList();
        close.onClick.AddListener(delegate { Hide(); });
    }

    public void SubscribeToGameFoundationEvents() 
    {
        GameFoundationSdk.inventory.itemAddedToCollection += OnItemAddedToInventory;
        GameFoundationSdk.inventory.itemRemovedFromCollection += OnItemRemovedToInventory;
    }
    public void UnSubscribeToGameFoundationEvents()
    {
        GameFoundationSdk.inventory.itemAddedToCollection -= OnItemAddedToInventory;
        GameFoundationSdk.inventory.itemRemovedFromCollection -= OnItemRemovedToInventory;
    }
    private void OnItemAddedToInventory(IItemCollection itemCollection,InventoryItem inventoryItem) 
    {
        if(inventory.Items.id == itemCollection.id) 
        {
            foreach(var slot in slots) 
            {
                if(slot.inventoryItem == null) 
                {
                    slot.Set(inventoryItem);
                    break;
                }
            }
        }
    }
    private void OnItemRemovedToInventory(IItemCollection itemCollection, InventoryItem inventoryItem)
    {
        if (inventory.Items.id == itemCollection.id)
        {
            ItemList inventory = itemCollection as ItemList;
            int index = inventory.IndexOf(inventoryItem);
            slots[index].UnSet();
        }
    }
}
