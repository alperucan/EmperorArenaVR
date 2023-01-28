using System;
using UnityEngine;

[Serializable]
public enum SkillType
{
    Combat
}
[Serializable]
public class Skill
{
    [SerializeField] private int requiredExperience;
    [SerializeField] private int currentExperience;
    [SerializeField] private int level;
    [SerializeField] private SkillType type;
    public event Action<Skill> OnlevelUp; 

    public SkillType Type
    {
        get { return this.type; }
    }

    public int Level
    {
        get { return this.level; }
    }
    public int CurrentExperience
    {
        get { return this.currentExperience; }
        set
        {
            if (currentExperience + value >= requiredExperience)
            {
                currentExperience = currentExperience + value - requiredExperience;
                requiredExperience *= 2;
                level += 1;
                OnlevelUp?.Invoke(this);
            }
            else
            {
                currentExperience += value;
            }
        }
    }
    public int RequiredExperience
    {
        get { return this.requiredExperience; }
    }

    public Skill(int currentExperience, int level, int requiredExperience, SkillType type)
    {
        this.currentExperience = currentExperience;
        this.level = level;
        this.requiredExperience = requiredExperience;
        this.type = type;
    }
    
}
