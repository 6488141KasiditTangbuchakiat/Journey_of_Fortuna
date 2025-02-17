using UnityEngine;

public class SaveLoader : MonoBehaviour
{
    private SaveManager saveManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();

        // Try loading the game on start
        SaveData loadedData = saveManager.LoadGame();

        if (loadedData != null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
