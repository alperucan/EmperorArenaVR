using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float delay = 3f;
    public float radius = 5f;
    public float expForce = 70f;
    private float countdown;

    private bool hasExploded = false;
    private GameObject explosionEffect;
    private void Start()
    {
        countdown = delay;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject _exp = Instantiate(explosionEffect,transform.position,transform.rotation);
        Destroy(_exp,3);
        Explode();
    }


    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(expForce,transform.position,radius);
            }
        }
    }
}
