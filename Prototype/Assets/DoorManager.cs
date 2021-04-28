using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DoorManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D PlayerRb;
    [SerializeField]
    private Tilemap tileMap;

    /*
    [SerializeField]
    private Tile closedDoorUP;
    [SerializeField]
    private Tile closedDoorDown;
    */
    private bool DoorOpenA = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            float distanceToMonumentA = Mathf.Sqrt((PlayerRb.position.x - (-4.0f) )* (PlayerRb.position.x - (-4.0f)) + (PlayerRb.position.y - (1.0f)) * (PlayerRb.position.y - (1.0f)));
                Debug.Log(distanceToMonumentA);
            if (distanceToMonumentA < 1.0f)
            {
                if (DoorOpenA == false)
                {
                    Vector3Int wallLocation0_0Doorlayer = new Vector3Int(6, 7, 0);
                    Vector3Int wallLocation0_1Doorlayer = new Vector3Int(7, 7, 0);
                    Vector3Int wallLocation0_2Doorlayer = new Vector3Int(6, 8, 0);
                    Vector3Int wallLocation0_3Doorlayer = new Vector3Int(7, 8, 0);
                    tileMap.SetTile(wallLocation0_0Doorlayer, null);
                    tileMap.SetTile(wallLocation0_1Doorlayer, null);
                    tileMap.SetTile(wallLocation0_2Doorlayer, null);
                    tileMap.SetTile(wallLocation0_3Doorlayer, null);
                    DoorOpenA = false;
                }
                    /*


                        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Vector3Int gridPosition = tileMap.WorldToCell(mousePosition);

                        //TileData data = mapManager.GetTileData(gridPosition);

                        //Debug.Log(gridPosition);
                        //Debug.Log(gridPosition.ToString());


                        Vector3Int wallLocation0_0 = new Vector3Int(6, 10, 0);
                        Vector3Int wallLocation0_1 = new Vector3Int(7, 10, 0);
                        Vector3Int wallLocation0_2 = new Vector3Int(6, 9, 0);
                        Vector3Int wallLocation0_3 = new Vector3Int(7, 9, 0);

                        Vector3Int wallLocation0_0Doorlayer = new Vector3Int(6, 6, 0);
                        Vector3Int wallLocation0_1Doorlayer = new Vector3Int(7, 6, 0);
                        Vector3Int wallLocation0_2Doorlayer = new Vector3Int(6, 7, 0);
                        Vector3Int wallLocation0_3Doorlayer = new Vector3Int(7, 7, 0);
                        TileBase tile = tileMap.GetTile(gridPosition);

                        if (gridPosition.ToString() == wallLocation0_0.ToString() || gridPosition.ToString() == wallLocation0_1.ToString() || gridPosition.ToString() == wallLocation0_2.ToString() || gridPosition.ToString() == wallLocation0_3.ToString())
                        {

                            tileMap.SetTile(wallLocation0_0Doorlayer, null);
                            tileMap.SetTile(wallLocation0_1Doorlayer, null);
                            tileMap.SetTile(wallLocation0_2Doorlayer, null);
                            tileMap.SetTile(wallLocation0_3Doorlayer, null);
                            DoorOpenA = false;
                        }
                    }
                    */
                }
        }
        
    }

}
