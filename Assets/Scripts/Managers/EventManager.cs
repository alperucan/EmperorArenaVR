using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class EventManager : Singleton<EventManager>
{
    public event Action OnShowUI;
    public event Action OnHideUI;

    public void ShowUI() => OnShowUI?.Invoke();
    public void HideUI() => OnShowUI?.Invoke();


    public event Action<InventoryItem> OnEquip;
    public event Action<InventoryItem> OnUnEquip;

    public void Equip(InventoryItem inventoryItem) => OnEquip?.Invoke(inventoryItem);
    public void UnEquip(InventoryItem inventoryItem) => OnUnEquip?.Invoke(inventoryItem);

    public event Action<Enemy> OnEnemyDied;

    public void EnemyDied(Enemy enemy) => OnEnemyDied?.Invoke(enemy);
}
