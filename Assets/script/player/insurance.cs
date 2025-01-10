using UnityEngine;

public class insurance : MonoBehaviour
{
    int price;
    public double reduction;

    public enum tier { B, A, S }
    public tier InTier;

    public enum type { Accident, Health }
    public type InType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        calculate_price();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void calculate_price()
    {
        switch (InTier)
        {
            case tier.B:
                price = 100;
                reduction = 30.0;
                break;

            case tier.A:
                price = 500;
                reduction = 50.0;
                break;

            case tier.S:
                price = 1000;
                reduction = 70.0;
                break;

            default: 
                break;
        }
    }
}
