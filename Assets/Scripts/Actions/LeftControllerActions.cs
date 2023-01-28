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
            UIManager.Instance.Hide();
        }
    }

    public void OnSecondaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UIManager.Instance.Show(Constants.UI.RADIAL_MENU);
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
