using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Inventory : MonoBehaviour
{
   public ItemList Items { get; private set; }


    private void Start()
    {
        if (Items == null) 
        {
            Items = GameFoundationSdk.inventory.CreateList();
        }
    }
    private void OnEnable()
    {
        EventManager.Instance.OnEquip += Add;
        EventManager.Instance.OnUnEquip += Remove;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnEquip -= Add;
        EventManager.Instance.OnUnEquip -= Remove;
    }
    public void Add(Item item) 
    {
        Items.Add(item.InventoryItem);
        Debug.Log($"Added {item.InventoryItem.definition.displayName} to inventory");
        Destroy(item.gameObject);
    }
    public void Add(InventoryItem inventoryItem) 
    {
        Items.Add(inventoryItem);
    
    }
    public void Remove(InventoryItem inventoryItem)
    {

        Items.Remove(inventoryItem);
    }
}
