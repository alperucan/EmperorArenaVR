using UnityEngine;
using UnityEngine.UI;


public class DynamicStatUI : BaseStatUI
{
    [SerializeField] private Text currentValue;

    public override void Refresh(Stat stat)
    {
        base.Refresh(stat);
        currentValue.text = (stat as DynamicStat).CurrentValue.ToString();
    }
}
