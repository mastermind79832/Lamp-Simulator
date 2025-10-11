using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Axe : MonoBehaviour, IPickupable
{
    private Rigidbody2D rb;
    private float CurrentMoveSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Rigidbody2D Pickup()
    {
        return rb;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(rb.linearVelocity.magnitude);

        if (collision.gameObject.TryGetComponent(out Boulder boulder))
        {
            if(CurrentMoveSpeed > boulder.m_SpeedRequiredToDamage)
                boulder.DecreaseHealth();
        }
    }

    public void SetMoveSpeed(float speed)
    {
        CurrentMoveSpeed = speed;
    }
}
