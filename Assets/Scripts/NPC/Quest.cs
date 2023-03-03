﻿
using UnityEngine;

[System.Serializable] 
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
     
    
    public int expReward;
    public int goldReward;

    public QuestGoal goal;
}