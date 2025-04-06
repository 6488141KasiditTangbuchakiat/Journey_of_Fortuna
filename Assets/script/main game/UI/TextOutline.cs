using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class TextOutline : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro.outlineColor = Color.white;
        textMeshPro.outlineWidth = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
