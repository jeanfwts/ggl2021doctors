using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformeDecorator : MonoBehaviour
{
    public bool playground = true;

    private void Start()
    {

        Debug.Log("Start PD");
        Tilemap pgTileMap = transform.Find("Tilemap").GetComponent<Tilemap>();
        Debug.Log("child compoenent found: "+ pgTileMap);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("decorate");
            decorate();
        }
    }

    

    private void decorate()
    {
        Tilemap pgTileMap = transform.Find("Tilemap").GetComponent<Tilemap>();
        BoundsInt bounds = pgTileMap.cellBounds;
        TileBase[] allTiles = pgTileMap.GetTilesBlock(bounds);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                }
                else
                {
                    Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }
    }
}
