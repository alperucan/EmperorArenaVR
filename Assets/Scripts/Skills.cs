using System;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private ParticleSystem levelUpVfx;
    [SerializeField] private AudioSource levelUpSfx;
    private List<Skill> skills;

    private void Awake()
    {
        if (skills == null)
        {
            skills = new List<Skill>()
            {
                new Skill(0, 1, 10, SkillType.Combat)
            };
        }
    }

    private void OnEnable()
    {
        foreach (var skill in skills)
        {
            skill.OnlevelUp += LevelUp;
        }

        EventManager.Instance.OnEnemyDied += GainExperience;
    }

    private void OnDisable()
    {
        foreach (var skill in skills)
        {
            skill.OnlevelUp -= LevelUp;
        }
        
        EventManager.Instance.OnEnemyDied -= GainExperience;
        
    }

    public Skill this[SkillType type]
    {
        get => skills.Find(skill => skill.Type == type);
        set
        {
            int index = skills.FindIndex(skill => skill.Type == type);
            if (index == -1)
                skills[index] = value;
            else
                skills.Add(value);
                
        }
    }
    
    private void LevelUp(Skill skill)
    {
        if (levelUpSfx)
            levelUpSfx.Play();
        if(levelUpVfx)
            levelUpVfx.Play();
        
        
    }

    private void GainExperience(Enemy enemy)
    {
        this[SkillType.Combat].CurrentExperience += enemy.definition.experienceReward;
    }
}
