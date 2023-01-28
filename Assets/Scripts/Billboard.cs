using System;
using UnityEngine;

 public class Billboard : MonoBehaviour
 {
     private Transform mainCamera;

     private void Start()
     {
         mainCamera = Camera.main.transform;
     }

     private void LateUpdate()
     {
         transform.LookAt(mainCamera.transform);
     } 
 } 