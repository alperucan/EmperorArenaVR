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
        
        private int currentId;

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
                if(currentId != -1)
                    DisableWeapon();

                int id = weapons.FindIndex(weapon => weapon.name == inventoryItem.definition.displayName);
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
            weapons[currentId].SetActive(false);
            currentId = -1;
        }

        private void EnableWeapon(int id)
        {
            weapons[id].SetActive(true);
            currentId = id;
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

