using TMPro;
using UnityEngine;

public class show_money : MonoBehaviour
{
    public statistics player;
    public TextMeshProUGUI money_txt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        money_txt.SetText($"{ player.money.ToString("N0")}");
    }
}
