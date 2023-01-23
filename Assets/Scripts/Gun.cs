using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour,IActivatable
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float force;

    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    public void Activate()
    {
       if(Time.time >= nextTimeToFire) 
       {
           
            nextTimeToFire = Time.time + 1f / fireRate;
            var go = Instantiate(prefab,spawnPoint.position,spawnPoint.rotation);
            var rb = go.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
            Destroy(go, 5f);
       }
    }
}
