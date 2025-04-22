using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class DiceRoll_3D : MonoBehaviour
{
    Rigidbody body;

    [SerializeField]
    private float maxRandomForceValue, startRollingForce;
    private float forceX, forceY, forceZ;
    public int diceFaceNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rollDice_but_3d()
    {
        body.isKinematic = false;

        forceX = Random.Range(0.0f, maxRandomForceValue);
        forceY = Random.Range(0.0f, maxRandomForceValue);
        forceZ = Random.Range(0.0f, maxRandomForceValue);

        body.AddForce(Vector3.up * startRollingForce);
        body.AddTorque(forceX, forceY, forceZ);
    }

    void Initialize()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }
}
