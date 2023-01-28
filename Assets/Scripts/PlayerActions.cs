using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class PlayerActions : MonoBehaviour, PlayerControls.IGameplayActions
{
    private PlayerControls controls;
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;
    private Camera mainCamera;
    private Inventory inventory;
    private static readonly int MovementSpeed = Animator.StringToHash("movementSpeed");

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        mainCamera=Camera.main;
    }

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new PlayerControls();
            controls.Gameplay.SetCallbacks(this);
        }
        controls.Gameplay.Enable();
        EventManager.Instance.OnShowUI += controls.Gameplay.Disable;
        EventManager.Instance.OnHideUI += controls.Gameplay.Enable;
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
        EventManager.Instance.OnShowUI += controls.Gameplay.Disable;
        EventManager.Instance.OnHideUI += controls.Gameplay.Enable;
    }

    private void Update()
    {
        Vector3 relativeVelocity = transform.InverseTransformDirection(agent.velocity);
        animator.SetFloat(MovementSpeed,relativeVelocity.magnitude);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("aasdad");
            Vector2 mousePosition = controls.Gameplay.Move.ReadValue<Vector2>();
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
               // Debug.Log(mousePosition);
                agent.SetDestination(hit.point);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
       
    }

    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UIManager.Instance.InventoryUI.Show();

        }
    }

    public void OnOpenEquipment(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UIManager.Instance.EquipmentUI.Show();
        }
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //text.text = "OnSelect Right";
            var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Item"));
            foreach (var hit in hits)
            {
                var item = hit.GetComponent<Item>();
                inventory.Add(item);
            }
        }
    }
}