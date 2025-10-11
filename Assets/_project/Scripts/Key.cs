using UnityEngine;

[RequireComponent (typeof(Rigidbody2D)) ]
public class Key : MonoBehaviour, IPickupable
{
    public Rigidbody2D Pickup()
    {
        return GetComponent<Rigidbody2D>();
    }

    public void SetMoveSpeed(float speed)
    {
        
    }
}
