using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeText : MonoBehaviour
{

    TextMeshProUGUI textmeshPro;

    public rollDice diceResult;


    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (diceResult != null)
        {
            int num = diceResult.diceResult;
            textmeshPro.SetText($"You rolled: {num}");
        }
        
    }
}
