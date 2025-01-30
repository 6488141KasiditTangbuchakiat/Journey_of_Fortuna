using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public tile currentTile;
    public tile_event currentTileEvent;
    statistics stats;

    public dice_event diceEvent;

    bool pass_earn = false;
    int pass_earn_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        stats = gameObject.GetComponent<statistics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(move_x_tile(1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(move_x_tile(2));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(move_x_tile(3));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(move_x_tile(4));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine(move_x_tile(5));
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine(move_x_tile(6));
        }
    }

    private void FixedUpdate()
    {
        changePosition(currentTile.myX, currentTile.playerY, currentTile.myZ);
    }

    void changePosition(float _x, float _y, float _z)
    {
        this.transform.position = new Vector3(_x, _y, _z);
    }

    public IEnumerator move_x_tile(int tileNum)
    {

        if (currentTileEvent.popup_on == false)
        {
            for (int i = 0; i < tileNum; i++)
            {
                //if no next tile, then stop
                if (currentTile.nextTile == null)
                {
                    break;
                }


                // walk forward
                currentTile = currentTile.nextTile;
                stats.addEnergy(1);
                stats.one_step();

                if (currentTile.thisTileType == tile.tileType.Earning)
                {
                    pass_earn = true;
                    pass_earn_num++;
                }

                yield return new WaitForSeconds(0.2f);
            }

            //check if walked past green tile

            if (currentTile.thisTileType == tile.tileType.Earning)
            {
                pass_earn = false;
            }


            currentTileEvent.readTile(currentTile, pass_earn);


            pass_earn = false;

        }


    }

    public IEnumerator move_x_tile_noPopup(int tileNum)
    {

        if (currentTileEvent.popup_on == false)
        {
            for (int i = 0; i < tileNum; i++)
            {
                //if no next tile, then stop
                if (currentTile.nextTile == null)
                {
                    break;
                }


                // walk forward
                currentTile = currentTile.nextTile;
                stats.addEnergy(1);
                stats.one_step();

                if (currentTile.thisTileType == tile.tileType.Earning)
                {
                    pass_earn = true;
                    pass_earn_num++;
                }

                yield return new WaitForSeconds(0.2f);
            }

            //check if walked past green tile

            diceEvent.eventPopUp();
        }
    }

    public IEnumerator dash_continue()
    {

        if (currentTileEvent.popup_on == false)
        {
            for (int i = 0; i < stats.step_taken; i++)
            {
                //if no next tile, then stop
                if (currentTile.nextTile == null)
                {
                    break;
                }


                // walk forward
                currentTile = currentTile.nextTile;

                yield return new WaitForSeconds(0.01f);
            }

            //stats.step_reset();
        }
    }

    public void do_dash()
    {
        StartCoroutine(dash_continue());
    }

    public void readTile_for_button()
    {
        if (currentTile.thisTileType == tile.tileType.Earning)
        {
            pass_earn = false;
        }

        currentTileEvent.readTile(currentTile, pass_earn);
        pass_earn = false;
    }

    public int pass_earn_num_and_reset()
    {
        int num = pass_earn_num;
        if(num <= 0)
        {
            num = 1;
        }

        pass_earn_num = 0;

        return num;
    }
}
