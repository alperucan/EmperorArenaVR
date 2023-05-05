using System;
using UnityEngine;

[System.Serializable]
public struct WeatherData
{
        public string name;
        public ParticleSystem particleSystem;
        [HideInInspector] public ParticleSystem.EmissionModule emission;

        
}