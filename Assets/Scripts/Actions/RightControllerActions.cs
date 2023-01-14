using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRIRightHandActions,XRIDefaultInputActions.IXRIRightHandInteractionActions
{
    private XRIDefaultInputActions controls;
    [SerializeField] private Player player;

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnActivate(InputAction.CallbackContext context)
    {
      
    }

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnActivateValue(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandActions.OnHapticDevice(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandActions.OnPosition(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandActions.OnPrimaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Right Controller Primary Button Pressed");
        }
    }

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnRotateAnchor(InputAction.CallbackContext context)
    {
    
    }

    void XRIDefaultInputActions.IXRIRightHandActions.OnRotation(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandActions.OnSecondaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Right Controller Secondary Button Pressed");
        }
    }

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Item"));
            foreach (var hit in hits)
            {
                var item = hit.GetComponent<Item>();
                player.Inventory.Add(item);
            }
        }
    }

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnSelectValue(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandActions.OnTrackingState(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnTranslateAnchor(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnUIPress(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnUIPressValue(InputAction.CallbackContext context)
    {
      
    }
}
