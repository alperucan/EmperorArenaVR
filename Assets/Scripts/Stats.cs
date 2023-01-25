using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;


public class Stats : MonoBehaviour
    {
        public event Action OnInitialized;
        private List<Stat> stats;
        private int availablePoints;
        public int AvailablePoints => availablePoints;
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
               Initialize();
            }
           
        }

        public void SpendPoints(int points,string statName)
        {
            if (points > 0 && points <= availablePoints)
            {
                Stat stat = this[statName];
                if (stat != null)
                {
                    stat.BaseValue += points;
                    availablePoints -= points;
                }

            }
        }

        public void Initialize()
        {
            stats = new List<Stat>()
            {
                new Stat(StatType.STRENGTH, 1),
                new Stat(StatType.CONSTITUTION, 1),
                new Stat(StatType.WISDOM, 1),
                new Stat(StatType.INTELLIGENCE, 1),
                new Stat(StatType.CHARISMA, 1),
                new Stat(StatType.DEXTERITY, 1),
                new Stat(StatType.PHYSICAL_ATTACK, 0),
                new Stat(StatType.PHYSICAL_DEFENSE, 0),
                new Stat(StatType.MAGIC_ATTACK, 0),
                new Stat(StatType.MAGIC_DEFENSE, 0),
                new DynamicStat(StatType.HEALTH, 100),
                new DynamicStat(StatType.MANA, 100)
            };
            availablePoints = 15;

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
