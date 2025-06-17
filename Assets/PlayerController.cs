// using UnityEngine;
// using UnityEngine.InputSystem; // Required for the new Input System

// public class PlayerController : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 20f;
//     [SerializeField] private float laneBoundary = 9f;

//     private Vector2 moveInput;

//     // This function is automatically called by the Player Input component
//     public void OnMove(InputAction.CallbackContext context)
//     {
//         moveInput = context.ReadValue<Vector2>();
//     }

//     void Update()
//     {
//         // Get the left/right input
//         float horizontalInput = moveInput.x;

//         // Apply movement
//         Vector3 movement = new Vector3(horizontalInput, 0, 0);
//         transform.Translate(movement * moveSpeed * Time.deltaTime);
        
//         // Apply boundaries
//         Vector3 currentPosition = transform.position;
//         currentPosition.x = Mathf.Clamp(currentPosition.x, -laneBoundary, laneBoundary);
//         transform.position = currentPosition;
//     }
// }

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float laneBoundary = 9f;

    private Vector2 moveInput;
    private Animator animator; // <-- The new variable

    // This function is automatically called by the Player Input component
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Start() // <-- The new Start function
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get the left/right input that the OnMove function stored for us.
        float horizontalInput = moveInput.x;

        // Send the input value to the Animator
        animator.SetFloat("moveX", horizontalInput); 

        // If there is no horizontal input, we are idle.
        animator.SetBool("isIdle", horizontalInput == 0);

        // Calculate and apply movement.
        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        
        // Clamp the position to stay within the boundaries.
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -laneBoundary, laneBoundary);
        transform.position = currentPosition;
    }
}