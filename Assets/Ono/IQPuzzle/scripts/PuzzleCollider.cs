using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{

    [SerializeField]
    private GameObject CorrectPiece;
    public int ClearNumber;
    private bool Correct;

    void Start()
    {
        Correct = false;
        GetTag();
    }

    public void GetTag()
    {
        Debug.Log(CorrectPiece.tag);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("触れた");
        
        if(other.CompareTag(CorrectPiece.tag)){

        Correct = true;
        ClearNumber =ClearNumber+1;
        Debug.Log(ClearNumber);
        

    }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("抜けた");
        
        if(other.CompareTag(CorrectPiece.tag)){
      
        Correct = false;
        ClearNumber = ClearNumber-1;
        Debug.Log(ClearNumber);
        
    }
    }

}