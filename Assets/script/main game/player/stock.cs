using UnityEngine;

public class stock : MonoBehaviour
{
    public string company_name;
    public int stock_price;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_stock_price(int new_price)
    {
        stock_price = new_price;
    }
}
