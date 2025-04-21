using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public List<GameObject> pages = new List<GameObject>();
    public int page_num = 0;

    public TextMeshProUGUI number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updatePage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void increase_page()
    {
        page_num++;

        if (page_num >= pages.Count)
        {
            page_num = 0;
        }

        updatePage();
    }

    public void decrease_page()
    {
        page_num--;

        if (page_num < 0)
        {
            page_num = pages.Count - 1;
        }

        updatePage();
    }

    public void updatePage()
    {
        int i = 0;
        foreach (GameObject page in pages)
        {
            if(i == page_num)
            {
                page.SetActive(true);
            }
            else
            {
                page.SetActive(false);
            }

            i++;
        }

        number.SetText($"{page_num + 1}/{pages.Count}");
    }
}
