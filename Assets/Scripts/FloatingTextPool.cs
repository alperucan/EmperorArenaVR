﻿using System;
using UnityEngine;


public class FloatingTextPool : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameObject eperienceTextPrefab;
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private float initialHeight = 1f;

    private void OnEnable()
    {
        enemy.OnTakeDamage += ShowDamage;
        enemy.OnDied += ShowExperienceReward;
    }

    private void OnDisable()
    {
        enemy.OnTakeDamage -= ShowDamage;
        enemy.OnDied -= ShowExperienceReward;
    }

    private void ShowDamage(int damage)
    {
        var floatingText = Instantiate(damageTextPrefab, transform.position, transform.rotation, transform);

        floatingText.transform.localPosition = new Vector3(0, initialHeight, 0);

        floatingText.GetComponent<TextMesh>().text = $"{damage}";
    }

    private void ShowExperienceReward()
    {
        var floatingText = Instantiate(damageTextPrefab, transform.position, transform.rotation);
        
        floatingText.GetComponent<TextMesh>().text=$"{enemy.definition.experienceReward}";

    }
}
