using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        my_name.onEndEdit.AddListener(HandleInput);
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
    }

    public void select_gender(int i)
    {
        gender = i;
    }

    void HandleInput(string input)
    {
        // Check if the input is empty or not
        if (string.IsNullOrEmpty(input) || gender == 0)
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
}
