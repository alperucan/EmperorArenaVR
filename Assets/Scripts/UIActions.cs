using UnityEngine;
using UnityEngine.InputSystem;


public class UIActions : MonoBehaviour,PlayerControls.IUIActions
{
    private PlayerControls controls;
        private void OnEnable()
        {
            if (controls == null)
            {
                controls = new PlayerControls();
                controls.UI.SetCallbacks(this);
            }

            EventManager.Instance.OnShowUI += controls.UI.Enable;
            EventManager.Instance.OnHideUI += controls.UI.Disable;

        }

        private void OnDisable()
        {
            EventManager.Instance.OnShowUI -= controls.UI.Enable;
            EventManager.Instance.OnHideUI -= controls.UI.Disable;
        }
        public void OnCloseInventory(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                UIManager.Instance.InventoryUI.Hide();
            }
        }

        public void OnCloseEquipment(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                UIManager.Instance.EquipmentUI.Hide();
            }
        }
    }
