using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MaxFear;
    private float FearValue;
    public Slider FearVisual;
    public Transform Lamp;

    public float DistanceFromLamp; // Distance from the lamp where fear starts increasing
    public float FearIncreaseRate; // Rate at which fear increases per second
    public float FearDecreaseRate;
    void Start()
    {
        FearValue = 0f;
        FearVisual.value = FearValue;
        FearVisual.maxValue = MaxFear;
    }

    void Update()
    {
        float distanceToLamp = Vector2.Distance(transform.position, Lamp.position);
        if (distanceToLamp < DistanceFromLamp)
        {
            FearValue -= FearDecreaseRate * Time.deltaTime;
            if(FearValue <= 0)
            {
                FearValue = 0;
            }
        }
        else
        {
            FearValue += FearIncreaseRate * Time.deltaTime;

            if (FearValue >= MaxFear)
            {
                FearValue = MaxFear;
                //GameOver
            }
        }
        
        FearVisual.value = FearValue;
    }

}
