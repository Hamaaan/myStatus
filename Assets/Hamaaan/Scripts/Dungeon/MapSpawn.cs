using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] frontTiles;
    [SerializeField] GameObject backTile;
    SpawnColliderManager spm;
    [SerializeField] Transform GenerateGrid;

    // Start is called before the first frame update
    void Start()
    {
        spm = GetComponent<SpawnColliderManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (spm.isSpawn)
        {
            if (spm.col_num % 6 == 3)
            {
                GenerateTiles();
            }
        }
        
    }

    void GenerateTiles()
    {
        GameObject[] tiles = new GameObject[6];

        for (int i = 0; i < tiles.Length; i++)
        {
            //front
            tiles[i] = Instantiate(frontTiles[Random.Range(0, frontTiles.Length)]);
            tiles[i].transform.position = new Vector3(spm.col.transform.position.x + (i+3) * 5.6f, 0, 1);
            tiles[i].transform.SetParent(GenerateGrid);

            //background
            if (i == 3)
            {
                GameObject backtile = Instantiate(backTile);
                backtile.transform.position = new Vector3(spm.col.transform.position.x + (i + 3) * 5.6f, 0, 1);
                backtile.transform.SetParent(GenerateGrid);
            }
        }
    }
}
