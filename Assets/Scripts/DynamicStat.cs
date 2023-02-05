
    using System;
    using UnityEngine;
    using System.Collections.Generic;
    public class DynamicStat : Stat
    {
        [SerializeField]private int currentValue;
        public event Action<DynamicStat> OnChangedCurrentValue;
        public int CurrentValue {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = Mathf.Clamp(value, 0, Value);
                OnChangedCurrentValue?.Invoke(this);
            }
            
            
        }
       

        public DynamicStat(string name, int baseValue) : base(name, baseValue)
        {
            CurrentValue = baseValue;
        }
        public DynamicStat(string name, int baseValue, List<StatModifier> modifiers, int value, int currentValue) : base(name, baseValue, modifiers, value)
        {
            CurrentValue = currentValue;
        }
    }
