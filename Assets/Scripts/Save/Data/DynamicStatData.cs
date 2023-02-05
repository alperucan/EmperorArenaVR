using System;
using System.Collections.Generic;
[Serializable]
public struct DynamicStatData
{
    public string name;
    public int baseValue;
    public int value;
    public int currentValue;
    public List<StatModifier> modifiers;
}
