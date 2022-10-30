using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragOnWorld : MonoBehaviour, IDragHandler, IDropHandler, IEndDragHandler
{
    Rigidbody2D GetRd;


    // Start is called before the first frame update
    void Start()
    {
        GetRd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GetRd != null)
        {
            GetRd.simulated = false;
        }

        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(eventData.position);
        TargetPos.z = 0;
        transform.position = TargetPos;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GetRd != null)
        {
            GetRd.simulated = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        

    }
}
