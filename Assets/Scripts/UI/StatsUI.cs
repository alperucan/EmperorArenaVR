using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class StatsUI : BaseUI
    {
        [SerializeField] private Stats stats;
        [SerializeField] private Transform statParent;
        [SerializeField] private Transform primaryStatParent;
        [SerializeField] private Transform dynamicStatParent;
        [SerializeField] private Button close;
        
        private List<BaseStatUI> statUis;
        private List<PrimaryStatUI> primaryStatUis;
        private List<DynamicStatUI> dynamicStatUis;

        private void Awake()
        {
            base.Awake();
            statUis = statParent.GetComponentsInChildren<BaseStatUI>(true).ToList();
            primaryStatUis = primaryStatParent.GetComponentsInChildren<PrimaryStatUI>(true).ToList();
            dynamicStatUis = dynamicStatParent.GetComponentsInChildren<DynamicStatUI>(true).ToList();
            stats.OnInitialized += Refresh;
            close.onClick.AddListener(delegate { Hide(); });
        }

        private void Refresh()
        {
            foreach (var statUi in statUis)
            {
                Stat stat = stats[statUi.statName];
                statUi.Refresh(stat);
                stat.OnChangedValue += statUi.Refresh;
            }
            foreach (var primaryStatUi in primaryStatUis)
            {
                Stat stat = stats[primaryStatUi.statName];
                primaryStatUi.Refresh(stat);
                stat.OnChangedValue += primaryStatUi.Refresh;
            }

            foreach (var dynamicStatUi in dynamicStatUis)
            {
                DynamicStat dynamicStat = stats[dynamicStatUi.statName] as DynamicStat;
                dynamicStatUi.Refresh(dynamicStat);
                dynamicStat.OnChangedValue += dynamicStatUi.Refresh;
                dynamicStat.OnChangedCurrentValue += dynamicStatUi.Refresh;
            }
        }
    }
