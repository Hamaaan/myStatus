using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToRotation : MonoBehaviour
{
     [SerializeField]
    private GameObject NextRotation;
    [SerializeField]
    private GameObject PieceSet;

    public void onClickAct()
     {  
        var parent = PieceSet.transform;
        Vector3 tmp = this.gameObject.transform.position;
        Instantiate(NextRotation, new Vector3(tmp.x, tmp.y, tmp.z), Quaternion.identity,parent);
        Destroy( this.gameObject );

    }
}

