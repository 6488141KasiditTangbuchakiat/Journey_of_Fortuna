using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statistics : MonoBehaviour
{
    public int money = 0;

    public int energy = 0;
    public int energy_cap = 100;

    public int stock_price = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(int money_gain)
    {
        this.money += money_gain;
        print("add money");
    }

    public void addEnergy(int energy_gain)
    {
        this.energy += energy_gain;

        if(this.energy > this.energy_cap)
        {
            this.energy = this.energy_cap;
        }
    }

    public void stockpriceChange(int changed_price)
    {
        this.stock_price = changed_price;
    }
}
