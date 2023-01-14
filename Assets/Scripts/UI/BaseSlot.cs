using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.UI;

public class BaseSlot : MonoBehaviour
{
    public InventoryItem inventoryItem;
    protected Image image;
    protected Button button;


    protected void Awake()
    {
        Transform icon = transform.Find("Icon");
        image = icon.GetComponent<Image>();
        
    }

    public void Set(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
        image.sprite = inventoryItem.definition.GetStaticProperty("Sprite").AsAsset<Sprite>();
        image.enabled = true;
    }
    public void UnSet()
    {
        inventoryItem = null;
        image.sprite = null;
        image.enabled = false;

    }
}
