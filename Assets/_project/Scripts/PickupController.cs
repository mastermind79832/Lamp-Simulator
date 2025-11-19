using UnityEngine;
using UnityEngine.InputSystem; // Add this line to use the InputSystem namespace
public class PickupController : MonoBehaviour
{
    private static PickupController instance; // Add this line to create a reference to the PickupController script
    public static PickupController Instance { get { return instance; } } // Add this line to create a static reference to the PickupController script


    private Camera mainCamera;
    private Rigidbody2D pickedItem;
    public float MouseMoveSpeed;
    public bool IsMouseActive;

    void Awake()
    {
        if (instance == null) // Add this line to check if the instance is already assigned
        {
            instance = this; // Add this line to assign the current script as the instance
        }
        else if (instance != this) // Add this line to check if there are multiple instances of the script
        {
            Destroy(gameObject); // Add this line to destroy the duplicate instance
        }
    }

    void Start()
    {
        mainCamera = Camera.main;
        IsMouseActive = true;
    }

    void Update()
    {
        if (!IsMouseActive) return;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                Pickupable pickupable = hit.collider.GetComponent<Pickupable>();
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
            DropItem();
        }
    }

    public void DropItem()
    {
        if (pickedItem != null)
        {
            pickedItem.gravityScale = 1;
            pickedItem = null;
        }
    }

    public void LateUpdate()
    {
        if (pickedItem != null)
        {
            pickedItem.position = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            pickedItem.GetComponent<Pickupable>()?.SetMoveSpeed(MouseMoveSpeed);
        }
    }

}
