using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject leftHandRayInteractor;
    [SerializeField] private GameObject rightHandRayInteractor;
    [SerializeField] private GameObject leftHandDirectInteractor;
    [SerializeField] private GameObject rightHandDirectInteractor;
    [SerializeField] private ActionBasedContinuousMoveProvider actionBasedContinuousMoveProvider;
    [SerializeField] private ActionBasedContinuousTurnProvider actionBasedContinuousTurnProvider;

    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftHand;
    
    public Inventory Inventory { get; private set; }
    private void Awake()
    {
        Inventory = GetComponent<Inventory>();
    }

    private void OnEnable()
    {
        EventManager.Instance.OnShowUI += EnableUIMode;
        EventManager.Instance.OnHideUI += DisableUIMode;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnShowUI -= EnableUIMode;
        EventManager.Instance.OnHideUI -= DisableUIMode;
    }
    private void EnableUIMode()
    {
        actionBasedContinuousMoveProvider.enabled = false;
        actionBasedContinuousTurnProvider.enabled = false;
        leftHandDirectInteractor.SetActive(false);
        rightHandDirectInteractor.SetActive(false);
        leftHandRayInteractor.SetActive(true);
        rightHandRayInteractor.SetActive(true);
        
        leftHand.parent = leftHandRayInteractor.transform;
        leftHand.localPosition = Vector3.zero;
        leftHand.localRotation =Quaternion.Euler(-90,180,-90);
        rightHand.parent = rightHandRayInteractor.transform;
        rightHand.localPosition =Vector3.zero;
        rightHand.localRotation=Quaternion.Euler(90,0,90);
    }
    private void DisableUIMode() 
    {
        actionBasedContinuousMoveProvider.enabled = true;
        actionBasedContinuousTurnProvider.enabled = true;
        leftHandRayInteractor.SetActive(false);
        rightHandRayInteractor.SetActive(false);
        leftHandDirectInteractor.SetActive(true);
        rightHandDirectInteractor.SetActive(true);
        
        leftHand.parent = leftHandRayInteractor.transform;
        leftHand.localPosition = Vector3.zero;
        leftHand.localRotation =Quaternion.Euler(-90,180,-90);
        rightHand.parent = rightHandRayInteractor.transform;
        rightHand.localPosition =Vector3.zero;
        rightHand.localRotation=Quaternion.Euler(90,0,90);
       
    }
}
