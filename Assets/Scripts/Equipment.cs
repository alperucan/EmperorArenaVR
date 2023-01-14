using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Equipment : MonoBehaviour
{
   public ItemMap Items { get; private set; }


    private void Start()
    {
        if(Items == null) 
        {
            Items = GameFoundationSdk.inventory.CreateMap();
        }
    }
    private void OnEnable()
    {
        EventManager.Instance.OnEquip += Equip;
        EventManager.Instance.OnUnEquip += UnEquip;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnEquip -= Equip;
        EventManager.Instance.OnUnEquip -= UnEquip;
    }
    private void Equip(InventoryItem inventoryItem) 
    {
        string equipmentType = inventoryItem.definition.GetStaticProperty("equipmentType").AsString();
        Items.Set(equipmentType, inventoryItem);
    }

    private void UnEquip(InventoryItem inventoryItem) 
    {
        Items.Remove(inventoryItem);
    
    }
}
