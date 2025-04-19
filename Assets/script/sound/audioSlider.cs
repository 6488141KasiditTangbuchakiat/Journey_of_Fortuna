using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioSlider : MonoBehaviour
{
    public Slider volumeSLider;
    public AudioMixer mixer;
    private float value;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mixer.GetFloat("volume", out value);
        volumeSLider.value = value;
    }

    public void setVolume()
    {
        mixer.SetFloat("volume", volumeSLider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
