using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Axe : Pickupable
{
    private Rigidbody2D rb;
    private float CurrentMoveSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override Rigidbody2D Pickup()
    {
        return rb;
    }

    protected override void OnHit(Collision2D collision)
    {
        Debug.Log("Axe hit something!");
        Debug.Log(rb.linearVelocity.magnitude);

        if (collision.gameObject.TryGetComponent(out Boulder boulder))
        {
            if(CurrentMoveSpeed > boulder.m_SpeedRequiredToDamage)
                boulder.DecreaseHealth();
        }
        base.OnHit(collision); // Call the base class method to handle default behavior
    }

    public override void SetMoveSpeed(float speed)
    {
        CurrentMoveSpeed = speed;
    }
}
