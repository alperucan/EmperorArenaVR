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
    }
    private void DisableUIMode() 
    {
        actionBasedContinuousMoveProvider.enabled = true;
        actionBasedContinuousTurnProvider.enabled = true;
        leftHandRayInteractor.SetActive(false);
        rightHandRayInteractor.SetActive(false);
        leftHandDirectInteractor.SetActive(true);
        rightHandDirectInteractor.SetActive(true);
       
    }
}
