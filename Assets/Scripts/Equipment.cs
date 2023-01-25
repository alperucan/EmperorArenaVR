using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Equipment : MonoBehaviour
{
    public ItemMap Items { get; private set; }
    [SerializeField] private Transform primaryWeaponParent;
    private List<GameObject> primaryWeapons = new List<GameObject>();
    private int currentPrimaryWeaponId = 1;
   
    private void Awake()
    {
        foreach(Transform child in primaryWeaponParent) 
        {
            primaryWeapons.Add(child.gameObject);
        }
    }
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
    public GameObject GetCurrentPrimaryWeapon() 
    {
        return currentPrimaryWeaponId != -1 ? primaryWeapons[currentPrimaryWeaponId] : null;
    }
    public void Equip(InventoryItem inventoryItem) 
    {
        string equipmentType = inventoryItem.definition.GetStaticProperty("equipmentType").AsString();
        Items.Set(equipmentType, inventoryItem);
        string type = inventoryItem.definition.GetStaticProperty("type").AsString();
        if(type=="weapon")
            EnablePrimaryWeapon(inventoryItem);
    }

    public void UnEquip(InventoryItem inventoryItem) 
    {
        Items.Remove(inventoryItem);
        string type = inventoryItem.definition.GetStaticProperty("type").AsString();
        if(type=="weapon")
            DisablePrimaryWeapon();
       
    
    }
    private void EnablePrimaryWeapon(InventoryItem inventoryItem) 
    {
        int id = primaryWeapons.FindIndex(go => go.name == inventoryItem.definition.displayName);
        primaryWeapons[id].SetActive(true);
        currentPrimaryWeaponId = id;
    }
    private void DisablePrimaryWeapon() 
    {
        primaryWeapons[currentPrimaryWeaponId].SetActive(false);
        currentPrimaryWeaponId = -1;
        
    }

}
