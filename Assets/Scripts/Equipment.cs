using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Equipment : MonoBehaviour
{
    public ItemMap Items { get; private set; }
  
   
    public event Action<InventoryItem> OnEquip;
    public event Action<InventoryItem> OnUnEquip;

   // public void Equip(InventoryItem inventoryItem) => OnEquip?.Invoke(inventoryItem);
   // public void UnEquip(InventoryItem inventoryItem) => OnUnEquip?.Invoke(inventoryItem);
    
   
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
  
    
    public void Equip(InventoryItem inventoryItem) 
    {
        string equipmentType = inventoryItem.definition.GetStaticProperty("equipmentType").AsString();
        Items.Set(equipmentType, inventoryItem);
       // string type = inventoryItem.definition.GetStaticProperty("type").AsString();
        //if(type=="weapon")
          //  EnablePrimaryWeapon(inventoryItem);
       OnEquip?.Invoke(inventoryItem);   
    }

    public void UnEquip(InventoryItem inventoryItem) 
    {
        Items.Remove(inventoryItem);
        OnUnEquip?.Invoke(inventoryItem);
        // string type = inventoryItem.definition.GetStaticProperty("type").AsString();
        //if(type=="weapon")
          //  DisablePrimaryWeapon();
       
    
    }


}
