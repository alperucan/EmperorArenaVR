using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Stats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        enemy.TakeDamage(playerStats);
    }
}
