using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PressurePlates : MonoBehaviour
{


    bool door0_opened = false;
    [SerializeField]
    private Tilemap tileMap;
    [SerializeField]
    private Tilemap doorsToUnlock;
    [SerializeField]
    private Tile tilePlateNotActive;
    [SerializeField]
    private Tile tilePlateActive;

    private Player player1;
    private Player player2;
    private Rigidbody2D rb;
    private Rigidbody2D rb2;

    private void Start()
    {

        player1 = gameObject.GetComponent<CaptivityManager>().player1;
        player2 = gameObject.GetComponent<CaptivityManager>().player2;
        rb = player1.GetComponent<Rigidbody2D>();
        rb2 = player2.GetComponent<Rigidbody2D>();
    }
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

            if ((distanceTofirstPressurePlate <= 1.0f && rb.position.x > -4 && rb.position.y > -20 && player1.elementalsPossesed[player1.actualElementalIndex] == Player.ElementalsAvailable.HUMAN) ||
                (distanceTofirstPressurePlate2 <= 1.0f && rb2.position.x > -4 && rb2.position.y > -20 && player2.elementalsPossesed[player2.actualElementalIndex] == Player.ElementalsAvailable.HUMAN))
            {
                tileMap.SetTile(firstPressurePlateReal, null);
                tileMap.SetTile(firstPressurePlateReal, tilePlateActive);
                tileMap.SetTileFlags(firstPressurePlateReal, TileFlags.None);
                tileMap.SetColor(firstPressurePlateReal, Color.green);
                firstPressurePlateActive = true;
            }
            else
            {
                tileMap.SetTile(firstPressurePlateReal, null);
                tileMap.SetTile(firstPressurePlateReal, tilePlateNotActive);
                tileMap.SetTileFlags(firstPressurePlateReal, TileFlags.None);
                tileMap.SetColor(firstPressurePlateReal, Color.green);

            }
            //49,-22
            Vector3Int secondPressurePlateReal = new Vector3Int(49, -22, 0);//onTileMap
            float distanceToSecondPressurePlate = Mathf.Sqrt((rb.position.x - (secondPressurePlateReal.x)) * (rb.position.x - (secondPressurePlateReal.x)) + (rb.position.y - (secondPressurePlateReal.y+ 1)) * (rb.position.y - (secondPressurePlateReal.y + 1)));
            float distanceToSecondPressurePlate2 = Mathf.Sqrt((rb2.position.x - (secondPressurePlateReal.x)) * (rb2.position.x - (secondPressurePlateReal.x)) + (rb2.position.y - (secondPressurePlateReal.y + 1)) * (rb2.position.y - (secondPressurePlateReal.y + 1)));
            if ((distanceToSecondPressurePlate <= 1.0f && rb.position.x > secondPressurePlateReal.x && rb.position.y > (secondPressurePlateReal.y) && player1.elementalsPossesed[player1.actualElementalIndex] == Player.ElementalsAvailable.WATER) ||
                (distanceToSecondPressurePlate2 <= 1.0f && rb2.position.x > secondPressurePlateReal.x && rb2.position.y > (secondPressurePlateReal.y ) && player2.elementalsPossesed[player2.actualElementalIndex] == Player.ElementalsAvailable.WATER))
            {
                tileMap.SetTile(secondPressurePlateReal, null);
                tileMap.SetTile(secondPressurePlateReal, tilePlateActive);
                tileMap.SetTileFlags(secondPressurePlateReal, TileFlags.None);
                tileMap.SetColor(secondPressurePlateReal, new Color(0f, 0.9f, 1f));//0,224,255

                secondPressurePlateActive = true;
            }
            else
            {
                tileMap.SetTile(secondPressurePlateReal, null);
                tileMap.SetTile(secondPressurePlateReal, tilePlateNotActive);
                tileMap.SetTileFlags(secondPressurePlateReal, TileFlags.None);
                tileMap.SetColor(secondPressurePlateReal, new Color(0f, 0.9f, 1f));

            }

            if (secondPressurePlateActive && firstPressurePlateActive)
            {
                Vector3Int wallLocation0_0Doorlayer = new Vector3Int(48, -12, 0);
                Vector3Int wallLocation0_1Doorlayer = new Vector3Int(48, -14, 0);
                Vector3Int wallLocation0_2Doorlayer = new Vector3Int(48, -13, 0);
                Vector3Int wallLocation0_3Doorlayer = new Vector3Int(50, -13, 0);
                Vector3Int wallLocation0_4Doorlayer = new Vector3Int(50, -14, 0);
                Vector3Int wallLocation0_5Doorlayer = new Vector3Int(50, -12, 0);
                Vector3Int wallLocation0_6Doorlayer = new Vector3Int(49, -13, 0);
                Vector3Int wallLocation0_7Doorlayer = new Vector3Int(49, -14, 0);
                Vector3Int wallLocation0_8Doorlayer = new Vector3Int(49, -12, 0);
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
