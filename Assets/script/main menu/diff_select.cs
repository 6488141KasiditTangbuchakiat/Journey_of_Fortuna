using UnityEngine;

public class diff_select : MonoBehaviour
{
    public int difficulty_level = 0;
    public GameObject diff_button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(difficulty_level == 0)
        {
            diff_button.SetActive(false);
        }
        else
        {
            diff_button.SetActive(true);
        }
    }

    public void choose_diff(int diff)
    {
        difficulty_level = diff;
    }
}
