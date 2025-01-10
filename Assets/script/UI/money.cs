using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class money : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;

    public statistics stats;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats != null)
        {
            int num = stats.money;
            textmeshPro.SetText($"Your money: {num}");
        }
    }
}
