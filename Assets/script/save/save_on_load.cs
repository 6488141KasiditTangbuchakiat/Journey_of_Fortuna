using Unity.VisualScripting;
using UnityEngine;

public class save_on_load : MonoBehaviour
{
    private SaveManager saveManager;

    public playerState_save save_file;

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

            if (data != null)
            {

                print(data.save_player_stage);

                if (data.save_player_stage != 0)
                {
                    save_file.loadPlayerData();
                }
                else
                {
                    save_file.savePlayerData();

                    data = saveManager.LoadGame();
                }


                // check if has done something

                if (data.save_step_taken != 0 || data.save_myJob != "kid")
                {
                    if (data.save_player_stage == 2)
                    {
                        save_screen.SetActive(true);
                        tile_Event.open_popup();
                    }
                    else if (data.save_step_taken != 0)
                    {
                        save_screen.SetActive(true);
                        tile_Event.open_popup();
                    }


                    // has save
                    print("case 1");
                }
                else
                {
                    if (job_event != null)
                    {
                        job_event.eventPopUp();
                        tile_Event.open_popup();
                    }

                    // no save
                    save_screen.SetActive(false);
                    print("case 2");
                }
            }
            else
            {
                if (job_event != null)
                {
                    job_event.eventPopUp();
                    tile_Event.open_popup();


                    // save guard for case 2
                    print("case 3");
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
