using System;
using System.Collections.Generic;
using UnityEngine;


    public class Stats : MonoBehaviour
    {
        public event Action OnInitialized;
        private List<Stat> stats;

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
        
    }
