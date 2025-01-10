using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    public int tileID = -1;
    public tile nextTile;

    public float myX;
    public float myY;
    public float myZ;

    public float playerY;

    public enum tileType {Greed, Earning, Opportunity, NEWS, Family, Dangerous}
    public tileType thisTileType;



    // Start is called before the first frame update
    void Start()
    {
        myX = this.transform.position.x;
        myY = this.transform.position.y;
        myZ = this.transform.position.z;

        playerY = myY + 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

}