using UnityEngine;
using UnityEngine.UI;


public class BaseStatUI : MonoBehaviour
    {
        [SerializeField] private Text value;
        public string statName;

        public virtual void Refresh(Stat stat)
        {
            value.text = stat.Value.ToString();
        }
    }
