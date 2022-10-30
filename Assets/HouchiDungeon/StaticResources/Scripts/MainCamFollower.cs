using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamFollower : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, this.gameObject.transform.position.z);
        this.gameObject.transform.position = pos;
    }
}
