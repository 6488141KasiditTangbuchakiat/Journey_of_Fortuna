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
            roll_dice();
        }
    }

    public void roll_dice()
    {

        int num = Random.Range(1, 7);
        StartCoroutine(movement.move_x_tile(num));
        diceResult = num;

    }

    public void roll_dice_double()
    {

        int num = Random.Range(1, 7);
        StartCoroutine(movement.move_x_tile(num));
        diceResult = num;

    }

}