using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class create_folder : MonoBehaviour
{
    private string saveFilePath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        saveFilePath = Application.persistentDataPath;

        if (!Directory.Exists(saveFilePath + "/greed"))
        {
            var folder = Directory.CreateDirectory(saveFilePath + "/greed");
        }

        if (!Directory.Exists(saveFilePath + "/news"))
        {
            var folder = Directory.CreateDirectory(saveFilePath + "/news");
        }

        if (!Directory.Exists(saveFilePath + "/oppo"))
        {
            var folder = Directory.CreateDirectory(saveFilePath + "/oppo");
        }

        if (!Directory.Exists(saveFilePath + "/oppo2"))
        {
            var folder = Directory.CreateDirectory(saveFilePath + "/oppo2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
