using UnityEngine;
using UnityEngine.InputSystem;


    public class UIActions : MonoBehaviour, PlayerControls.IUIActions
    {
        private PlayerControls controls;
        private void OnEnable()
        {
            if (controls == null)
            {
                controls = new PlayerControls();
                controls.UI.SetCallbacks(this);
            }
           // Debug.Log("UIActions enabled");
            UIManager.Instance.OnShowUI += controls.UI.Enable;
            UIManager.Instance.OnHideUI += controls.UI.Disable;
        }

        private void OnDisable()
        {
            UIManager.Instance.OnShowUI -= controls.UI.Enable;
            UIManager.Instance.OnHideUI -= controls.UI.Disable;
        }

        public void OnCloseMenu(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
               // Debug.Log("Close Radial menu");
                UIManager.Instance.Hide();
            }
        }
    }
