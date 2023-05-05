using System;
using UnityEngine;
using UnityEngine.UI;


    public class PlayerHealthBar : BaseUI
    {
          
        [SerializeField] private Player player;
        [SerializeField] private float delay = 10f;
        private Slider slider;
        private Coroutine coroutine;
      
        protected void Awake()
        {
            base.Awake();
            slider = GetComponent<Slider>();
        }

        private void Start()
        {
            slider.maxValue = player.Stats[StatType.HEALTH].Value;
            
        }
    
    }
