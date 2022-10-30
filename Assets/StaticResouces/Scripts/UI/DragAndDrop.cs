using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IDropHandler
{
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 TargetPos = eventData.position;
        TargetPos.z = 0;
        transform.position = TargetPos;
        //Debug.Log("drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Destroy(gameObject);
        //Debug.Log("drop");

    }

}
