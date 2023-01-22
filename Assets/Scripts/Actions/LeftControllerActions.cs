using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LeftControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRILeftHandActions,XRIDefaultInputActions.IXRILeftHandInteractionActions
{
    private XRIDefaultInputActions controls;
    [SerializeField] private Player player;
    [SerializeField] private Text text;
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new XRIDefaultInputActions();
            controls.XRILeftHand.SetCallbacks(this);
        }
        controls.XRILeftHand.Enable();
    }
    /*void XRIDefaultInputActions.IXRILeftHandInteractionActions.OnActivate(InputAction.CallbackContext context)
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
            Debug.Log(" Left OnPrimaryButtonPress");
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
            Debug.Log(" Left OnSecondaryButtonPress");
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
        
    }*/
    public void OnPosition(InputAction.CallbackContext context)
    {
      //  throw new System.NotImplementedException();
    }

    public void OnRotation(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnTrackingState(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnHapticDevice(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnPrimaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            text.text = "OnSecondaryButtonPress Left";
            UIManager.Instance.InventoryUI.Show();
        }
    }

    public void OnSecondaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            text.text = "OnSecondaryButtonPress Left";
            UIManager.Instance.EquipmentUI.Show();
        }
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            text.text = "OnSelect Left";
            var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Item"));
            foreach(var hit in hits) 
            {
                var item = hit.GetComponent<Item>();
                player.Inventory.Add(item);
            }
        }
    }

    public void OnSelectValue(InputAction.CallbackContext context)
    {
      //  throw new System.NotImplementedException();
    }

    public void OnActivate(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnActivateValue(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUIPress(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUIPressValue(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }

    public void OnRotateAnchor(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnTranslateAnchor(InputAction.CallbackContext context)
    {
       // throw new System.NotImplementedException();
    }
}
