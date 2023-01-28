using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.UI;

public class InventorySlot : BaseSlot
{
    // private void Awake()
    // {
    //     base.Awake();
    //     // player click on a item, equip the item
    //     button.onClick.AddListener( delegate { EventManager.Instance.Equip(inventoryItem); } );
    // //     button.onClick.AddListener(delegate
    // //     {
    // //         
    // //         if (inventoryItem != null)
    // //         {
    // //             Debug.Log("Inventory slot clicked!");
    // //             equipment.UnEquip(inventoryItem);
    // //         }
    // //             
    // //     });
    // }
    private void Awake()
    {
        base.Awake();
        button.onClick.AddListener(delegate
        {
            if (inventoryItem != null)
                equipment.Equip(inventoryItem);
        });
    }
}
