using UnityEngine;

public class TwoD_billboard : MonoBehaviour
{
    public Camera Camera;

    public float pan_up = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = Camera.transform.position;

        cameraPos.y = transform.position.y;

        transform.LookAt(cameraPos);
        transform.Rotate(pan_up, 180f, 0f);
    }
}
