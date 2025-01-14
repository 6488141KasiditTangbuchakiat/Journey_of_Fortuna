using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class money_text : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro;

    public statistics stats;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stats != null)
        {
            int num = stats.money;
            textmeshPro.SetText($"Money: {num}");
        }
    }
}
