using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyPrefabs;
    public int enemyCount;

    SpawnColliderManager spm;


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
            GenerateEnemys();
        }
    }

    public void GenerateEnemys()
    {
        GameObject enemy = Instantiate(EnemyPrefabs[Random.Range(0, (EnemyPrefabs.Length))]);

        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1 - r);
        float b = 1 - r - g;
        //enemy.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, 1) * 2f;

        enemy.transform.SetParent(this.gameObject.transform);
        enemy.transform.position += new Vector3(spm.col.transform.position.x - (Random.Range(0.4f, 2f)), 0, 1);
        if (enemy.name == "BirdEnemy(Clone)")
        {
            enemy.transform.position += new Vector3(0, Random.Range(0.2f, 3f), 1);
        }


        /*
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefabs[Random.Range(0, (EnemyPrefabs.Length))]);

            float r = Random.Range(0,1f);
            float g = Random.Range(0,1-r);
            float b = 1 - r - g;
            enemy.GetComponent<SpriteRenderer>().material.color = new Color(r,g,b,1) * 2f;

            enemy.transform.SetParent(this.gameObject.transform);
            enemy.transform.position += new Vector3(((i+1) * Random.Range(8f,10f)), 0, 1);
            if (enemy.name == "BirdEnemy(Clone)")
            {
                enemy.transform.position += new Vector3(0, Random.Range(2, 3), 1);
            }
        }
        */
    }
}
