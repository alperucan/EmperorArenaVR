using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class RightControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRIRightHandActions,XRIDefaultInputActions.IXRIRightHandInteractionActions
{
    private XRIDefaultInputActions controls;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Text text;
    [SerializeField] private Inventory inventory;
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new XRIDefaultInputActions();
            controls.XRIRightHand.SetCallbacks(this);
        }
        controls.XRIRightHand.Enable();
    }
  
   public void OnPosition(InputAction.CallbackContext context)
   {
      // throw new System.NotImplementedException();
   }

   public void OnRotation(InputAction.CallbackContext context)
   {
       //throw new System.NotImplementedException();
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
           text.text = "Primary Button Press Right";
           UIManager.Instance.StatsUI.Hide();
       }
   }

   public void OnSecondaryButtonPress(InputAction.CallbackContext context)
   {
       if (context.performed)
       {
           text.text = "OnSecondaryButtonPress Right";
           UIManager.Instance.StatsUI.Show();
       }
   }

   public void OnSelect(InputAction.CallbackContext context)
   {
       if (context.performed)
       {
           text.text = "OnSelect Right";
           var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Item"));
           foreach (var hit in hits)
           {
               var item = hit.GetComponent<Item>();
               inventory.Add(item);
           }
       }
   }

   public void OnSelectValue(InputAction.CallbackContext context)
   {
      // throw new System.NotImplementedException();
   }
   /// TODO "Equip a weapon videosunda player.Equipment var ama hatali unutma"
   public void OnActivate(InputAction.CallbackContext context)
   {
       if (context.performed)
       {
           text.text = "OnActivate Right";
           var go = weaponController.GetCurrent();
           if(go !=null)
               go.GetComponent<IActivatable>()?.Activate();
       }
   }

   public void OnActivateValue(InputAction.CallbackContext context)
   {
       //throw new System.NotImplementedException();
   }

   public void OnUIPress(InputAction.CallbackContext context)
   {
       //throw new System.NotImplementedException();
   }

   public void OnUIPressValue(InputAction.CallbackContext context)
   {
       //throw new System.NotImplementedException();
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
