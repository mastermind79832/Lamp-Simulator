using UnityEngine;

[RequireComponent (typeof(Rigidbody2D)) ]
public class Key : Pickupable
{
    public override Rigidbody2D Pickup()
    {
        return GetComponent<Rigidbody2D>();
    }

    public override void SetMoveSpeed(float speed)
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent(out Door door))
        {
            door.Open();

            gameObject.SetActive(false);
        }
    }

}
