using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign a UI Text component in the Inspector

    public float time = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;

            int totalSeconds = Mathf.FloorToInt(time);
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        time = 0f;
        timerText.text = "00:00:00";
    }
}
