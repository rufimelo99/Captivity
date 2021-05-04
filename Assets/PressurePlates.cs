using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PressurePlates : MonoBehaviour
{

    public Rigidbody2D rb;
    public Rigidbody2D rb2;

    bool door0_opened = false;
    [SerializeField]
    private Tilemap tileMap;
    [SerializeField]
    private Tilemap doorsToUnlock;
    [SerializeField]
    private Tile tilePlateNotActive;
    [SerializeField]
    private Tile tilePlateActive;

    
    void Update()
    {
        checkPressurePlates();
    }


    void checkPressurePlates()
    {
        if (!door0_opened)
        {
            bool firstPressurePlateActive = false;
            bool secondPressurePlateActive = false;
            Vector3Int playerPosition = new Vector3Int(Mathf.RoundToInt(rb.position.x), Mathf.RoundToInt(rb.position.y), 0);
            Vector3Int otherPlayerPosition = new Vector3Int(Mathf.RoundToInt(rb2.position.x), Mathf.RoundToInt(rb2.position.y), 0);

            Vector3Int gridPosition = tileMap.WorldToCell(playerPosition);
            Vector3Int gridPosition2 = tileMap.WorldToCell(otherPlayerPosition);

            Vector3Int firstPressurePlateReal = new Vector3Int(-4, -20, 0);//onTileMap
            float distanceTofirstPressurePlate = Mathf.Sqrt((rb.position.x - (-4.0f)) * (rb.position.x - (-4.0f)) + (rb.position.y - (-20.0f + 1)) * (rb.position.y - (-20.0f + 1)));
            float distanceTofirstPressurePlate2 = Mathf.Sqrt((rb2.position.x - (-4.0f)) * (rb2.position.x - (-4.0f)) + (rb2.position.y - (-20.0f + 1)) * (rb2.position.y - (-20.0f + 1)));

            if ((distanceTofirstPressurePlate <= 1.0f && rb.position.x > -4 && rb.position.y > -20) ||
                (distanceTofirstPressurePlate2 <= 1.0f && rb2.position.x > -4 && rb2.position.y > -20))
            {
                tileMap.SetTile(firstPressurePlateReal, null);
                tileMap.SetTile(firstPressurePlateReal, tilePlateActive);
                firstPressurePlateActive = true;
            }
            else
            {
                tileMap.SetTile(firstPressurePlateReal, null);
                tileMap.SetTile(firstPressurePlateReal, tilePlateNotActive);

            }

            Vector3Int secondPressurePlateReal = new Vector3Int(49, -23, 0);//onTileMap
            float distanceToSecondPressurePlate = Mathf.Sqrt((rb.position.x - (49.0f)) * (rb.position.x - (49.0f)) + (rb.position.y - (-22.0f)) * (rb.position.y - (-22.0f)));
            float distanceToSecondPressurePlate2 = Mathf.Sqrt((rb2.position.x - (49.0f)) * (rb2.position.x - (49.0f)) + (rb2.position.y - (-22.0f)) * (rb2.position.y - (-22.0f)));
            if ((distanceToSecondPressurePlate <= 1.0f && rb.position.x > 49 && rb.position.y > -22) ||
                (distanceToSecondPressurePlate2 <= 1.0f && rb2.position.x > 49 && rb2.position.y > -22))
            {
                tileMap.SetTile(secondPressurePlateReal, null);
                tileMap.SetTile(secondPressurePlateReal, tilePlateActive);

                secondPressurePlateActive = true;
            }
            else
            {
                tileMap.SetTile(secondPressurePlateReal, null);
                tileMap.SetTile(secondPressurePlateReal, tilePlateNotActive);

            }

            if (secondPressurePlateActive && firstPressurePlateActive)
            {
                Vector3Int wallLocation0_0Doorlayer = new Vector3Int(48, -15, 0);
                Vector3Int wallLocation0_1Doorlayer = new Vector3Int(48, -14, 0);
                Vector3Int wallLocation0_2Doorlayer = new Vector3Int(48, -13, 0);
                Vector3Int wallLocation0_3Doorlayer = new Vector3Int(50, -13, 0);
                Vector3Int wallLocation0_4Doorlayer = new Vector3Int(50, -14, 0);
                Vector3Int wallLocation0_5Doorlayer = new Vector3Int(50, -15, 0);
                Vector3Int wallLocation0_6Doorlayer = new Vector3Int(49, -13, 0);
                Vector3Int wallLocation0_7Doorlayer = new Vector3Int(49, -14, 0);
                Vector3Int wallLocation0_8Doorlayer = new Vector3Int(49, -15, 0);
                doorsToUnlock.SetTile(wallLocation0_0Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_1Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_2Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_3Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_4Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_5Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_6Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_7Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_8Doorlayer, null);
                door0_opened = true;
            }

        }
    }
}
