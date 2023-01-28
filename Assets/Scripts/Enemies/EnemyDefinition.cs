using System;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/New Enemy", order = 0)]
public class EnemyDefinition : ScriptableObject
{
    public BaseStat[] baseStats;
    public string enemyName;
    public BaseStat health;
    public BaseStat mana;
    public int experienceReward;

    private void Reset()
    {
        baseStats = new[]
        {
            new BaseStat(StatType.PHYSICAL_ATTACK, 0),
            new BaseStat(StatType.MAGIC_ATTACK, 0),
            new BaseStat(StatType.PHYSICAL_DEFENSE, 0),
            new BaseStat(StatType.MAGIC_DEFENSE, 0),
        };
        health = new BaseStat(StatType.HEALTH,100);
        mana = new BaseStat(StatType.MANA,100);
    }
}
