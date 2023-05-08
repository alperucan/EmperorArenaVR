using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class RightControllerActions : MonoBehaviour, XRIDefaultInputActions.IXRIRightHandActions,XRIDefaultInputActions.IXRIRightHandInteractionActions
{
    private XRIDefaultInputActions controls;
    [SerializeField] private PrimaryWeaponController primaryWeaponController;
    [SerializeField] private Text text;
    //[SerializeField] private Inventory inventory;
    [SerializeField] private Player player;
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
           Debug.Log("deneme");
           text.text = "Right Click OnPrimaryButtonPress";
           var hits = Physics.OverlapSphere(transform.position, 1f, 1 << LayerMask.NameToLayer("Item"));
           foreach (var hit in hits)
           {
               var item = hit.GetComponent<Item>();
               player.Inventory.Add(item);
           } 
       }
   }

   public void OnSecondaryButtonPress(InputAction.CallbackContext context)
   {
       if (context.performed)
       {
           text.text = "Right Click OnSecondaryButtonPress";
           var go = primaryWeaponController.GetCurrent();
           if (go != null)
               go.GetComponent<IActivatable>()?.Activate();
       }
   }

   public void OnTriggerButtonPress(InputAction.CallbackContext context)
   {
       /*if (context.performed)
       {
           var go = GameObject.FindGameObjectWithTag("Staff").GetComponent<FireStaff>();
           if(go!=null)
               go.throwFireball();

       }*/
   }

   /// <summary>
    /// Itemi yerden alma
    /// </summary>
    /// <param name="context"></param>
   public void OnSelect(InputAction.CallbackContext context)
   {
       if (context.performed)
       {
           // text.text = "Right Click OnSelect";
           // var hits = Physics.OverlapSphere(transform.position, 1f, 1 << LayerMask.NameToLayer("Item"));
           // foreach (var hit in hits)
           // {
           //     var item = hit.GetComponent<Item>();
           //     player.Inventory.Add(item);
           // } 
       }
   }

   public void OnSelectValue(InputAction.CallbackContext context)
   {
      // throw new System.NotImplementedException();
   }
   /// TODO "Equip a weapon videosunda player.Equipment var ama hatali unutma"
   
   /// <summary>
   /// Itemi giyme 
   /// </summary>
   /// <param name="context"></param>
   public void OnActivate(InputAction.CallbackContext context)
   {
       // if (context.performed)
       // {
       //     text.text = "Right Click OnActivate";
       //     var go = primaryWeaponController.GetCurrent();
       //     if (go != null)
       //         go.GetComponent<IActivatable>()?.Activate();
       // }
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
