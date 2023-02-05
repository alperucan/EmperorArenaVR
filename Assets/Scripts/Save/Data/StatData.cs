using System;
using System.Collections.Generic;

[Serializable]
public struct StatData
{
    public string name;
    public int baseValue;
    public int value;
    public List<StatModifier> modifiers;
}
