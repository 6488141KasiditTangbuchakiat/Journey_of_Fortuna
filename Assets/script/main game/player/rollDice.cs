using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rollDice : MonoBehaviour
{
    playerMovement movement;
    statistics player;

    public GameObject diceSet;
    public DiceRoll_3D dice;

    public GameObject dice_num_sprite_object;
    public Image dice_num_sprite;

    public int diceResult;

    public float wait_time;

    public bool dice_rest = false;

    // Start is called before the first frame update
    void Start()
    {
        movement = gameObject.GetComponent<playerMovement>();
        player = gameObject.GetComponent<statistics>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void roll_dice()
    {
        StartCoroutine(activate_Dice());

        add_interest();
    }

    public void roll_dice_double()
    {
        StartCoroutine(activate_Dice_double());

        add_interest();
    }

    public void add_interest()
    {
        player.money += calculator.x_in_y_percent(player.money, 2);
        player.reserve_money += calculator.x_in_y_percent(player.reserve_money, 2);
    }

    IEnumerator activate_Dice()
    {
        diceSet.SetActive(true);
        dice.rollDice_but_3d();

        yield return new WaitUntil(() => dice_rest);

        dice_num_sprite_object.SetActive(true);
        dice_num_sprite.sprite = Resources.Load<Sprite>($"dice_page/{dice.diceFaceNum}");

        yield return new WaitForSeconds(wait_time);

        dice_num_sprite_object.SetActive(false);
        diceSet.SetActive(false);

        StartCoroutine(movement.move_x_tile(dice.diceFaceNum));
        diceResult = dice.diceFaceNum;
        dice_rest = false;
    }

    IEnumerator activate_Dice_double()
    {
        diceSet.SetActive(true);
        dice.rollDice_but_3d();

        yield return new WaitUntil(() => dice_rest);

        dice_num_sprite_object.SetActive(true);

        yield return new WaitForSeconds(wait_time);

        dice_num_sprite_object.SetActive(false);
        diceSet.SetActive(false);

        StartCoroutine(movement.move_x_tile_noPopup(dice.diceFaceNum));
        diceResult = dice.diceFaceNum;
        dice_rest = false;
    }

    public void time_to_go()
    {
        dice_rest = true;
    }

}