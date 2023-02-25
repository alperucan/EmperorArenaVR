using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class GameplayActions : MonoBehaviour, PlayerControls.IGameplayActions
{
    [SerializeField]private PlayerControls controls;
    [SerializeField]private Animator animator;
    [SerializeField]private NavMeshAgent agent;
    [SerializeField]private Camera mainCamera;
    [SerializeField]private Inventory inventory;
    private static readonly int MovementSpeed = Animator.StringToHash("movementSpeed");

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        mainCamera=Camera.main;
    }

    private void OnEnable()
    {
        //Debug.Log("GameplayActions enable");
        if (controls == null)
        {
            controls = new PlayerControls();
            controls.Gameplay.SetCallbacks(this);
        }
        controls.Gameplay.Enable();
        UIManager.Instance.OnShowUI += controls.Gameplay.Disable;
        UIManager.Instance.OnHideUI += controls.Gameplay.Enable;
    }

    private void OnDisable()
    {
      // Debug.Log("GameplayActions Disable");
        controls.Gameplay.Disable();
        UIManager.Instance.OnShowUI += controls.Gameplay.Disable;
        UIManager.Instance.OnHideUI += controls.Gameplay.Enable;
    }

    private void Update()
    {
        Vector3 relativeVelocity = transform.InverseTransformDirection(agent.velocity);
        animator.SetFloat(MovementSpeed,relativeVelocity.magnitude);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
       // Debug.Log("OnFire 2Method");
        if (context.performed)
        {
         //   Debug.Log("OnFire Method");
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
       // Debug.Log("OnMove Method");
    }

 
    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           // Debug.Log("OnPickUp");
            //text.text = "OnSelect Right";
            var hits = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Item"));
            foreach (var hit in hits)
            {
                var item = hit.GetComponent<Item>();
                inventory.Add(item);
            }
        }
    }

    public void OnOpenRadialMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           // Debug.Log("Show Radial menu");
            UIManager.Instance.Show(Constants.UI.RADIAL_MENU);
        }
    }
}