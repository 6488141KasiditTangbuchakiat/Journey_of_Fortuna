using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public tile currentTile;
    public tile_event currentTileEvent;
    statistics stats;

    bool pass_earn = false;

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

                if (currentTile.thisTileType == tile.tileType.Earning)
                {
                    pass_earn = true;
                }

                yield return new WaitForSeconds(0.2f);
            }

            //check if walked past green tile

            if(currentTile.thisTileType == tile.tileType.Earning)
            {
                pass_earn = false;
            }


            currentTileEvent.readTile(currentTile, pass_earn);


            pass_earn = false;

        }


    }
}
