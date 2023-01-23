using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour, PlayerControls.IPlayerActions
{
    private PlayerControls controls;
    private Animator animator;
    private NavMeshAgent agent;
    private Camera mainCamera;
    private static readonly int MovementSpeed = Animator.StringToHash("movementSpeed");

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        mainCamera=Camera.main;
    }

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new PlayerControls();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
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
            Vector2 mousePosition = controls.Player.Move.ReadValue<Vector2>();
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                Debug.Log(mousePosition);
                agent.SetDestination(hit.point);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
       
    }
    
}