 using System;
 using System.Collections.Generic;
 using System.Collections.ObjectModel;
 using System.Linq;
 using UnityEngine;

 public class Stat
 {
     public string name;
     [SerializeField] private int baseValue;

     public int BaseValue
     {
         get { return baseValue; }
         set
         {
             baseValue = value;
             CalculateValue();
         }
     }

     private List<StatModifier> modifiers;
     public ReadOnlyCollection<StatModifier> Modifiers => modifiers.AsReadOnly();
     public int Value { get; set; }

     public event Action<Stat> OnChangedValue;

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
     public Stat(string name, int baseValue)
     {
         this.name = name;
         BaseValue = baseValue;
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
