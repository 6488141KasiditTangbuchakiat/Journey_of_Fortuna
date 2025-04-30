using UnityEngine;

public class diff_select : MonoBehaviour
{
    public int difficulty_level = 0;
    public GameObject diff_button;

    public GameObject easy;
    public GameObject normal;
    public GameObject hard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (difficulty_level == 0)
        {
            diff_button.SetActive(false);
        }
        else
        {
            diff_button.SetActive(true);
        }

        if (difficulty_level == 1)
        {
            easy.SetActive(true);
            normal.SetActive(false);
            hard.SetActive(false);
        }
        else if (difficulty_level == 2)
        {
            easy.SetActive(false);
            normal.SetActive(true);
            hard.SetActive(false);
        }
        else if (difficulty_level == 3)
        {
            easy.SetActive(false);
            normal.SetActive(false);
            hard.SetActive(true);
        }
    }


    public void choose_diff(int diff)
    {
        difficulty_level = diff;
    }
}

