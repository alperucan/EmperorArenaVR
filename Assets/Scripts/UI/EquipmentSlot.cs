using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : BaseSlot
{
    public string equipmentType;
    private void Awake()
    {
        base.Awake();
        // player click on a item UnUequip item
        button.onClick.AddListener(delegate { EventManager.Instance.UnEquip(inventoryItem); });
    }
}
