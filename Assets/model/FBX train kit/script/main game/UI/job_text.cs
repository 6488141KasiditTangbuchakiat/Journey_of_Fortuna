using TMPro;
using UnityEngine;

public class job_text : MonoBehaviour
{
    public statistics player;

    public TextMeshProUGUI textMeshPro;

    public string front;
    public string back;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textMeshPro.SetText($"{front} {player.myJob.name_text} {back}");
    }
}
