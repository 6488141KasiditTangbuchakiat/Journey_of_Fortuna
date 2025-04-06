using System.Collections;
using TMPro;
using UnityEngine;

public class summary : MonoBehaviour
{
    public TextMeshProUGUI summary_text;
    public statistics player;

    public GameObject button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void trigger_summary()
    {
        StartCoroutine(write_summary());
    }

    IEnumerator write_summary()
    {
        string txt = "";
        int counter = 0;
        int limit = 99;

        foreach (string record in player.life_record)
        {
            yield return new WaitForSeconds(0.5f);

            if (counter > limit)
            {
                txt = txt + "and much more!";
                break;
            }
            else
            {
                txt += record + "\n";
                counter++;
            }

            summary_text.SetText(txt);


        }

        yield return new WaitForSeconds(1.0f);
        button.SetActive(true);
    }
}
