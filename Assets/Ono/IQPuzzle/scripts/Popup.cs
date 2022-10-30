using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject1")]
    private GameObject createPrefab1;
    [SerializeField]
    [Tooltip("生成するGameObject2")]
    private GameObject createPrefab2;
    [SerializeField]
    [Tooltip("生成するGameObject3")]
    private GameObject createPrefab3;
    [SerializeField]
    [Tooltip("生成するGameObject4")]
    private GameObject createPrefab4;
    [SerializeField]
    [Tooltip("PieceSet")]
    public GameObject PieceSet;

    // Start is called before the first frame update
    void Start()
    {
        var parent = PieceSet.transform;

        for (int i = 0; i < 16; i++)
        {   
            Instantiate(createPrefab1, new Vector3( -0.5f,-3f, 0f), Quaternion.identity,parent);
        } 
        for (int i = 0; i < 16; i++)
        {
            Instantiate(createPrefab2, new Vector3( 0.5f,-3f, 0f), Quaternion.identity,parent);
        } 
        for (int i = 0; i < 16; i++)
        {
            Instantiate(createPrefab3, new Vector3( -0.5f,-4f, 0f), Quaternion.identity,parent);
        } 
        for (int i = 0; i < 16; i++)
        {
            Instantiate(createPrefab4, new Vector3( 0.5f,-4f, 0f), Quaternion.identity,parent);
        } 


    }

}
