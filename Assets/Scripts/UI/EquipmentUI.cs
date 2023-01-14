using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class EquipmentUI : BaseUI
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private Equipment equipment;
    private Dictionary<string, EquipmentSlot> slots = new Dictionary<string, EquipmentSlot>();

    private void Awake()
    {
        base.Awake();
        foreach(var child in slotParent.GetComponentsInChildren<EquipmentSlot>(true))
        {

            slots[child.equipmentType] = child;
        }
    }

    public void SubscribeToGameFoundationEvents()
    {
        GameFoundationSdk.inventory.itemAddedToCollection += OnItemAddedToEquipment;
        GameFoundationSdk.inventory.itemRemovedFromCollection += OnItemRemovedToEquipment;
    }
    public void UnSubscribeToGameFoundationEvents()
    {
        GameFoundationSdk.inventory.itemAddedToCollection -= OnItemAddedToEquipment;
        GameFoundationSdk.inventory.itemRemovedFromCollection -= OnItemRemovedToEquipment;
    }
    public void OnItemAddedToEquipment(IItemCollection itemCollection,InventoryItem inventoryItem) 
    { 
        if(equipment.Items.id == itemCollection.id) 
        {
            slots[inventoryItem.definition.GetStaticProperty("equipmentType").AsString()].Set(inventoryItem);
        }
    }
    public void OnItemRemovedToEquipment(IItemCollection itemCollection, InventoryItem inventoryItem)
    {
        if (equipment.Items.id == itemCollection.id)
        {
            slots[inventoryItem.definition.GetStaticProperty("equipmentType").AsString()].UnSet();
        }
    }


}
