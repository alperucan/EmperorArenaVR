using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class RightControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRIRightHandActions,XRIDefaultInputActions.IXRIRightHandInteractionActions
{
    private XRIDefaultInputActions controls;
    [SerializeField] private Player player;
    [SerializeField] private Text text;
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new XRIDefaultInputActions();
            controls.XRIRightHand.SetCallbacks(this);
        }
        controls.XRIRightHand.Enable();
    }
   /*/// <summary>
   /// TODO "Equip a weapon videosunda player.Equipment var ama hatali unutma"
   /// </summary>
   /// <param name="context"></param>
    void XRIDefaultInputActions.IXRIRightHandInteractionActions.OnActivate(InputAction.CallbackContext context)
    {
       // if (context.performed) 
        //{
          //  var go = player.Equipment.GetCurrentPrimaryWeapon();
           // if(go != null) 
            //{
              //  go.GetComponent<IActivatable>()?.Activate();
           // }
        //}
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
            UIManager.Instance.StatsUI.Hide();
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
            UIManager.Instance.StatsUI.Show();
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
      
    }*/
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
               player.Inventory.Add(item);
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
           // var go = player.Equipment.GetCurrentPrimaryWeapon();
           // if(go != null) 
           //{
           //   go.GetComponent<IActivatable>()?.Activate();
           //}
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
