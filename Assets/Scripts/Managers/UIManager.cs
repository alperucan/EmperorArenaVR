using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public InventoryUI InventoryUI;
    public EquipmentUI EquipmentUI;
    public StatsUI StatsUI;
    public CharacterSelectionUI characterSelectionUI;
}
