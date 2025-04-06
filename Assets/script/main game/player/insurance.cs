using UnityEngine;

public class insurance : MonoBehaviour
{
    public int price = 0;
    public double reduction;
    public int expiration;


    public enum tier { A, S, L }
    public tier InTier;

    public enum type { Accident, Health, Life, Prelude, None }
    public type InType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        calculate_price();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void calculate_price()
    {
        switch (InTier)
        {
            case tier.A:
                price = 500;
                reduction = 50.0;
                break;

            case tier.S:
                price = 1000;
                reduction = 100.0;
                break;

            default:
                break;
        }
    }

    public int price_from_age(int age)
    {
        return price + (age * 100) - 2300;
    }
}
