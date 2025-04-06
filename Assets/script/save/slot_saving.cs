using UnityEngine;

public class slot_saving : MonoBehaviour
{
    private slot_saver slotSaver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slotSaver = Object.FindFirstObjectByType<slot_saver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save_slot(int slot_number)
    {
        save_slot data = slotSaver.LoadGame();

        if (data == null)
        {
            data = new save_slot();
        }

        data.player_num = slot_number;

        slotSaver.SaveGame(data);
    }

    public save_slot load_slot()
    {
        save_slot loadeddata = slotSaver.LoadGame();

        if(loadeddata != null)
        {
            return loadeddata;
        }

        return null;
    }
}
