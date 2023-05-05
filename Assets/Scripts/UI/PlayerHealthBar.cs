using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


    public class PlayerHealthBar : BaseUI
    {
          
       /* [SerializeField] private Player player;
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
            player.OnTakeDamage += Refresh;
        }

        private void OnDestroy()
        {
            enemy.OnTakeDamage -= Refresh;
        }
        private void Refresh(int damage)
        {
            if (player.Stats[StatType.HEALTH].Value == 0)
            {
                Hide();
            }
            else
            {
                if (canvasGroup.alpha == 0)
                {
                    Show();    
                }
                else
                {
                    StopCoroutine(coroutine);
                }

                coroutine = StartCoroutine(Wait());
                slider.value = enemy.health.CurrentValue;
            }
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(delay);
            Hide();
        }*/
    }
