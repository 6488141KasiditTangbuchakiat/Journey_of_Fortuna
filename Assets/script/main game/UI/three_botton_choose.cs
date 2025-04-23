using UnityEngine;

public class three_botton_choose : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public GameObject chosen1;
    public GameObject chosen2;
    public GameObject chosen3;

    public int button_choosen = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
    }

    public void choose_button(int i)
    {
        button_choosen = i;

        button_show();
    }

    public void button_show()
    {
        if (button_choosen == 1)
        {
            button1.SetActive(true);
            button2.SetActive(false);
            button3.SetActive(false);

            chosen1.SetActive(true);
            chosen2.SetActive(false);
            chosen3.SetActive(false);
        }
        else if (button_choosen == 2)
        {
            button1.SetActive(false);
            button2.SetActive(true);
            button3.SetActive(false);

            chosen1.SetActive(false);
            chosen2.SetActive(true);
            chosen3.SetActive(false);
        }
        else if (button_choosen == 3)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(true);

            chosen1.SetActive(false);
            chosen2.SetActive(false);
            chosen3.SetActive(true);
        }
    }
}
