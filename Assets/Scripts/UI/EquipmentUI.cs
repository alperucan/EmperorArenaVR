using System;
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
            child.equipment = equipment;
            slots[child.equipmentType] = child;
        }
    }

    private void OnEnable()
    {
        equipment.OnEquipmentInitialized += Initialize;
        equipment.OnEquip += AddItemToEquipment;
        equipment.OnUnEquip += RemoveItemFromEquipment;
        
    }
    private void OnDisable()
    {
        equipment.OnEquip -= AddItemToEquipment;
        equipment.OnUnEquip -= RemoveItemFromEquipment;
        equipment.OnEquipmentInitialized -= Initialize;
    }

    private void RemoveItemFromEquipment(InventoryItem inventoryItem)
    {
        slots[inventoryItem.definition.GetStaticProperty("equipmentType").AsString()].UnSet();
    }

    private void AddItemToEquipment(InventoryItem inventoryItem)
    {
        slots[inventoryItem.definition.GetStaticProperty("equipmentType").AsString()].Set(inventoryItem);
    }
   
    private void Initialize()
    {
        foreach (InventoryItem inventoryItem in equipment.Items)
        {
            slots[inventoryItem.definition.GetStaticProperty("equipmentType").AsString()].Set(inventoryItem);
        }
    }

}
