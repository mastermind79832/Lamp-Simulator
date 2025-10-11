using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite DoorOpenSprite;

    public void Open()
    {
        GetComponent<SpriteRenderer>().sprite = DoorOpenSprite;
    }
}
