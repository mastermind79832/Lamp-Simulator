using UnityEngine;

public abstract class Pickupable : MonoBehaviour 
{
    public abstract Rigidbody2D Pickup();
    public abstract void SetMoveSpeed(float speed);

    void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit(collision);
    }

    protected virtual void OnHit(Collision2D collision)
    {
        PickupController.Instance.DropItem();
    }
}
