using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    public static GlobalAudioManager Instance;
    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Awake()
    {

        // Make sure only one instance exists
        /*
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make it persistent
        }
        else
        {
            Destroy(gameObject);
        }*/
    }

    public void PlayClickSound()
    {
        if (audioSource && clickSound)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
