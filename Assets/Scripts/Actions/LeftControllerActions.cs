using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRILeftHandActions,XRIDefaultInputActions.IXRILeftHandInteractionActions
{
    private XRIDefaultInputActions controls;
    [SerializeField] private Player player;

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnActivate(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnActivateValue(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRILeftHandActions.OnHapticDevice(InputAction.CallbackContext context)
    {
    }

    void XRIDefaultInputActions.IXRILeftHandActions.OnPosition(InputAction.CallbackContext context)
    {
        
    }

    void XRIDefaultInputActions.IXRILeftHandActions.OnPrimaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            UIManager.Instance.InventoryUI.Show();
        }
    }

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnRotateAnchor(InputAction.CallbackContext context)
    {
      
    }

    void XRIDefaultInputActions.IXRILeftHandActions.OnRotation(InputAction.CallbackContext context)
    {
      
    }

    void XRIDefaultInputActions.IXRILeftHandActions.OnSecondaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UIManager.Instance.EquipmentUI.Show();
        }
    }

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Item"));
            foreach(var hit in hits) 
            {
                var item = hit.GetComponent<Item>();
                player.Inventory.Add(item);
            }
        }
    }

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnSelectValue(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRILeftHandActions.OnTrackingState(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnTranslateAnchor(InputAction.CallbackContext context)
    {
        
    }

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnUIPress(InputAction.CallbackContext context)
    {
       
    }

    void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnUIPressValue(InputAction.CallbackContext context)
    {
        
    }
}
