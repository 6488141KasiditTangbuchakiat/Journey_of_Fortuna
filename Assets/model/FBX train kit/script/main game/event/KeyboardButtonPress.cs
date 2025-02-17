using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyboardButtonPress : MonoBehaviour
{
    public Button yourButton; // Reference to the UI button
    public KeyCode keyToPress = KeyCode.Space; // Key to press (Enter key by default)

    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(keyToPress))
        {
            // Trigger the button click event
            yourButton.onClick.Invoke();
        }
    }
}