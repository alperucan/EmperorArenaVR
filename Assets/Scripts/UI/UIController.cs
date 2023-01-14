using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    private Transform mainCameraTransform;

    private void Awake()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        EventManager.Instance.OnShowUI += SetPosition;
    }

    void SetPosition() 
    {
        transform.position = mainCameraTransform.TransformPoint(new Vector3(0, 0, distance));
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
    }
}
