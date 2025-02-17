using UnityEngine;

public class save_on_load : MonoBehaviour
{
    private SaveManager saveManager;

    public GameObject save_screen;
    public job_event job_event;
    public tile_event tile_Event;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveManager = Object.FindFirstObjectByType<SaveManager>();

        if (saveManager != null)
        {
            SaveData data = saveManager.LoadGame();
            save_screen.SetActive(false);

            if (data.save_step_taken != 0)
            {
                save_screen.SetActive(true);
                tile_Event.open_popup();
            }
            else
            {
                if (job_event != null)
                {
                    job_event.eventPopUp();
                    tile_Event.open_popup();
                }

                save_screen.SetActive(false);

            }
        }
        else if (job_event != null)
        {
            job_event.eventPopUp();
            tile_Event.open_popup();
            save_screen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
