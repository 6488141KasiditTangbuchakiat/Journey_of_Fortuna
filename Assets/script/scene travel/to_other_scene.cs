using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class to_other_scene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button_load_scene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
