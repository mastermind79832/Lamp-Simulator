using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class LampController : Pickupable
{

    public KeyCode LampPwerToggleKey;
    public Light LampLight;
    public float MaxFuel;
    private float CurrentFuel;
    public float FuelDecreaseAmount;
    public float MoveSpeedLimit; // limit after which fuel decreases faster
    public float FastFuelDecreaseAmount;
    public Slider FuelSlider;

    private Rigidbody2D rb; // reference to the Rigidbody2D component   

    private float CurrentMoveSpeed;
    
    public override Rigidbody2D Pickup()
    {
        return GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        CurrentFuel = MaxFuel;
        FuelSlider.value = CurrentFuel;
        FuelSlider.maxValue = MaxFuel;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float TotlaFuelDecreased = FuelDecreaseAmount;
        if (CurrentMoveSpeed >= MoveSpeedLimit)
            TotlaFuelDecreased += FastFuelDecreaseAmount;

        CurrentFuel -= TotlaFuelDecreased * Time.deltaTime;

        FuelSlider.value = CurrentFuel;

    }

    public override void SetMoveSpeed(float speed)
    {
        CurrentMoveSpeed = speed;

    }
}
