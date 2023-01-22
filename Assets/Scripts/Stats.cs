using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;


public class Stats : MonoBehaviour
    {
        public event Action OnInitialized;
        private List<Stat> stats;

        private void OnEnable()
        {
            EventManager.Instance.OnEquip += AddEquipmentModifiers;
            EventManager.Instance.OnUnEquip += RemoveEquipmentModifiers;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnEquip -= AddEquipmentModifiers;
            EventManager.Instance.OnUnEquip -= RemoveEquipmentModifiers;
        }

        private void Start()
        {
            if (stats == null)
            {
                stats = new List<Stat>()
                {
                    new Stat(StatType.STRENGTH, 5),
                    new Stat(StatType.CONSTITUTION, 5),
                    new Stat(StatType.WISDOM, 5),
                    new Stat(StatType.INTELLIGENCE, 5),
                    new Stat(StatType.CHARISMA, 5),
                    new Stat(StatType.DEXTERITY, 5),
                    new Stat(StatType.PHYSICAL_ATTACK, 5),
                    new Stat(StatType.PHYSICAL_DEFENSE, 5),
                    new Stat(StatType.MAGIC_ATTACK, 5),
                    new Stat(StatType.MAGIC_DEFENSE, 5),
                    new DynamicStat(StatType.HEALTH, 100),
                    new DynamicStat(StatType.MANA, 100)
                };

            }
            OnInitialized?.Invoke();
        }

        public Stat this[string name]
        {
            get => stats.Find(stat => stat.name == name);
            set
            {
                int index = stats.FindIndex(stat => stat.name == name);
                if (index == -1)
                    stats[index] = value;
                else
                    stats.Add(value);
                
            }
        }

        private void AddEquipmentModifiers(InventoryItem inventoryItem)
        {
            foreach (var mutableProperty in inventoryItem.GetMutableProperties())
            {
                Stat stat = stats.Find(s => s.name == mutableProperty.Key);
                stat.AddModifier(new StatModifier(mutableProperty.Value.AsInt(),ModifierType.Flat));
            }
        }
        private void RemoveEquipmentModifiers(InventoryItem inventoryItem)
        {
            foreach (var mutableProperty in inventoryItem.GetMutableProperties())
            {
                Stat stat = stats.Find(s => s.name == mutableProperty.Key);
                stat.RemoveModifier(new StatModifier(mutableProperty.Value.AsInt(),ModifierType.Flat));
            }
        }
    }
