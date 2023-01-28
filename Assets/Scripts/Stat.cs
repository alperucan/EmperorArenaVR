 using System;
 using System.Collections.Generic;
 using System.Collections.ObjectModel;
 using System.Linq;
 using UnityEngine;

 [Serializable]
 public class Stat : BaseStat
 {
     public event Action<Stat> OnChangedValue; 

     public virtual int BaseValue
     {
         get { return baseValue; }
         set
         {
             baseValue = value;
             CalculateValue();
         }
     }

     
     
     public int Value { get; set; }
     private List<StatModifier> modifiers;
     public ReadOnlyCollection<StatModifier> Modifiers => modifiers.AsReadOnly();
     
     public void AddModifier(StatModifier modifier)
     {
         modifiers.Add(modifier);
         CalculateValue();
     }

     public void RemoveModifier(StatModifier modifier)
     {
         modifiers.Remove(modifier);
         CalculateValue();
     }
     public Stat(string name, int baseValue): base(name,baseValue)
     {
         modifiers = new List<StatModifier>();
         Value = baseValue;

     }

     private void CalculateValue()
     {
         Value = baseValue;
         foreach (var modifier in modifiers.Where(modifier=> modifier.type==ModifierType.Flat))
         {
             Value += modifier.value;
         }
         foreach (var modifier in modifiers.Where(modifier=> modifier.type==ModifierType.Flat))
         {
             Value *= modifier.value;
         }
         OnChangedValue?.Invoke(this);
     }
 }
