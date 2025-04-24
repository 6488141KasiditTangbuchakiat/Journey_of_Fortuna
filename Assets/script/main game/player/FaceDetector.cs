using System.Collections;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    DiceRoll_3D dice;
    public rollDice rolling_dice;

    public float wait_time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dice = FindFirstObjectByType<DiceRoll_3D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (dice != null)
        {
            if(dice.GetComponent<Rigidbody>().linearVelocity == Vector3.zero)
            {
                dice.diceFaceNum = int.Parse(other.name);

                StartCoroutine(time_to_walk());
            }
        }
    }

    IEnumerator time_to_walk()
    {
        yield return new WaitForSeconds(wait_time);

        rolling_dice.time_to_go();
    }
}
