using UnityEngine;

public class continue_check : MonoBehaviour
{
    public GameObject cont_button;
    private SaveManager saveManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();

        SaveData loadedData = saveManager.LoadGame();

        if (loadedData != null)
        {
            cont_button.SetActive(true);
        }
        else
        {
            cont_button.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
