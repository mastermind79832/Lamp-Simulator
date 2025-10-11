using UnityEngine;
using UnityEngine.InputSystem; // Add this line to use the InputSystem namespace
public class MouseController : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D pickedItem;
    public float MouseMoveSpeed;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
                if (pickupable != null)
                {
                    pickedItem = pickupable.Pickup(); // Assign the picked item to a variable for later use
                    pickedItem.gravityScale = 0;
                }
            }
        }

        //calculate mouse movement speed
        if (Mouse.current.leftButton.isPressed && pickedItem != null)
        {
            Vector2 value = (Vector2)Mouse.current.delta.ReadValue() / Time.deltaTime; // Calculate the mouse movement speed
            MouseMoveSpeed = value.magnitude;

            Debug.Log(MouseMoveSpeed);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (pickedItem != null)
            {
                pickedItem.gravityScale = 1;
                pickedItem = null;
            }
        }
    }

    public void LateUpdate()
    {
        if (pickedItem != null)
        {
            pickedItem.position = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            pickedItem.GetComponent<IPickupable>()?.SetMoveSpeed(MouseMoveSpeed);
        }
    }

}
