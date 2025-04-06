using UnityEngine;

public class result_load : MonoBehaviour
{
    public playerState_save state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state.loadPlayerData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
