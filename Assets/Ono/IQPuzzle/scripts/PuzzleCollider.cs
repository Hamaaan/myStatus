using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{

    [SerializeField]
    private GameObject CorrectPiece;
    private bool Correct;
    //public int ClearNumbers;
    public Clear ClearA;

    void Start()
    {
        ClearA = ClearA.GetComponent<Clear>();
        Correct = false;

    }

    public void GetTag()
    {
        Debug.Log(CorrectPiece.tag);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("触れた");
        
        if(other.CompareTag(CorrectPiece.tag))
        {
             Debug.Log(CorrectPiece.tag);

        Correct = true;  //Debug.Log("あたり");
        ClearA.ClearNumbers = ClearA.ClearNumbers+1;
        Debug.Log(ClearA.ClearNumbers);
        
    }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("抜けた");
        
        if(other.CompareTag(CorrectPiece.tag)){
      
        Correct = false;
        ClearA.ClearNumbers = ClearA.ClearNumbers-1;
        Debug.Log(ClearA.ClearNumbers);

        
    }
    }

}