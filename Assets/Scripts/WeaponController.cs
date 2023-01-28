using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;


public abstract class WeaponController : MonoBehaviour
{
        [SerializeField] private Transform weaponsParents;
        [SerializeField] private List<GameObject> weapons;
        [SerializeField] private Equipment equipment;
        [SerializeField] private string equipmentType;
        
        [SerializeField]private int currentId;

        private void OnEnable()
        {
            equipment.OnEquip += Equip;
            equipment.OnUnEquip += UnEquip;
        }
        private void OnDisable()
        {
            equipment.OnEquip -= Equip;
            equipment.OnUnEquip -= UnEquip;
        }

        private void Equip(InventoryItem inventoryItem)
        {
            
            if (inventoryItem.definition.GetStaticProperty("equipmentType").AsString() == equipmentType)
            {
                Debug.Log("Weapon Controller Equip");
                Debug.Log("inventoryItem.definition.displayName " +inventoryItem.definition.displayName);
                //why (Lenght -3) cuz GameObject.name_XX den _XX cikar 
                int id = weapons.FindIndex(go => go.name.Substring(0,go.name.Length-3) == inventoryItem.definition.displayName);
                Debug.Log("Weapon id : " +id);
                EnableWeapon(id);
            }
            
        }

        private void UnEquip(InventoryItem inventoryItem)
        {
            if (inventoryItem.definition.GetStaticProperty("equipmentType").AsString() == equipmentType)
                DisableWeapon();
        }

        private void DisableWeapon()
        {
            if (currentId != -1)
            {
                weapons[currentId].SetActive(false);
                currentId = -1;
            }
        }

        private void EnableWeapon(int id)
        {
            Debug.Log("Weapon Controller EnableWeapon1");
            if (id != -1)
            {
                Debug.Log("Weapon Controller EnableWeapon2");
                weapons[id].SetActive(true);
                currentId = id;
            }
        }

        [ContextMenu("Setup")]
        private void Setup()
        {
            foreach (Transform child in weaponsParents)
            {
                weapons.Add(child.gameObject);                
            }
        }

        public GameObject GetCurrent()
        {
            return currentId == -1 ? null : weapons[currentId];
        }
        
}

