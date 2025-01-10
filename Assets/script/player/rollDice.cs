using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollDice : MonoBehaviour
{
    playerMovement movement;

    public int diceResult;

    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int num = Random.Range(1, 7);
            StartCoroutine(movement.move_x_tile(num));
            print(num);
            diceResult = num;
        }
    }
}
