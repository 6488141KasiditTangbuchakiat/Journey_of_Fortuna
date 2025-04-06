using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class select_boy_girl : MonoBehaviour
{
    public int gender = 0;

    public GameObject boy;
    public GameObject girl;

    public TMP_InputField my_name;
    public TextMeshProUGUI name_text;

    public GameObject play_button;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boy.SetActive(false);
        girl.SetActive(false);

        play_button.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gender == 1)
        {
            boy.SetActive(true);
            girl.SetActive(false);
        }
        else if (gender == 2)
        {
            boy.SetActive(false);
            girl.SetActive(true);
        }

        if (my_name.text == "" || gender == 0)
        {
            if (name_text != null)
            {
                play_button.SetActive(false);
            }
        }
        else
        {
            play_button.SetActive(true);
        }
    }

    public void select_gender(int i)
    {
        gender = i;
    }
}
