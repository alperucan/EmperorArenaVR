using System;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : BaseUI
{
    private Slider slider;
    [SerializeField] private Enemy enemy;
    protected override void Awake()
    {
        base.Awake();
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = enemy.health.Value;
        enemy.health.OnChangedCurrentValue += Refresh;
    }

    private void OnDestroy()
    {
        enemy.health.OnChangedCurrentValue -= Refresh;
    }

    private void Refresh(DynamicStat dynamicStat)
    {
        if (dynamicStat.CurrentValue==0)
        {
            Hide();
        }
        else
        {
            slider.value = dynamicStat.CurrentValue;
            Show();
        }
        
    }
}
