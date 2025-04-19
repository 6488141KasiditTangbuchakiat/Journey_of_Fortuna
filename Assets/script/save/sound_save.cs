using UnityEngine;
using UnityEngine.Audio;

public class sound_save : MonoBehaviour
{
    private SoundSaveManager soundSaveManager;

    public AudioMixer sfx;
    public AudioMixer bgs;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundSaveManager = Object.FindFirstObjectByType<SoundSaveManager>();

        loadSoundData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void saveSoundData()
    {
        SoundData data = soundSaveManager.LoadSound();

        if (data == null)
        {
            data = new SoundData();
        }

        sfx.GetFloat("volume", out data.sfx_volume);
        bgs.GetFloat("volume", out data.bgs_volume);


        soundSaveManager.SaveSound(data);
    }

    public void loadSoundData()
    {
        SoundData loadedData = soundSaveManager.LoadSound();

        if (loadedData != null)
        {
            sfx.SetFloat("volume", loadedData.sfx_volume);
            bgs.SetFloat("volume", loadedData.bgs_volume);

        }
    }
}
