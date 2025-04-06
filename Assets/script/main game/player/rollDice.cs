using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollDice : MonoBehaviour
{
    playerMovement movement;
    statistics player;

    public int diceResult;

    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<playerMovement>();
        player = gameObject.GetComponent<statistics>();
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

        add_interest();
    }

    public void roll_dice_double()
    {

        int num = Random.Range(1, 7);
        StartCoroutine(movement.move_x_tile_noPopup(num));
        diceResult = num;

        add_interest();
    }

    public void add_interest()
    {
        player.money += calculator.x_in_y_percent(player.money, 2);
        player.reserve_money += calculator.x_in_y_percent(player.reserve_money, 2);
    }

}