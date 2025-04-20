using UnityEngine;

public class obj_moving : MonoBehaviour
{
    public RectTransform panel;         // Assign in Inspector
    public Vector2 hiddenPosition;      // Off-screen position
    public Vector2 visiblePosition;     // On-screen position
    public float slideDuration = 0.5f;  // Seconds

    public float moveIncrement = 0;

    bool isOpen = true;

    private void Start()
    {

    }

    public void SlideIn()
    {
        StopAllCoroutines();
        StartCoroutine(Slide(panel, panel.anchoredPosition, visiblePosition));
    }

    public void SlideOut()
    {
        StopAllCoroutines();
        StartCoroutine(Slide(panel, panel.anchoredPosition, hiddenPosition));
    }

    private System.Collections.IEnumerator Slide(RectTransform target, Vector2 from, Vector2 to)
    {
        float elapsed = 0;
        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / slideDuration);
            target.anchoredPosition = Vector2.Lerp(from, to, t);
            yield return null;
        }
        target.anchoredPosition = to;
    }

    public void toggle_tab()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            SlideIn();
        }
        else
        {
            SlideOut();
        }
    }
}
