using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColliderManager : MonoBehaviour
{
    [SerializeField] GameObject SpawnCollider;
    public GameObject col;
    Vector3 pre_colPos;
    SpawnCollider spawncol;
    public bool isSpawn = false;

    public int col_num;

    // Start is called before the first frame update
    void Start()
    {
        pre_colPos = Vector2.zero;
        GenerateCollider();
    }

    // Update is called once per frame
    void Update()
    {
        isSpawn = spawncol.isTrigger;

        if (isSpawn)
        {
            GenerateCollider();
        }
    }

    public void GenerateCollider()
    {
        col = Instantiate(SpawnCollider);
        col.transform.position = pre_colPos + new Vector3(0.4f * 14, 0, 0);
        spawncol = col.GetComponent<SpawnCollider>();

        pre_colPos = col.transform.position;

        col_num++;
    }
}
