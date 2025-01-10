using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statistics : MonoBehaviour
{
    public int money = 0;

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
}
