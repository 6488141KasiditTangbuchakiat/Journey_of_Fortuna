using UnityEngine;

public class doubleDice_button : MonoBehaviour
{

    public statistics statistics;
    public GameObject dice_button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (statistics.hasCar)
        {
            dice_button.SetActive(true);
        }
        else
        {
            dice_button.SetActive(false);
        }
    }
}
