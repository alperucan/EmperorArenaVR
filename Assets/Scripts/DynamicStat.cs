
    using System;
    using UnityEngine;

    public class DynamicStat : Stat
    {
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
        private int currentValue;
        public event Action<DynamicStat> OnChangedCurrentValue;

        public DynamicStat(string name, int baseValue) : base(name, baseValue)
        {
            CurrentValue = baseValue;
        }
    }
