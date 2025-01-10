using TMPro;
using UnityEngine;

public class stock_price : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;

    public statistics stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats != null)
        {
            int num = stats.stock_price;
            textmeshPro.SetText($"Stock Price: {num}");
        }
    }
}
