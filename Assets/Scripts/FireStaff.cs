using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.Demos;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FireStaff : MonoBehaviour
{
   
    public GameObject fireballPrefab;
    
    public float throwForce = 20f;
    private Vector3 currentPos;
    private bool isEquipped = false;
   
   

    // Update is called once per frame
    void Update()
    {
    
    }
    
    public void throwFireball()
    {
        if (isEquipped)
        {
            GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce);
        }
       
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isEquipped = true;
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isEquipped = false;
        }
    }

   
}
