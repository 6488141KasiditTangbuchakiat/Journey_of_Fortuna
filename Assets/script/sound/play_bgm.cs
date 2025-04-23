using UnityEngine;

public class play_bgm : MonoBehaviour
{
    public AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager.sound_Play("bgm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
