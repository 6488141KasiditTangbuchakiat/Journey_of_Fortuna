using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public tile currentTile;
    public tile_event currentTileEvent;
    statistics stats;

    int tile_save = 0;

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
            // print("pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(move_x_tile(2));
            // print("pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(move_x_tile(3));
            // print("pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(move_x_tile(4));
            // print("pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine(move_x_tile(5));
            // print("pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine(move_x_tile(6));
            // print("pressed");
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
                if (currentTile.nextTile == null)
                {
                    break;
                }
                currentTile = currentTile.nextTile;

                if (currentTile.thisTileType == tile.tileType.Earning)
                {
                    stats.addMoney(100);

                    tile_save = tileNum - i - 1;

                    if (tile_save <= 0)
                    {
                        tile_save = 0;
                    }
                    print("have left = " + tile_save);
                    break;
                }

                yield return new WaitForSeconds(0.2f);
            }

            print(currentTile);
            currentTileEvent.readTile(currentTile);
        }


    }

    public void move_tile_save()
    {
        if (tile_save > 0)
        {
            StartCoroutine(move_x_tile(tile_save));
            tile_save = 0;
        }

    }
}
