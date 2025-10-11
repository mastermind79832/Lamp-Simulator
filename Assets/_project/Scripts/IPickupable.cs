using UnityEngine;

public interface IPickupable 
{
    public Rigidbody2D Pickup();
    public void SetMoveSpeed(float speed);
}
