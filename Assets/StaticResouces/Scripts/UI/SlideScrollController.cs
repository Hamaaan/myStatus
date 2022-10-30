using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideScrollController : MonoBehaviour,IBeginDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] GameObject Axis;

    Vector3 BeginVec;
    Vector3 OnVec;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginVec = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Axis.transform.Rotate(Vector3.up,eventData.delta.x/3);
        /*
        Vector3 TargetPos = eventData.position;
        TargetPos.z = 0;
        transform.position = TargetPos;
        */
        //Debug.Log("drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Destroy(gameObject);
        //Debug.Log("drop");

    }
}
